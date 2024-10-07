﻿using Microsoft.Xrm.Sdk;
using Microsoft.Xrm.Sdk.Query;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kpmg.CRM.BookRooms
{
    public class BookRoomClass
    {
        private IOrganizationService _organizationService;
        const string bookroomSchemaName = "kpmg_bookroom";
        const string roomSchemaName = "kpmg_room";
        const string buildingSchemaName = "kpmg_building";
        const string predefinedtimeslotsSchemaName = "kpmg_predefinedtimeslots";

        public BookRoomClass(IOrganizationService service) {
            _organizationService = service;
        }
        public void validateifBookedExistBefore(DateTime bookingDate, EntityReference roomId, EntityReference timeSlot)
        {
           
            // Check for existing bookings
            QueryExpression queryBookAlreadyExist = new QueryExpression(bookroomSchemaName)
            {
                ColumnSet = new ColumnSet(false),
                Criteria =
                {
                    Conditions =
                    {
                        new ConditionExpression("kpmg_room", ConditionOperator.Equal, roomId),
                        new ConditionExpression("kpmg_bookingday", ConditionOperator.Equal, bookingDate),
                        new ConditionExpression("kpmg_predefinedtimeslots", ConditionOperator.Equal, timeSlot)
                    }
                }
            };

            var existingBookings = _organizationService.RetrieveMultiple(queryBookAlreadyExist);

            if (existingBookings.Entities.Count > 0)
            {
                throw new InvalidPluginExecutionException("A booking already exists for this room at the specified date and time.");
            }
        }

        public void getAvailablerooms()
        {
            // Specify the booking date
            DateTime bookingDate = new DateTime(2024, 10, 07); // Specify your booking date

            #region Query for all Rooms
            QueryExpression roomQuery = new QueryExpression(roomSchemaName)
            {
                ColumnSet = new ColumnSet("kpmg_name", "kpmg_building") // Add other fields as needed
            };

            // Create a LinkEntity to join with the Building entity
            LinkEntity linkBuilding = new LinkEntity(roomSchemaName, buildingSchemaName, "kpmg_building", "kpmg_buildingid", JoinOperator.Inner);
            linkBuilding.Columns.AddColumns("kpmg_isblocked"); // Specify the fields to retrieve from the Building entity
            linkBuilding.EntityAlias = "building"; // Optional: Set an alias for the linked entity

            // Add criteria to filter for buildings where isblocked is true
            linkBuilding.LinkCriteria = new FilterExpression
            {
                Conditions ={
                                new ConditionExpression("kpmg_isblocked", ConditionOperator.Equal, false)
                }
            };

            roomQuery.LinkEntities.Add(linkBuilding);
            EntityCollection allRooms = _organizationService.RetrieveMultiple(roomQuery);
            #endregion
            // Step 2: Query for all TimeSlots
            QueryExpression timeSlotQuery = new QueryExpression(predefinedtimeslotsSchemaName)
            {
                ColumnSet = new ColumnSet("kpmg_to", "kpmg_from") // Adjust fields as necessary
            };

            // Execute the query to get all time slots
            EntityCollection allTimeSlots = _organizationService.RetrieveMultiple(timeSlotQuery);

            // Step 3: Query for BookRoom entries for the specified date
            QueryExpression bookingQuery = new QueryExpression(bookroomSchemaName)
            {
                ColumnSet = new ColumnSet("kpmg_room", "kpmg_predefinedtimeslots"),
                Criteria = new FilterExpression
                {
                    Conditions =
                                {
                                    new ConditionExpression("kpmg_bookingday", ConditionOperator.Equal, bookingDate)
                                }
                }
            };

            // Execute the booking query
            EntityCollection bookedRooms = _organizationService.RetrieveMultiple(bookingQuery);

            // Step 4: Create a HashSet for booked room and time slot pairs for quick lookup
            HashSet<Tuple<Guid, Guid>> bookedRoomTimeSlots = new HashSet<Tuple<Guid, Guid>>(
                bookedRooms.Entities.Select(b =>
                    Tuple.Create(
                        b.GetAttributeValue<EntityReference>("kpmg_room").Id,
                        b.GetAttributeValue<EntityReference>("kpmg_predefinedtimeslots").Id))
            );

            // Step 5: Determine available rooms (where at least one associated time slot is not booked)
            var availableRooms = new List<Entity>();

            foreach (var room in allRooms.Entities)
            {
                bool isRoomAvailable = false;

                // Check each time slot for the room
                foreach (var timeSlot in allTimeSlots.Entities)
                {
                    var timeSlotId = timeSlot.Id;

                    // If at least one time slot is not booked, mark the room as available
                    if (!bookedRoomTimeSlots.Contains(Tuple.Create(room.Id, timeSlotId)))
                    {
                        isRoomAvailable = true;
                        break; // Break as soon as an available time slot is found
                    }
                }

                if (isRoomAvailable)
                {
                    availableRooms.Add(room); // Add to available rooms if any time slot is free
                }
            }

            // Output available rooms
            if (availableRooms.Any())
            {
                Console.WriteLine("Available Rooms (with at least one time slot not booked):");
                foreach (var room in availableRooms)
                {
                    string roomName = room.GetAttributeValue<string>("name");
                    Console.WriteLine($"Room: {roomName}, Room ID: {room.Id}");
                }
            }
            else
            {
                Console.WriteLine("No available rooms with unbooked time slots for the specified date.");
            }
        }
    }
}

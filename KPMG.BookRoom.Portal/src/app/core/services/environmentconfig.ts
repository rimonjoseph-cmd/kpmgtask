let mainUrl = "https://localhost:7280/api/";
export const  links = {
    "getallbuilding" : mainUrl + "Building",
    "createbuilding" : mainUrl + "Building",
    "contact": {
        "registernew" : mainUrl + "contact",
        "login" : mainUrl + "contact"+ "/login"
    },
    "bookrooms": {
        "mybookroooms" : mainUrl + "book/own",
        "createbook" : mainUrl + "book"
    },
    "rooms": {
        "availableRooms" : mainUrl + "room/getavailable"
    },
    "timeslots": {
        "getall" : mainUrl + "TimeSlot"
    }
};
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { RoomService } from 'src/app/core/services/room/room.service';
import { RoomModel } from 'src/app/models/rooms.model';
import { timeslot } from 'src/app/models/timeslot.model';

// booking.interface.ts
export interface Booking {
  title: string;
  roomid: string;
  fromid: string;
  toid: string;
  bookedDate: string;
  convertedutcbookeddate: Date;
  contactid: string;
}
@Component({
  selector: 'app-bookroomview',
  templateUrl: './bookroomview.component.html',
  styleUrls: ['./bookroomview.component.css']
})
export class BookroomviewComponent implements OnInit {

  selectedDateTime: string;
  showToId: boolean = false;
  isLoader: boolean = false;
  roomModels: RoomModel[] = [];
  timeslotsModel : timeslot[] = [];
  timeslotsModelTO : timeslot[] = [];
  constructor(private roomService : RoomService,private router : Router) {
    this.bookingData = {
      title: '',
      roomid: '',
      fromid: '',
      toid: '',
      bookedDate: '',
      convertedutcbookeddate: new Date(),
      contactid: ''
    };
    this.selectedDateTime = this.getCurrentDateTime();
    this.loadtimeslots();

  }
  ngOnInit(){
    this.loadtimeslots();
  }
  loadtimeslots(){
    this.roomService.getAllTimeSlots().subscribe((response:any) => {
      if(response.result){
        debugger;
        this.timeslotsModel = response.data;
      }
    })
  }
  onsubmit() {
    this.roomService.createBookRoom(this.bookingData).subscribe((response:any) => {
      if(response.result){
        this.router.navigate(['mybooks']);
      }
    })
  
  }
  checkFromId() {
    debugger;
    if (this.bookingData.fromid) {
      this.showToId = true;
      // Filter the timeslotsModel to find the slot with the selected fromid
    let fromChooseTimeSlot: any = this.timeslotsModel.find(slot => slot.timeslotid === this.bookingData.fromid);
      this.timeslotsModelTO = this.timeslotsModel.filter(slot => slot.timeid > fromChooseTimeSlot.timeid);
      debugger;
    } else {
      this.showToId = false;
    }
  }
  public bookingData: Booking;
 
  onBookedDateChange() {
    debugger;
    const date = new Date(new Date(this.selectedDateTime)); // Get the current date and time

// Format the date without the GMT offset
const dateStringWithoutGMT = date.toISOString().split('T')[0] + ' ' + date.toTimeString().split(' ')[0];

// Get the GMT offset in +/-HHMM format
const timeZoneOffset = date.getTimezoneOffset();
const offsetSign = timeZoneOffset > 0 ? '-' : '+';
const offsetHours = Math.floor(Math.abs(timeZoneOffset) / 60);
const offsetMinutes = Math.abs(timeZoneOffset) % 60;
const gmtOffset = `${offsetSign}${offsetHours.toString().padStart(2, '0')}${offsetMinutes.toString().padStart(2, '0')}`;

// Send the date string without GMT and the GMT offset to the server
// You would typically use a HTTP client library like Axios or Angular's HttpClient for this
console.log('Date without GMT:', dateStringWithoutGMT);
console.log('GMT offset:', gmtOffset);
debugger;

    debugger;
    this.isLoader = true;
    this.roomService.getAllAvailableRooms(dateStringWithoutGMT).subscribe((response :any) => {
    this.isLoader = false;
      if(response.result){
        debugger;
        this.roomModels = response.data;
      }
    });
  }
  
  getCurrentDateTime(): string {
    const now = new Date();
    const year = now.getFullYear();
    let month = now.getMonth() + 1;
    let day = now.getDate();
    let hours = now.getHours();
    let minutes = now.getMinutes();

    // Add leading zeroes if needed
    const formattedMonth = month < 10 ? '0' + month : month;
    const formattedDay = day < 10 ? '0' + day : day;
    const formattedHours = hours < 10 ? '0' + hours : hours;
    const formattedMinutes = minutes < 10 ? '0' + minutes : minutes;

    return `${year}-${formattedMonth}-${formattedDay}`;//T${formattedHours}:${formattedMinutes}`;
  }
}

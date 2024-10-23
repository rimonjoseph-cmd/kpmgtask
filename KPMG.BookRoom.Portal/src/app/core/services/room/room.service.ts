import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { links } from '../environmentconfig';
import { Booking } from 'src/app/pages/bookroom/bookroomview/bookroomview.component';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  createBookRoom(bookingData: Booking) {
    return this.http.post(links.bookrooms.createbook,bookingData);
  }

  constructor(private http: HttpClient) { }
  
  getAllAvailableRooms(bookedDate : string){
    debugger;
    return this.http.get(links.rooms.availableRooms+'?bookedDate=' +bookedDate);
  }
  getAllTimeSlots (){
    return this.http.get(links.timeslots.getall);
  }
}

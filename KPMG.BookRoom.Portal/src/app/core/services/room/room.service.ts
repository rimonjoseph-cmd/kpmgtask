import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { links } from '../environmentconfig';
import { Booking } from 'src/app/pages/bookroom/bookroomview/bookroomview.component';
import { RoomModel } from 'src/app/models/rooms.model';

@Injectable({
  providedIn: 'root'
})
export class RoomService {
  getRoom(id: string) {
    return this.http.get(links.rooms.getRoom + '?id=' +id);
  }
  createroom(createUpdateRoomModel: RoomModel) {
    return this.http.post(links.rooms.createRoom,createUpdateRoomModel);
  }
  getAllRooms() {
    return this.http.get(links.rooms.allRooms);
  }
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

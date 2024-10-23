import { Component, OnInit } from '@angular/core';
import { RoomService } from 'src/app/core/services/room/room.service';
import { RoomModel } from 'src/app/models/rooms.model';


@Component({
  selector: 'app-available-rooms',
  templateUrl: './available-rooms.component.html',
  styleUrls: ['./available-rooms.component.css']
})
export class AvailableRoomsComponent implements OnInit {
  selectedDateTime: string;
  isLoader: boolean = false;
  availableRooms: RoomModel[] = [];
  constructor(private roomService : RoomService) {
    this.selectedDateTime = this.getCurrentDateTime();
  }
  ngOnInit(): void {
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

    return `${year}-${formattedMonth}-${formattedDay}T${formattedHours}:${formattedMinutes}`;
  }
  onsubmit(){
    debugger;
    this.isLoader = true;
    this.roomService.getAllAvailableRooms(this.selectedDateTime).subscribe((response :any) => {
    this.isLoader = false;
      if(response.result){
        debugger;
        this.availableRooms = response.data;
      }
    });
    
  }
}

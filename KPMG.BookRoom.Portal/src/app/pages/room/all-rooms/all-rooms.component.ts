import { Component, OnInit } from '@angular/core';
import { RoomModel } from 'src/app/models/rooms.model';

@Component({
  selector: 'app-all-rooms',
  templateUrl: './all-rooms.component.html',
  styleUrls: ['./all-rooms.component.css']
})
export class AllRoomsComponent implements OnInit{

  isLoader: boolean = false;
  allRooms: RoomModel[] = [];

  ngOnInit(): void {
  }

}

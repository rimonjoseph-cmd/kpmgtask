import { Component, OnInit } from '@angular/core';
import { RoomService } from 'src/app/core/services/room/room.service';
import { RoomModel } from 'src/app/models/rooms.model';

@Component({
  selector: 'app-all-rooms',
  templateUrl: './all-rooms.component.html',
  styleUrls: ['./all-rooms.component.css']
})
export class AllRoomsComponent implements OnInit{

  isLoader: boolean = false;
  allRooms: RoomModel[] = [];
  createUpdateRoomModel : RoomModel = {
    id: '',
    name: '',
    code: '',
    isactive: false,
    building: {
      Id: '',
      name: '',
      code: '',
      isactive: false,
      isblocked: false
    }
  }
  constructor(private roomService : RoomService){
  }
  ngOnInit(): void {
    this.loadRooms();
   
  }
  loadRooms(){
  this.isLoader = true;
    this.roomService.getAllRooms().subscribe((response: any) => {
      this.isLoader =false;
      if(response.result){
        this.allRooms = response.data;
      }
    })
  }
  createRoom(){
    debugger;
    this.isLoader = true;
    this.roomService.createroom(this.createUpdateRoomModel).subscribe((response: any)=>{
      debugger;
      if(response.result){
        this.loadRooms();
      }
    })
  }
  editBuilding(id:string){
    this.isLoader = true;
    this.roomService.getRoom(id).subscribe((response : any) => {
      if(response.result){
        this.isLoader = false;
        this.createUpdateRoomModel = response.data;
      }else{
        alert(response.message);
      }
    })
  }

}

import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { BuildingService } from 'src/app/core/services/building/building.service';
import { RoomService } from 'src/app/core/services/room/room.service';
import { BuildingModel } from 'src/app/models/building.model';
import { RoomModel } from 'src/app/models/rooms.model';

interface RoomCreateModel {
    id:string;
    name:string;
    code:string;
    isactive: boolean;
    buildingid :string;
}
@Component({
  selector: 'app-all-rooms',
  templateUrl: './all-rooms.component.html',
  styleUrls: ['./all-rooms.component.css']
})
export class AllRoomsComponent implements OnInit{

  isLoader: boolean = false;
  allRooms: RoomModel[] = [];
  createUpdateRoomModel : RoomCreateModel = {
    id: '',
    name: '',
    code: '',
    isactive: false,
    buildingid:''
  }
  builings : BuildingModel[] = []
  constructor(private roomService : RoomService,private buildingService : BuildingService){
  }
  ngOnInit(): void {
    this.loadRooms();
    debugger;
    this.buildingService.getAllBuildings().subscribe((response: any) => {
      debugger;
      if(response.result){
        this.builings = response.data;
      }
    });
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
  resetForm(form: NgForm) {
    form.resetForm();
}

}

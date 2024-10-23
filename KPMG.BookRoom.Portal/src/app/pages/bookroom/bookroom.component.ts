import { Component, OnInit } from '@angular/core';
import { BookroomServiceService } from 'src/app/core/services/bookroom/bookroom-service.service';

interface roomModel{
  id: string,
  name: string,
  code: string,
  isactive: boolean
}
interface BookRoomModel{
  id: string,
  name: string,
  bookedDate : Date ,
  from: string,
  to : string,
  room: roomModel
}
@Component({
  selector: 'app-bookroom',
  templateUrl: './bookroom.component.html',
  styleUrls: ['./bookroom.component.css']
})
export class BookroomComponent implements OnInit {
  constructor(private bookroomService : BookroomServiceService){
  }
  myBookroomsList: any[] = [];
  mybookrooms :BookRoomModel =  {
    id: '',
    name: '',
    from: '',
    to: '',
    bookedDate: new Date(),
    room: {
      code: '',
      name: "",
      id: "",
      isactive: false
    }
  };
  isLoader: boolean = false;

  ngOnInit(): void {
    this.loadmyBuildings();
  }
  loadmyBuildings(){
    this.isLoader = true;
    this.bookroomService.getAllmybookrooms().subscribe((response:any) => {
    this.isLoader = false;
      if(response.result){
        this.myBookroomsList = response.data;
      }
    })
  }
}

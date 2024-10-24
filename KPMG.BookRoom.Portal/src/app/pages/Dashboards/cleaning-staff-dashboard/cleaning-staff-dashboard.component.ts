import { Component, OnInit } from '@angular/core';
import { BookroomServiceService } from 'src/app/core/services/bookroom/bookroom-service.service';
import { BookRoomModel } from 'src/app/models/bookroom.model';

@Component({
  selector: 'app-cleaning-staff-dashboard',
  templateUrl: './cleaning-staff-dashboard.component.html',
  styleUrls: ['./cleaning-staff-dashboard.component.css']
})
export class CleaningStaffDashboardComponent implements OnInit{
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
    this.loadallbooking();
  }
  loadallbooking(){
    this.isLoader = true;
    this.bookroomService.getAllbookrooms().subscribe((response:any) => {
    this.isLoader = false;
      if(response.result){
        this.myBookroomsList = response.data;
      }
    })
  }
  

}

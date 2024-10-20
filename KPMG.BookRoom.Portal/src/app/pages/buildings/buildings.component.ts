import { Component, OnInit } from '@angular/core';
import { BuildingService } from 'src/app/core/services/building/building.service';

interface buildingModel{
  id: string,
  name: string,
  code: string,
  isactive: boolean
}
@Component({
  selector: 'app-buildings',
  templateUrl: './buildings.component.html',
  styleUrls: ['./buildings.component.css']
})
export class BuildingsComponent  implements OnInit{
  buildingsList: any[] = [];
  createBuidlingobj :buildingModel =  {
    id: '',
    name: '',
    code: '',
    isactive: false
  };
  isLoader: boolean = false;
  constructor(private buildingService : BuildingService){
  }
  ngOnInit(): void {
    this.loadBuildings();
  }
  loadBuildings(){
    this.isLoader = true;
    this.buildingService.getAllBuildings().subscribe((response: any) => {
      this.isLoader =false;
      this.buildingsList = response.data;
    });
  }
  createBuilding(){
    debugger;
    this.isLoader = true;
    this.buildingService.createBuilding(this.createBuidlingobj).subscribe((response: any)=>{
      debugger;
      if(response.result){
      this.isLoader =false;
        this.loadBuildings();
      }
    })
  }
  editBuilding(id:string){
    this.isLoader = true;
    this.buildingService.getBuilding(id).subscribe((response : any) => {
      if(response.result){
        this.isLoader = false;
        this.createBuidlingobj = response.data;
      }else{
        alert(response.message);
      }
    })
  }
  updateBuilding(){
    this.buildingService.updateBuilding(this.createBuidlingobj).subscribe((response:any)=> {
      if(response.result){
        this.createBuidlingobj = response.data;
        this.loadBuildings();
      }else{
        alert(response.message);
      }
    })
  }
}

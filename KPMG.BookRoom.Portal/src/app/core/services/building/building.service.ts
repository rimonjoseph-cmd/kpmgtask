import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// file2.ts
import { links } from '../environmentconfig';
@Injectable({
  providedIn: 'root'
})
export class BuildingService {
  constructor(private http: HttpClient) { }
  updateBuilding(createBuidlingobj: any) {
    return this.http.put(links.createbuilding +"/" + createBuidlingobj.id,createBuidlingobj);
  }
  getBuilding(id: string) {
    return this.http.get(links.getallbuilding+"/" +id);
  }


  getAllBuildings(){
    return this.http.get(links.getallbuilding);
  }
  createBuilding(obj:any){
    return this.http.post(links.createbuilding,obj);
  }
}

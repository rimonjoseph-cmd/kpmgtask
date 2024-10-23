import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { links } from '../environmentconfig';

@Injectable({
  providedIn: 'root'
})
export class BookroomServiceService {

  constructor(private http: HttpClient) { }

  getAllmybookrooms(){
    return this.http.get(links.bookrooms.mybookroooms);
  }
}

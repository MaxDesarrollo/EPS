import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Eps } from '../models/eps';

@Injectable({
  providedIn: 'root'
})
export class EpsService {

  urlApp = 'https://localhost:44381/';
  urlApi = 'api/persona/'
  constructor(private http:HttpClient) { }


  obtener() : Observable<Eps>{
    return this.http.get<Eps>(this.urlApp + this.urlApi);
  }

}

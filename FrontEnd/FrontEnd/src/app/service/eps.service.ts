import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Api_Response } from '../models/api_response';
import { Eps } from '../models/eps';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EpsService {

  urlApp = environment.urlApp;
  urlApi = 'api/eps/';
  listEps : Eps[];
  constructor(private http:HttpClient) { }



  obtenerEps(){
    return  this.http.get<Api_Response>(this.urlApp + this.urlApi).toPromise()
    .then(data => {
      this.listEps = data.response as Eps[]
      console.log(this.listEps);
    });
  }

}

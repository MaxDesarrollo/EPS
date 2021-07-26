import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, pipe } from 'rxjs';
import { map } from 'rxjs/operators'
import { Api_Response } from '../models/api_response';
import { Persona } from '../models/persona';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  urlApp = environment.urlApp;
  urlApi = "api/persona/";
  listPersonas: Persona[];
  constructor(private http:HttpClient) { }

  guardar(persona: Persona ) : Observable<Persona>{
    return this.http.post<Persona>(this.urlApp + this.urlApi, persona)

  }

  eliminarPersona(id : string|undefined) : Observable<Persona>{

    return this.http.delete<Persona>(this.urlApp + this.urlApi + id);
  }

  obtenerPersonas(){
   return  this.http.get<Api_Response>(this.urlApp + this.urlApi).toPromise()
   .then(data => {
     this.listPersonas = data.response as Persona[]
   });



  }



}

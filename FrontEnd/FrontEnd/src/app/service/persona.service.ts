import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Persona } from '../models/persona';

@Injectable({
  providedIn: 'root'
})
export class PersonaService {

  urlApp = 'https://localhost:44381/';
  urlApi = 'api/persona/'
  constructor(private http:HttpClient) { }

  guardar(persona: Persona ) : Observable<Persona>{
    return this.http.post<Persona>(this.urlApp + this.urlApi, persona)

  }
}

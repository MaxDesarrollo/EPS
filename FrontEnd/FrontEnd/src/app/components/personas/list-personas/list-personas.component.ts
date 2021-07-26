import { Component, OnInit } from '@angular/core';
import { PersonaService } from 'src/app/service/persona.service';
import { Persona } from 'src/app/models/persona';
import { ToastrService } from 'ngx-toastr';
import { Api_Response } from 'src/app/models/api_response';

@Component({
  selector: 'app-list-personas',
  templateUrl: './list-personas.component.html',
  styleUrls: ['./list-personas.component.css']
})
export class ListPersonasComponent implements OnInit {

  personasList :Persona[];
  constructor(public personaService : PersonaService, public toastr: ToastrService) {

    this.mapeoPersonas();
  }

  ngOnInit(): void {



  }

  mapeoPersonas(){
     var response =  this.personaService.obtenerPersonas() as Api_Response ;
     this.personasList = response.response;

  }

  eliminarPersona(id: string|undefined){
    if(confirm('Esta seguro que desea elminiar el registro?')){
      this.personaService.eliminarPersona(id).subscribe(data => {
        this.toastr.warning("Registro Eliminado", 'Persona elminada correctamente')
        this.personaService.obtenerPersonas();

      })
    }
  }

  editar(persona:any){
    this.personaService.actualizar(persona);
  }

}

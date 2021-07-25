import { Component, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms'

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent implements OnInit {
  form: FormGroup;
  constructor(private formBuilder: FormBuilder) {
    this.form = this.formBuilder.group({
      id:0,
      primer_nombre:['',[Validators.required]],
      segundo_nombre:[''],
      primer_apellido:['',[Validators.required]],
      segundo_apellido:[''],
      estado_civil:['',Validators.required],
      sexo:['',Validators.required],
      numero_identificacion:['',Validators.required],
      tipo_identificacion:['',Validators.required],
      fecha_expedicion:['',Validators.required],
      entidad:['',Validators.required],
      fecha_afiliacion:['',Validators.required]



    })
   }

  ngOnInit(): void {
  }

}

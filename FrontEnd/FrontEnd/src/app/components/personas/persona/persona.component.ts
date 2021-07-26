import { Component, OnDestroy, OnInit } from '@angular/core';
import {FormGroup, FormBuilder, Validators} from '@angular/forms'
import { ToastrService } from 'ngx-toastr';
import { Subscription } from 'rxjs';
import { Api_Response } from 'src/app/models/api_response';

import { Core_Eps } from 'src/app/models/core_eps';
import { Identificacion } from 'src/app/models/identificacion';
import { Persona } from 'src/app/models/persona';

import { PersonaService } from 'src/app/service/persona.service';

@Component({
  selector: 'app-persona',
  templateUrl: './persona.component.html',
  styleUrls: ['./persona.component.css']
})
export class PersonaComponent implements OnInit, OnDestroy {
  form: FormGroup;
  suscription : Subscription;
  persona : Persona;
  idPersona? : string;

  constructor(private formBuilder: FormBuilder, private personaService: PersonaService,private toastr: ToastrService ) {
    this.form = this.formBuilder.group({

      primer_nombre:['',[Validators.required]],
      segundo_nombre:[''],
      primer_apellido:['',[Validators.required]],
      segundo_apellido:[''],
      estado_civil:['',Validators.required],
      sexo:['',Validators.required],
      numero_identificacion:['',[Validators.required, Validators.maxLength(9), Validators.minLength(9)]],
      tipo_identificacion:['',Validators.required],
      fecha_expedicion:['',Validators.required],
      lugar_expedicion:['',Validators.required],
      entidad:['',Validators.required],
      fecha_afiliacion:['',Validators.required],
      correo:['',[Validators.required, Validators.email]],
      codigo_interno:['',[Validators.required, Validators.maxLength(12), Validators.minLength(12)]],
      fecha_nacimiento:['', Validators.required]



    })
   }

  ngOnInit(): void {
    this.personaService.obtenerPersona$().subscribe(data => {
      this.persona = data;
      this.form.patchValue({
        primer_nombre: this.persona.primer_Nombre,
        segundo_nombre: this.persona.segundo_Nombre,
        primer_apellido: this.persona.primer_Apellido,
        segundo_apellido: this.persona.segundo_Apellido,
        codigo_interno: this.persona.codigo_Interno,
        estado_civil: this.persona.estado_Civil,
        sexo: this.persona.sexo,
        fecha_nacimiento: this.persona.fecha_Nacimiento,
        numero_identificacion: this.persona.identificacion?.numero,
        tipo_identificacion: this.persona.identificacion?.tipo,
        fecha_expedicion: this.persona.identificacion?.fecha_expedicion,
        lugar_expedicion: this.persona.identificacion?.lugar_expedicion
      })
      this.idPersona = this.persona.id;
    })
  }

  ngOnDestroy(){
    this.suscription.unsubscribe();
  }

  guardar(){

    console.log(this.idPersona);
    if(this.idPersona === undefined){
        this.agregar();
    }
    else{
        this.editar();
    }

  }


  agregar(){
    const identificacion : Identificacion = {
      numero : this.form.get('numero_identificacion')?.value,
      tipo: this.form.get('tipo_identificacion')?.value,
      fecha_expedicion : this.form.get('fecha_expedicion')?.value,
     lugar_expedicion: this.form.get('lugar_expedicion')?.value
    }

    const core_eps : Core_Eps = {

      entidad : this.form.get ('entidad')?.value,
      fecha_ingreso : this.form.get('fecha_afiliacion')?.value,
      estado_afiliacion : 'activo'

    }

    const persona : Persona = {
      schema_version : "1",
      document_version:"1",
      codigo_Interno : this.form.get('codigo_interno')?.value,
      primer_Nombre : this.form.get('primer_nombre')?.value,
      segundo_Nombre: this.form.get('segundo_nombre')?.value,
      primer_Apellido : this.form.get('primer_apellido')?.value,
      segundo_Apellido : this.form.get('segundo_apellido')?.value,
      estado_Civil: this.form.get('estado_civil')?.value,
      sexo: this.form.get('sexo')?.value,
      fecha_Nacimiento: this.form.get('fecha_nacimiento')?.value,
      correo: this.form.get('correo')?.value,
      identificacion: identificacion,
      core_eps : core_eps,
    }

    this.personaService.guardar(persona).subscribe(data => {
      console.log(data)
      console.log(typeof(data))
      this.toastr.success('Registro agregado', 'Persona Agregada')
      this.personaService.obtenerPersonas();
      this.form.reset();
    })

  }


  editar(){

    const identificacion : Identificacion = {
      numero : this.form.get('numero_identificacion')?.value,
      tipo: this.form.get('tipo_identificacion')?.value,
      fecha_expedicion : this.form.get('fecha_expedicion')?.value,
     lugar_expedicion: this.form.get('lugar_expedicion')?.value
    }

    const core_eps : Core_Eps = {

      entidad : this.form.get ('entidad')?.value,
      fecha_ingreso : this.form.get('fecha_afiliacion')?.value,
      estado_afiliacion : 'activo'

    }

    const persona : Persona = {
      id: this.persona.id,
      schema_version: this.persona.schema_version,
      document_version: this.persona.document_version,
      codigo_Interno : this.form.get('codigo_interno')?.value,
      primer_Nombre : this.form.get('primer_nombre')?.value,
      segundo_Nombre: this.form.get('segundo_nombre')?.value,
      primer_Apellido : this.form.get('primer_apellido')?.value,
      segundo_Apellido : this.form.get('segundo_apellido')?.value,
      estado_Civil: this.form.get('estado_civil')?.value,
      sexo: this.form.get('sexo')?.value,
      fecha_Nacimiento: this.form.get('fecha_nacimiento')?.value,
      correo: this.form.get('correo')?.value,
      identificacion: identificacion,
      core_eps : core_eps,
    }

    this.personaService.actualizarPersona(this.idPersona,persona).subscribe(data => {
        this.toastr.info('Registro Actualizado', 'Persona actualizada correctamente');
        this.personaService.obtenerPersonas();
        this.form.reset();
    })

  }


}



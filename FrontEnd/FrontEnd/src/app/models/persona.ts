import { Core_Eps } from "./core_eps";
import { Identificacion } from "./identificacion";

export class Persona{
    id: string;
    codigo_interno: string;
    primer_nombre: string;
    segundo_nombre: string;
    primer_apellido:string;
    segundo_apellido:string;
    estado_civil:string;
    sexo:string;
    fecha_nacimiento:Date;
    correo: string;
    identificacion : Identificacion;
    core_eps : Core_Eps;

  constructor(
    id: string,
    codigo_interno: string,
    primer_nombre: string,
    segundo_nombre: string,
    primer_apellido: string,
    segundo_apellido: string,
    estado_civil: string,
    sexo: string,
    fecha_nacimiento: Date,
    correo: string,
    identificacion: Identificacion,
    core_eps: Core_Eps
) {
    this.id = id
    this.codigo_interno = codigo_interno
    this.primer_nombre = primer_nombre
    this.segundo_nombre = segundo_nombre
    this.primer_apellido = primer_apellido
    this.segundo_apellido = segundo_apellido
    this.estado_civil = estado_civil
    this.sexo = sexo
    this.fecha_nacimiento = fecha_nacimiento
    this.correo = correo
    this.identificacion = identificacion
    this.core_eps = core_eps
  }

}

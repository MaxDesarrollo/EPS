import { Core_Eps } from "./core_eps";
import { Identificacion } from "./identificacion";

export class Persona{
    id?: string | undefined;
    codigo_Interno: string;
    primer_Nombre: string;
    segundo_Nombre: string;
    primer_Apellido:string;
    segundo_Apellido:string;
    estado_Civil:string;
    sexo:string;
    fecha_Nacimiento:Date;
    correo: string;
    identificacion? : Identificacion;
    core_eps? : Core_Eps;



}

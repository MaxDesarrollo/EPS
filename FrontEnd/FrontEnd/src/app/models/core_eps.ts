export class Core_Eps{
  id: string;
  entidad:string;
  fecha_ingreso:Date;
  estado_afiliacion:string;


  constructor(
    id: string,
    entidad: string,
    fecha_ingreso: Date,
    estado_afiliacion: string
) {
    this.id = id
    this.entidad = entidad
    this.fecha_ingreso = fecha_ingreso
    this.estado_afiliacion = estado_afiliacion
  }

}

export class Identificacion{
  numero: string;
  fecha_expedicion: string;
  lugar_expedicion: string;
  tipo: string;


  constructor(
    numero: string,
    fecha_expedicion: string,
    lugar_expedicion: string,
    tipo: string
) {
    this.numero = numero
    this.fecha_expedicion = fecha_expedicion
    this.lugar_expedicion = lugar_expedicion
    this.tipo = tipo
  }

}

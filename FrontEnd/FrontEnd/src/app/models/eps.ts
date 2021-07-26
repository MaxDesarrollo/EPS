export class Eps{
    id : string;
    codigo : string;
    entidad : string;
    nit: string;
    regimen_codigo:string;
    regimen_descripcion:string;

  constructor(
    id: string,
    codigo: string,
    entidad: string,
    nit: string,
    regimen_codigo: string,
    regimen_descripcion: string
) {
    this.id = id
    this.codigo = codigo
    this.entidad = entidad
    this.nit = nit
    this.regimen_codigo = regimen_codigo
    this.regimen_descripcion = regimen_descripcion
  }

}

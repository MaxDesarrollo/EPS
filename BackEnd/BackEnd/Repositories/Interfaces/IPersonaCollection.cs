using BackEnd.Models;
using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Interfaces
{
    public interface IPersonaCollection: IGenericCollection<Persona,string>
    {

    }
}

using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories
{
    public class RutasMedicasDBRepository
    {
        public MongoClient client;

        public IMongoDatabase db;

        public RutasMedicasDBRepository()
        {
            client = new MongoClient("mongodb+srv://max_admin:Mememe555@cluster0.e9aje.mongodb.net/rutas_medicas?retryWrites=true&w=majority");
            db = client.GetDatabase("rutas_medicas");
        }

    }
}

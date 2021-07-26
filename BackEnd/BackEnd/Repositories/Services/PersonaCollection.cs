using BackEnd.Models;
using BackEnd.Repositories.Helpers;
using BackEnd.Repositories.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Services
{
    public class PersonaCollection : IPersonaCollection
    {
        internal RutasMedicasDBRepository _repository = new RutasMedicasDBRepository();
        private IMongoCollection<Persona> Collection;
        private EpsCollection epsCollection = new EpsCollection();

        public PersonaCollection()
        {
            Collection = _repository.db.GetCollection<Persona>("persona");
        }

        public async Task<HttpResponserWrapper<bool>> Delete(string id)
        {
            try
            {
                var filter = FilterPersonaById(id);
                await Collection.DeleteOneAsync(filter);
                return new HttpResponserWrapper<bool>(true, false, "Eliminado Correctamente...");
            }
            catch (MongoWriteException ex)
            {
                return new HttpResponserWrapper<bool>(false, true, ex.WriteError.ToString());
             
            }
            

            
        }

        public async Task<HttpResponserWrapper<Persona>> GetById(string id)
        {
            try
            {

                var persona = await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id.ToString()) } }).Result.FirstOrDefaultAsync();
                return new HttpResponserWrapper<Persona>(persona, false, "");
            }
            catch (MongoWriteException ex)
            {
                var persona = new Persona();
                return new HttpResponserWrapper<Persona>(persona, true, ex.WriteError.ToString());
             
            }
        }

        public async Task<HttpResponserWrapper<Persona>> Insert(Persona model)
        {
            try
            {
                var eps = await GetEps(model.Core_Eps.Id);
                model.Core_Eps.Entidad = eps.Entidad;
                await Collection.InsertOneAsync(model);
                var response =  new HttpResponserWrapper<Persona>(model, false, "Registro Guardado Exitosamente...");

                return response;

            }
            catch (MongoWriteException ex)
            {
                return new HttpResponserWrapper<Persona>(model, true, ex.WriteError.ToString());
              
            }
        }

        public Task<HttpResponserWrapper<Persona>> Save(Persona model)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponserWrapper<List<Persona>>> ToList()
        {
            try
            {
                var personas = await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
                return new HttpResponserWrapper<List<Persona>>(personas, false, "");
            }
            catch (MongoWriteException ex)
            {
                var personas = new List<Persona>();
                return new HttpResponserWrapper<List<Persona>>(personas, true, ex.WriteError.ToString());
             
            }
        }

        public async Task<HttpResponserWrapper<Persona>> Update(Persona model)
        {
            try
            {
                var countDocumentVersion = int.Parse(model.Document_version) + 1;
                var filter = FilterPersonaById(model.Id.ToString());
                model.Schema_version = 1.ToString();
                model.Document_version = countDocumentVersion.ToString();
                await Collection.ReplaceOneAsync(filter,model);
                return new HttpResponserWrapper<Persona>(model, false, "Registo Actualizado Exitosamente...");
            }
            catch (MongoWriteException ex)
            {
                return new HttpResponserWrapper<Persona>(model, true, ex.WriteError.ToString());
               
            }
           
        }


        private FilterDefinition<Persona> FilterPersonaById(string id)
        {
            return  Builders<Persona>.Filter.Eq(s => s.Id, id);
        }


        private async Task<Eps> GetEps(string id)
        {
            return await epsCollection.GetEpsByID(id);
        }



    }
}

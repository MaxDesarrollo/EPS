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

        public PersonaCollection()
        {
            Collection = _repository.db.GetCollection<Persona>("persona");
        }

        public async Task<HttpResponserWrapper<bool>> Delete(Persona model)
        {
            try
            {
                var filter = Builders<Persona>.Filter.Eq(s => s.Id, new ObjectId(model.Id.ToString()));
                await Collection.DeleteOneAsync(filter);
                return new HttpResponserWrapper<bool>(true, false, "Eliminado Correctamente...");
            }
            catch (MongoWriteException ex)
            {
                return new HttpResponserWrapper<bool>(false, true, ex.WriteError.ToString());
                throw;
            }
            

            
        }

        public async Task<HttpResponserWrapper<Persona>> GetById(string id)
        {
            try
            {
                var persona = await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
                return new HttpResponserWrapper<Persona>(persona, false, "");
            }
            catch (MongoWriteException ex)
            {
                var persona = new Persona();
                return new HttpResponserWrapper<Persona>(persona, true, ex.WriteError.ToString());
                throw;
            }
        }

        public async Task<HttpResponserWrapper<Persona>> Insert(Persona model)
        {
            try
            {
                await Collection.InsertOneAsync(model);
                return new HttpResponserWrapper<Persona>(model, false, "Registro Guardado Exitosamente...");

            }
            catch (MongoWriteException ex)
            {
                return new HttpResponserWrapper<Persona>(model, true, ex.WriteError.ToString());
                throw;
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
                throw;
            }
        }

        public async Task<HttpResponserWrapper<Persona>> Update(Persona model)
        {
            try
            {
                var filter = Builders<Persona>.Filter.Eq(s => s.Id, new ObjectId(model.Id.ToString()));
                await Collection.ReplaceOneAsync(s => s.Id == model.Id, model);
                return new HttpResponserWrapper<Persona>(model, false, "Registo Actualizado Exitosamente...");
            }
            catch (MongoWriteException ex)
            {
                return new HttpResponserWrapper<Persona>(model, true, ex.WriteError.ToString());
                throw;
            }
            throw new NotImplementedException();
        }
    }
}

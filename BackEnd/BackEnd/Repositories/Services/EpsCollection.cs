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
    public class EpsCollection : IEpsCollection
    {
        internal RutasMedicasDBRepository _repository = new RutasMedicasDBRepository();
        private IMongoCollection<Eps> Collection;


        public EpsCollection()
        {
            Collection = _repository.db.GetCollection<Eps>("eps");
        }

        public Task<HttpResponserWrapper<bool>> Delete(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponserWrapper<Eps>> GetById(string id)
        {
            try
            {
                var eps = await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();
                return new HttpResponserWrapper<Eps>(eps, false, "");
            }
            catch (MongoWriteException ex)
            {
                var eps = new Eps();
                return new HttpResponserWrapper<Eps>(eps, true, ex.WriteError.ToString());
              
            }
        }

        public async Task<Eps> GetEpsByID(string id)
        {
            try
            {
                return await Collection.FindAsync(new BsonDocument { { "_id", new ObjectId(id) } }).Result.FirstOrDefaultAsync();

            }catch(MongoWriteException ex)
            {
                return null;
            }
        }

        public Task<HttpResponserWrapper<Eps>> Insert(Eps model)
        {
            throw new NotImplementedException();
        }

        public Task<HttpResponserWrapper<Eps>> Save(Eps model)
        {
            throw new NotImplementedException();
        }

        public async Task<HttpResponserWrapper<List<Eps>>> ToList()
        {
            try
            {
                var personas = await Collection.FindAsync(new BsonDocument()).Result.ToListAsync();
                return new HttpResponserWrapper<List<Eps>>(personas, false, "");
            }
            catch (MongoWriteException ex)
            {
                var eps = new List<Eps>();
                return new HttpResponserWrapper<List<Eps>>(eps, true, ex.WriteError.ToString());
              
            }
        }

        public Task<HttpResponserWrapper<Eps>> Update(Eps model)
        {
            throw new NotImplementedException();
        }
    }
}

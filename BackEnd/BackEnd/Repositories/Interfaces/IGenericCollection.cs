using BackEnd.Repositories.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Interfaces
{
    public interface IGenericCollection<T,U>
    {

        Task<HttpResponserWrapper<T>> Insert(T model);
        Task<HttpResponserWrapper<T>> Update(T model);
        Task<HttpResponserWrapper<bool>> Delete(U id);
        Task<HttpResponserWrapper<T>> Save(T model);
        Task<HttpResponserWrapper<List<T>>> ToList();
        Task<HttpResponserWrapper<T>> GetById(U id);

    }
}

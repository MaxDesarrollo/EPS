using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace BackEnd.Repositories.Helpers
{
    public class HttpResponserWrapper<T>
    {
        public HttpResponserWrapper(T response, bool error, string message)
        {
            Error = error;
            Response = response;
            Message = message;
        }

        public bool Error { get; set; }
        public T Response { get; set; }
        public string Message { get; set; }

       
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Deadlock.Robinhood.Model
{
    public class Result<T>
    {
        public HttpStatusCode StatusCode { get; set; }       

        public T Data { get; set; }
    }
}

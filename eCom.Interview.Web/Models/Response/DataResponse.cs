using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace eCom.Interview.Web.Models.Response
{
    public class DataResponse<T>
    {
        public IQueryable<T> Result { get; set; }
        public int Count { get; set; }
    }
}

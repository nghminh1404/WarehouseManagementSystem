using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs
{
    public class ResponseData<T>
    {
        public List<T> Data { get; set; }
        public int Offset { get; set; }
        public int Limit { get; set; }
        public int Total { get; set; }
    }
}

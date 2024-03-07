using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;

namespace WM.Entity.DTOs.GoodsDTO
{
    public class GoodsFilterPaging
    {
        public double TotalPages { get; set; }

        public int PageSize { get; set; }

        public List<Models.Good> goods { get; set; }
    }
}




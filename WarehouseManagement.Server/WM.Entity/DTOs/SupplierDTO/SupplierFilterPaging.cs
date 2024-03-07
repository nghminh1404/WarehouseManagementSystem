using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;

namespace WM.Entity.DTOs.SupplierDTO
{
    public class SupplierFilterPaging
    {
        public double TotalPages { get; set; }

        public int PageSize { get; set; }

        public List<Models.Supplier> suppliers { get; set; }
    }
}

using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;

namespace WM.Entity.DTOs.StorageDTO
{
    public class StorageFilterPaging
    {
        public double TotalPages { get;set; }

        public int PageSize { get;set; }

        public List<Models.Storage> storages { get; set; }


    }
}

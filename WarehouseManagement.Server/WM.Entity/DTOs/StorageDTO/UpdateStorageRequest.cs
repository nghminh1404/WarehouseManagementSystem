using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.StorageDTO
{
    public class UpdateStorageRequest
    {
        public int StorageId { get; set; }
        public string? StorageName { get; set; }
        public string? StorageAddress { get; set; }
        public string? StoragePhone { get; set; }
    }
}

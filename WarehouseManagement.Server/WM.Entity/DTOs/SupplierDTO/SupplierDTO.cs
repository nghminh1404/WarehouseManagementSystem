using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;

namespace WM.Entity.DTOs.SupplierDTO
{
    public class SupplierDTO
    {
        public int SupplierId { get; set; }

        public string SupplierName { get; set; } = null!;

        public string SupplierPhone { get; set; } = null!;

        public string? SupplierEmail { get; set; }

        public string? Note { get; set; }

        public string  Status { get; set; } = null!;
    }
}

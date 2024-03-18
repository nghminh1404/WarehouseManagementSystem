using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.ExportOrderDTO
{
    public class ExportDetailDTO
    {
        //public int DetailId { get; set; }

        public int ExportId { get; set; }

        public float Price { get; set; }

        public int? GoodsId { get; set; }

        public int? Quantity { get; set; }

 

        
    }
}

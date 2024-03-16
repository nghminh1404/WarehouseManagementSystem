using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.ImportOrderDTO
{
    public class ImportDetailDTO
    {
        public int ImportId { get; set; }

        public float CostPrice { get; set; }

        public int DetailId { get; set; }

        public int? GoodsId { get; set; }

        public string? GoodsName { get; set; }

        public string? MeasureUnit { get; set; }

        public int? Quantity { get; set; }
    }
}

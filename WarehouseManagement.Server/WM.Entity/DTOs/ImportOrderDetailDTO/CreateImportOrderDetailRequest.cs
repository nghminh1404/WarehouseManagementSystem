﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.ImportOrderDetailDTO
{
    public class CreateImportOrderDetailRequest
    {
        public int ImportId { get; set; }

        public float CostPrice { get; set; }

        // public int DetailId { get; set; }

        public int? GoodsId { get; set; }

        public int? Quantity { get; set; }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.StorageDTO
{
    public class CreateStorageRequest
    {
        public string StorageName { get; set; }
        public string? StorageAddress { get; set; } = null;
    }
}

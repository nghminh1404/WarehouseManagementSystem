using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.CategoryDTO
{
    public class CategoryFilterPaging
    {
        public double TotalPages { get; set; }

        public int PageSize { get; set; }

        public List<Models.Category> category { get; set; }

    }
}

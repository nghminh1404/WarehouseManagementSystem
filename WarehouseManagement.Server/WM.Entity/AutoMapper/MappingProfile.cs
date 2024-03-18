using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs.ImportOrderDTO;
using WM.Entity.Models;

namespace WM.Entity.AutoMapper
{
    public class MappingProfile: Profile
    {
        public MappingProfile() {
            CreateMap<ImportOrderDTO, ImportDTOMapper>();
            CreateMap<ImportDetailDTO, ImportOrderDetail>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WM.Entity.DTOs.ProjectDTO
{
    public class UpdateProjectRequest
    {
        public int ProjectId { get; set; }

        public string ProjectName { get; set; } = null!;
    }
}

using Microsoft.Identity.Client.Extensions.Msal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.DTOs.ProjectDTO;
using WM.Entity.DTOs.StorageDTO;
using WM.Entity.Models;

namespace WM.Service
{
    public interface IProjectService
    {
        List<Project> GetAllProject();
        Project GetProjectById(int id);
        CreateProjectResponse AddProject(CreateProjectRequest project);
        UpdateProjectResponse UpdateProject(UpdateProjectRequest project);
    }
    public class ProjectService : IProjectService
    {
        private readonly WarehouseManagementContext _context;

        public ProjectService(WarehouseManagementContext context)
        {
            _context = context;
        }

        public CreateProjectResponse AddProject(CreateProjectRequest project)
        {
            try
            {
                var requestProject = new Project 
                {
                    ProjectName = project.ProjectName
                };
                _context.Projects.Add(requestProject);
                _context.SaveChanges();
                return new CreateProjectResponse { IsSuccess = true, Message = $"Thêm du an thành công" };

            }
            catch (Exception ex)
            {
                return new CreateProjectResponse { IsSuccess = false, Message = $"Thêm du an thất bại" };
            }
        }

        public List<Project> GetAllProject()
        {
            try
            {
                var projects = _context.Projects.ToList();
                return projects;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public Project GetProjectById(int id)
        {
            try
            {
                var projects = _context.Projects.FirstOrDefault(p => p.ProjectId == id);
                return projects ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public UpdateProjectResponse UpdateProject(UpdateProjectRequest project)
        {
            try
            {
                var requestProject = new Project
                {
                    ProjectId = project.ProjectId,
                    ProjectName = project.ProjectName
                    
                };
                _context.Projects.Update(requestProject);
                _context.SaveChanges();
                return new UpdateProjectResponse { IsSuccess = true, Message = "Update project successfully" };

            }
            catch (Exception e)
            {
                return new UpdateProjectResponse { IsSuccess = false, Message = "Update project failed" };
            }
        }
    }
}

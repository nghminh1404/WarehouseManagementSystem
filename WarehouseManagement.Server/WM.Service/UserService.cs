using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;
using WM.Entity.DTOs.UserDTO;
using Microsoft.EntityFrameworkCore;


namespace WM.Service
{
    public interface IUserService
    {
        List<User>? GetUsersByKeyword(int offset, int limit,string? keyword);
        List<User>? GetAllUser();
        User? GetUserById(int id);
        User? GetUserByEmailAndPassword(string email, string password);
        User? GetUserByEmail(string email);
        CreateUserResponse AddUser(CreateUserRequest user);
        UpdateUserResponse UpdateUser(UpdateUserRequest user);
        bool UpdateDeleteStatusUser(int id);
        List<User> GetUsersByRoleId(int offset, int limit, int? roleId);
    }

    public class UserService : IUserService
    {
        private readonly WarehouseManagementContext _context;

        public UserService(WarehouseManagementContext context)
        {
            _context = context;
        }

        public CreateUserResponse AddUser(CreateUserRequest user)
        {

            return null;
        //    try
        //    {
        //        var password = "123456";
                
        //        var requestUser = new User
        //        {
        //            UserName = user.UserName,
        //            FullName = user.FullName,
        //            Email = user.Email,
        //            Address = user.Address,
        //            Phone = user.Phone,
        //            RoleId = user.RoleId,
        //            Password = password,
        //            StatusId = user.StatusId,
        //            IsDeleted = user.IsDeleted
        //        };
        //        _context.Users.Add(requestUser);
        //        _context.SaveChanges();
        //        return new CreateUserResponse { IsSuccess = true, Message = "Add user complete" };
        //    }
        //    catch (Exception e)
        //    {
        //        return new CreateUserResponse { IsSuccess = false, Message = $"Add user failed {e.Message}" };

        //    }
        }

        public List<User>? GetAllUser()
        {
            try
            {
                var users = _context.Users.ToList();
                return users;

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User? GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public User? GetUserByEmailAndPassword(string email, string password)
        {
            throw new NotImplementedException();
        }

        public User? GetUserById(int id)
        {
            try
            {
                var user = _context.Users.FirstOrDefault(a => a.UserId == id);
                return user ?? null;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public List<User>? GetUsersByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<User>? GetUsersByKeyword(int offset, int limit, string? keyword)
        {
            try
            {

                var users = _context.Users.Where(s => s.UserCode.ToLower().Contains(keyword.ToLower())
                                                      || s.UserName.ToLower().Contains(keyword.ToLower()) 
                                                      || s.Email.ToLower().Contains(keyword.ToLower()))
                                                .OrderBy(s => s.UserId).ToList();
                var count = users.Count();
                if (limit > count && offset >= 0)
                {
                    return users.Skip(offset).Take(count).ToList();

                }

                else if (offset >= 0)
                {
                    return users.Skip(offset).Take(limit).ToList();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        public List<User> GetUsersByRoleId(int offset, int limit, int? roleId)
        {
            try
            {

                var users = _context.Users.Where(s => s.RoleId == roleId)
                                                .OrderBy(s => s.UserId).ToList();
                var count = users.Count();
                if (limit > count && offset >= 0)
                {
                    return users.Skip(offset).Take(count).ToList();

                }

                else if (offset >= 0)
                {
                    return users.Skip(offset).Take(limit).ToList();
                }
                else
                {
                    return null;
                }

            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public bool UpdateDeleteStatusUser(int id)
        {
            throw new NotImplementedException();
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest user)
        {
            throw new NotImplementedException();
        }
    }
}

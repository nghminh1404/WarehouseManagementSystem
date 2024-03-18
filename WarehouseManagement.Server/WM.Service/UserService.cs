using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;
using WM.Entity.DTOs.UserDTO;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;
using WM.Entity.DTOs;

namespace WM.Service
{
    public interface IUserService
    {
      //  List<User>? GetUsersByKeyword(int offset, int limit,string? keyword);
        UserFilterPagingResponse GetUsersByKeyword(int pageNum,string? keyword, int? role, int? statusId, int? storageId);
        List<UserDTO>? GetAllUser();
        User? GetUserById(int id);
        User? GetUserByEmailAndPassword(string email, string password);
        User? GetUserByEmail(string email);
        CreateUserResponse AddUser(CreateUserRequest user);
        UpdateUserResponse UpdateUser(UpdateUserRequest user);
        bool UpdateDeleteStatusUser(int id);
       // List<User> GetUsersByRoleId(int offset, int limit, int? roleId);
        UserFilterPagingResponse GetUsersByRoleId(int pageNum, int? roleId);
    }

    public class UserService : IUserService
    {
        private readonly WarehouseManagementContext _context;

        public UserService(WarehouseManagementContext context)
        {
            _context = context;
        }
        List<UserDTO> userDTOs = new List<UserDTO>();
        public CreateUserResponse AddUser(CreateUserRequest user)
        {


            try
            {
                var password = "123456";

                var requestUser = new User
                {
                    UserName = user.UserName,
                    UserCode = user.UserCode,
                    FullName = user.FullName,
                    Email = user.Email,
                    Address = user.Address,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                    Password = password,
                    StatusId = user.StatusId,
                    StorageId = user.StorageId,
                    Image = user.Image
                };
                _context.Users.Add(requestUser);
                _context.SaveChanges();
                return new CreateUserResponse { IsSuccess = true, Message = "Add user complete" };
            }
            catch (Exception e)
            {
                return new CreateUserResponse { IsSuccess = false, Message = $"Add user failed {e.Message}" };

            }
        }

        public List<UserDTO>? GetAllUser()
        {
            try
            {
                var users = _context.Users.Include(x => x.Role).Include(x => x.Storage)
                    .Select(u => new UserDTO
                {
                    UserName = u.UserName,
                    UserCode = u.UserCode,
                    FullName = u.FullName,
                    Email = u.Email,
                    Address = u.Address,
                    Phone = u.Phone,
                    RoleName = u.Role.RoleName,
                    Password = u.Password,
                    Status = u.Status.StatusType,
                    StorageName = u.Storage.StorageName,
                    Image = u.Image
                })
                    .ToList();
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

        //public List<User>? GetUsersByKeyword(string keyword)
        //{
        //    throw new NotImplementedException();
        //}

        public UserFilterPagingResponse GetUsersByKeyword(int pageNum, string? keyword = "", int? role = 0, int? statusId = 0, int? storageId = 0)
        {
            try
            {
                var pageSize = 10;
                if (pageNum <= 0) pageNum = 1;
                var users = _context.Users
                    .Include(s=> s.Status).Include(s => s.Storage).Include(s => s.Role)
                    .Where(s => s.UserCode.ToLower().Contains(keyword.ToLower())
                                                      || s.UserName.ToLower().Contains(keyword.ToLower())
                                                      || s.Email.ToLower().Contains(keyword.ToLower())
                                                      && (s.RoleId == role || role == 0)
                                                      && (s.StatusId == statusId || statusId == 0)
                                                      && (s.StorageId == storageId || storageId == 0))
                                               
                                                .OrderBy(s => s.UserId).OrderBy(s => s.StatusId);
                                                
                var count = users.Count();
                var userDTo = users.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    UserCode = u.UserCode,
                    UserName = u.UserName,
                    FullName = u.FullName,
                    Email = u.Email,
                    Address = u.Address,
                    Phone = u.Phone,
                    RoleId = u.RoleId,
                    RoleName = u.Role.RoleName,
                    Password = u.Password,
                    StatusId = u.StatusId,
                    Status = u.Status.StatusType,
                    StorageName = u.Storage.StorageName,
                    Image = u.Image
                });
                var res = userDTo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new UserFilterPagingResponse
                {
                   
                    PageSize = pageSize, TotalPages = (int)totalPages,
                    Data = res,
                };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }


        //public List<User> GetUsersByRoleId(int offset, int limit, int? roleId)
        //{
        //    try
        //    {

        //        var users = _context.Users.Where(s => s.RoleId == roleId)
        //                                        .OrderBy(s => s.UserId).ToList();
        //        var count = users.Count();
        //        if (limit > count && offset >= 0)
        //        {
        //            return users.Skip(offset).Take(count).ToList();

        //        }

        //        else if (offset >= 0)
        //        {
        //            return users.Skip(offset).Take(limit).ToList();
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}

        //public List<User> GetUsersByRoleId(int pageSize, int? roleId)
        //{
        //    try
        //    {

        //        var users = _context.Users.Where(s => s.RoleId == roleId)
        //                                        .OrderBy(s => s.UserId).ToList();
        //        var count = users.Count();
        //        if (limit > count && offset >= 0)
        //        {
        //            return users.Skip(offset).Take(count).ToList();

        //        }

        //        else if (offset >= 0)
        //        {
        //            return users.Skip(offset).Take(limit).ToList();
        //        }
        //        else
        //        {
        //            return null;
        //        }

        //    }
        //    catch (Exception e)
        //    {
        //        throw new Exception(e.Message);
        //    }
        //}
        public bool UpdateDeleteStatusUser(int id)
        {
            try
            {
                var user = GetUserById(id);
                if (user == null)
                {
                    return false;
                }
                else if (user.StatusId == 1 )
                {
                    user.StatusId = 2;
                }
                else user.StatusId = 1;
                _context.Update(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest user)
        {
            try
            {

                var requestAccount = new User 
                {
                    UserId = user.UserId,
                    UserCode = user.UserCode,
                    UserName = user.UserName,
                    FullName = user.FullName,
                    Email = user.Email,
                    Address = user.Address,
                    Phone = user.Phone,
                    RoleId = user.RoleId,
                    Password = user.Password,
                    StatusId = user.StatusId,
                    StorageId = user.StorageId,
                    Image = user.Image
                };
                _context.Update(requestAccount);
                _context.SaveChanges();
                return new UpdateUserResponse { IsSuccess = true, Message = "Update account complete" };
            }
            catch (Exception e)
            {
                return new UpdateUserResponse { IsSuccess = false, Message = "Update account failed" + e.Message };
            }
        }

        public UserFilterPagingResponse GetUsersByRoleId(int pageNum, int? roleId)
        {
            try
            {
                var pageSize = 10;
                if (pageNum <= 0) pageNum = 1;
                var users = _context.Users.Where(s => s.RoleId == roleId || roleId == 0)
                                                .OrderBy(s => s.UserId).ToList();
                var count = users.Count();
                var userDTo = users.Select(u => new UserDTO
                {
                    UserId = u.UserId,
                    UserCode = u.UserCode,
                    UserName = u.UserName,
                    FullName = u.FullName,
                    Email = u.Email,
                    Address = u.Address,
                    Phone = u.Phone,
                    RoleId = u.RoleId,
                    RoleName = u.Role.RoleName,
                    Password = u.Password,
                    StatusId = u.StatusId,
                    Status = u.Status.StatusType,
                    StorageName = u.Storage.StorageName,
                    Image = u.Image
                });
                var res = userDTo.Skip((pageNum - 1) * pageSize).Take(pageSize).ToList();
                var totalPages = Math.Ceiling((double)count / pageSize);
                return new UserFilterPagingResponse { Data = res, PageSize = pageSize, TotalPages = (int)totalPages };
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}

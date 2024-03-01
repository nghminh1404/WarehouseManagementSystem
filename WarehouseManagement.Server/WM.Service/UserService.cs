using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Entity.Models;
using WM.Entity.DTOs.UserDTO;


namespace WM.Service
{
    public interface IUserService
    {
        List<User>? GetUsersByKeyword(string keyword);
        List<User>? GetAllUser();
        User? GetUserById(int id);
        User? GetUserByEmailAndPassword(string email, string password);
        User? GetUserByEmail(string email);
        CreateUserResponse AddUser(CreateUserRequest account);
        UpdateUserResponse UpdateUser(UpdateUserRequest account);
        bool UpdateDeleteStatusUser(int id);
        List<User> GetUsersByRoleId(int roleId);
    }

    public class UserService : IUserService
    {
        public CreateUserResponse AddUser(CreateUserRequest account)
        {
            throw new NotImplementedException();
        }

        public List<User>? GetAllUser()
        {
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public List<User>? GetUsersByKeyword(string keyword)
        {
            throw new NotImplementedException();
        }

        public List<User> GetUsersByRoleId(int roleId)
        {
            throw new NotImplementedException();
        }

        public bool UpdateDeleteStatusUser(int id)
        {
            throw new NotImplementedException();
        }

        public UpdateUserResponse UpdateUser(UpdateUserRequest account)
        {
            throw new NotImplementedException();
        }
    }
}

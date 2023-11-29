using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Interfaces
{
    public interface IUserService
    {
        public User? GetUserById(int userId);
        public List<User> GetAllUsers();
        public void CreateUser(User user);
        public void UpdateUser(User user);
        public void DeleteUser(int userId);
    }
}

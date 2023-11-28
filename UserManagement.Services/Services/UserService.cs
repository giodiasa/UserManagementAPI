using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Services
{
    public class UserService
    {
        private readonly UserManagementContext _dbContext;

        public UserService(UserManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public User? GetUserById(int userId)
        {
            return _dbContext.Users.Find(userId);
        }

        public List<User> GetAllUsers()
        {
            return _dbContext.Users.ToList();
        }

        public void CreateUser(User user)
        {
            _dbContext.Users.Add(user);
            _dbContext.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            _dbContext.Users.Update(user);
            _dbContext.SaveChanges();
        }

        public void DeleteUser(int userId)
        {
            var user = _dbContext.Users.Find(userId);
            if (user != null)
            {
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }
    }
}

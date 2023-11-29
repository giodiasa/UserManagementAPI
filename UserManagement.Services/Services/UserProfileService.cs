using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data;
using UserManagement.Data.Entities;
using UserManagement.Services.Interfaces;

namespace UserManagement.Services.Services
{
    public class UserProfileService : IUserProfileService
    {
        private readonly UserManagementContext _dbContext;

        public UserProfileService(UserManagementContext dbContext)
        {
            _dbContext = dbContext;
        }

        public UserProfile? GetUserProfileById(int userProfileId)
        {
            return _dbContext.UserProfiles.Find(userProfileId);
        }

        public List<UserProfile> GetAllUserProfiles()
        {
            return _dbContext.UserProfiles.ToList();
        }

        public void CreateUserProfile(UserProfile userProfile)
        {
            _dbContext.UserProfiles.Add(userProfile);
            _dbContext.SaveChanges();
        }

        public void UpdateUserProfile(UserProfile userProfile)
        {
            _dbContext.UserProfiles.Update(userProfile);
            _dbContext.SaveChanges();
        }

        public void DeleteUserProfile(int userProfileId)
        {
            var userProfile = _dbContext.UserProfiles.Find(userProfileId);
            if (userProfile != null)
            {
                _dbContext.UserProfiles.Remove(userProfile);
                _dbContext.SaveChanges();
            }
        }
    }
}

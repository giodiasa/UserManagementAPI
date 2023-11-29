using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Data.Entities;

namespace UserManagement.Services.Interfaces
{
    public interface IUserProfileService
    {
        public UserProfile? GetUserProfileById(int userProfileId);
        public List<UserProfile> GetAllUserProfiles();
        public void CreateUserProfile(UserProfile userProfile);
        public void UpdateUserProfile(UserProfile userProfile);
        public void DeleteUserProfile(int userProfileId);
    }
}

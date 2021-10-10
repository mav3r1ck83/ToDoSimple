using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;
using GreenSlate.Business.Interfaces;
using GreenSlate.Business.CacheHelper;
using GreenSlate.Database.Interfaces;
using System.Runtime.Caching;

namespace GreenSlate.Business.Services
{
    public class UserService : IUserService
    {
        protected MemoryCache cache;
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDto> GetUsers()
        {
            
            List<UserDto> userDtos = _userRepository.GetUsers();
            GlobalCachingProvider.Instance.AddItem("currentUser", userDtos[0].User_Name);

            return userDtos;
        }
        public string GetCurrentUserName()
        {
            string currentUserName = GlobalCachingProvider.Instance.GetItem("currentUser") as string; 
            return currentUserName;
        }
        public string SetCurrentUser(String userName)
        {
            GlobalCachingProvider.Instance.GetItem("currentUser", true);
            GlobalCachingProvider.Instance.AddItem("currentUser", userName);
            return userName;
        }
    }
}

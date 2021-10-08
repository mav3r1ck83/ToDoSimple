using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;
using GreenSlate.Business.Interfaces;
using GreenSlate.Database.Interfaces;

namespace GreenSlate.Business.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public List<UserDto> GetUsers()
        {
            List<UserDto> userDtos = _userRepository.GetUsers();
            return userDtos;
        }
    }
}

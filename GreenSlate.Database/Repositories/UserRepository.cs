using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;
using GreenSlate.Database.Interfaces;

namespace GreenSlate.Database.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly GSCapstoneEntities _context;
        public UserRepository()
        {
            _context = new GSCapstoneEntities();
        }
        public List<UserDto> GetUsers()
        {
            IEnumerable<User> users = _context.Users;
            List<UserDto> userDtos = new List<UserDto>();
            AutoMapper.Mapper.Map(users, userDtos);
            return userDtos;
        }
    }
}

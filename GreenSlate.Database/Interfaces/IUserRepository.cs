using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;

namespace GreenSlate.Database.Interfaces
{
    public interface IUserRepository
    {
        List<UserDto> GetUsers();
    }
}

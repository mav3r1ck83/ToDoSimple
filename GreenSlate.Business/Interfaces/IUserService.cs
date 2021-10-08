using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;

namespace GreenSlate.Business.Interfaces
{
    public interface IUserService
    {
        List<UserDto> GetUsers();
    }
}

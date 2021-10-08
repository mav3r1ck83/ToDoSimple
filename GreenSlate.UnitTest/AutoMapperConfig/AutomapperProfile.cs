using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using GreenSlate.Database;
using GreenSlate.Core.DTO;


namespace GreenSlate.UnitTest.AutoMapperConfig
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<ToDo, ToDoDto>();
            CreateMap<ToDoDto, ToDo>();
            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

        }
    }
}
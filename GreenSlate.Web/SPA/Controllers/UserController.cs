using GreenSlate.Business.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenSlate.Core.DTO;
using AutoMapper;
using GreenSlate.Web.SPA.ViewModels;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;




namespace GreenSlate.Web.SPA.Controllers
{
    public class UserController : Controller
    {

        private readonly IUserService _userService;


        public UserController(IUserService userService)
        {

            _userService = userService;
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetUsers([DataSourceRequest] DataSourceRequest request)
        {
        
            List<UserDto> usersDto = _userService.GetUsers();
            List <UsersViewModel> users= new List<UsersViewModel>();
            AutoMapper.Mapper.Map(usersDto, users);
            return Json(users, JsonRequestBehavior.AllowGet);
        }
        [HttpPost]
        public UsersViewModel UserSelected(UsersViewModel user)
        {

            var b = _userService.SetCurrentUser(user.User_Name);
            return user;
        }
    }
}
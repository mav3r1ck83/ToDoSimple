using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using GreenSlate.Business.Interfaces;
using GreenSlate.Core.DTO;
using GreenSlate.Web.SPA.ViewModels;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;

namespace GreenSlate.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITaskService _toDoService;



        public HomeController(ITaskService toDoService, IUserService userService)
        {
            _toDoService = toDoService;

        }
        public ActionResult Index()
        {


            return View();
        }
        public ActionResult Edit(int id)
        {

            ToDoGridViewModel toDoModel = new ToDoGridViewModel();

            return PartialView(toDoModel);
        }

        private void RecurseFilterDescriptors(IList<Kendo.Mvc.IFilterDescriptor> requestFilters, List<Kendo.Mvc.FilterDescriptor> allFilterDescriptors)
        {
            foreach (var filterDescriptor in requestFilters)
            {
                if (filterDescriptor is Kendo.Mvc.FilterDescriptor)
                {
                    allFilterDescriptors.Add((Kendo.Mvc.FilterDescriptor)filterDescriptor);
                }
                else if (filterDescriptor is Kendo.Mvc.CompositeFilterDescriptor)
                {
                    RecurseFilterDescriptors(((Kendo.Mvc.CompositeFilterDescriptor)filterDescriptor).FilterDescriptors, allFilterDescriptors);
                }
            }
        }
        [ValidateAntiForgeryToken]
        public JsonResult GetAllToDos([DataSourceRequest] DataSourceRequest request)
        {
            List<FilterDto> filterDtos = new List<FilterDto>();
            if (request.Filters != null && request.Filters.Any())
            {
                
                var allFilterDescriptors = new List<Kendo.Mvc.FilterDescriptor>();
                RecurseFilterDescriptors(request.Filters, allFilterDescriptors);
                var test = allFilterDescriptors[0].Member;
                foreach(var filter in allFilterDescriptors)
                {
                    FilterDto filterDto = new FilterDto();
                    filterDto.Column = filter.Member.ToString();
                    filterDto.Filter = filter.Value.ToString();
                    filterDtos.Add(filterDto);
                }
            }
            List<ToDoDto> toDosDto = _toDoService.GetToDoes(filterDtos);
            List<ToDoGridViewModel> toDos = new List<ToDoGridViewModel>();
            AutoMapper.Mapper.Map(toDosDto, toDos);
            return Json(toDos.ToDataSourceResult(request), JsonRequestBehavior.AllowGet);

        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public JsonResult UpdateToDo([DataSourceRequest] DataSourceRequest request, ToDoGridViewModel toDo)
        {
            if (toDo != null && ModelState.IsValid)
            {
                ToDoDto toDoDto = new ToDoDto();
                AutoMapper.Mapper.Map(toDo, toDoDto);
                toDoDto = _toDoService.UpdateToDo(toDoDto);
            }
            return Json(new[] { toDo }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        [ValidateAntiForgeryToken]
        public JsonResult CreateToDo([DataSourceRequest] DataSourceRequest request, ToDoGridViewModel toDo)
        {
            if (toDo != null && ModelState.IsValid)
            {
                ToDoDto toDoDto = new ToDoDto();
                AutoMapper.Mapper.Map(toDo, toDoDto);
                toDoDto.Created_By = ViewBag.User;
                toDoDto = _toDoService.CreateTodo(toDoDto);
            }
            return Json(new[] { toDo }.ToDataSourceResult(request, ModelState));
        }

    }
}

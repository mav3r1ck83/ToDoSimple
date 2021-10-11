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

    public class TaskService : ITaskService
    {

        private readonly IToDoRepository _toDoRepository;
        private readonly IUserService _userService;
        public TaskService(IToDoRepository toDoRepository, IUserService userService)
        {
            _toDoRepository = toDoRepository;
            _userService = userService;
        }

        public ToDoDto GetTodo(int id)
        {
            ToDoDto toDo = new ToDoDto();
            try
            {
                 toDo = _toDoRepository.GetToDo(id);
            } catch(Exception exception)
            {
                toDo.Title = "ToDoNotFound";
            }
            return toDo;
        }
        public List<ToDoDto> GetToDoes(List<FilterDto> filterDtos)
        {
            List<ToDoDto> toDoes = new List<ToDoDto>();
            try
            {
                toDoes = _toDoRepository.GetToDos(filterDtos).ToList();
            }
            catch(Exception exception)
            {
                throw (exception);
            }
            return toDoes;
        }

        public ToDoDto UpdateToDo(ToDoDto toDoDto)
        {
            try
            {
                toDoDto = _toDoRepository.Update(toDoDto);
            } 
            catch(Exception exception)
            {
                throw (exception);
            }
            return toDoDto;
        }
        public ToDoDto CreateTodo(ToDoDto toDoDto)
        {
            try
            {
                toDoDto.Created_By = _userService.GetCurrentUserName();
                toDoDto = _toDoRepository.Add(toDoDto);
            } 
            catch(Exception exception)
            {
                throw (exception);
            }
            return toDoDto;
        }

    }
}

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
            return _toDoRepository.GetToDo(id);
        }
        public List<ToDoDto> GetToDoes(List<FilterDto> filterDtos)
        {
            List<ToDoDto> toDoes = _toDoRepository.GetToDos(filterDtos).ToList();
            return toDoes;
        }

        public ToDoDto UpdateToDo(ToDoDto toDoDto)
        {
            toDoDto = _toDoRepository.Update(toDoDto);
            return toDoDto;
        }
        public ToDoDto CreateTodo(ToDoDto toDoDto)
        {
            toDoDto.Created_By = _userService.GetCurrentUserName();
            toDoDto = _toDoRepository.Add(toDoDto);
            return toDoDto;
        }

    }
}

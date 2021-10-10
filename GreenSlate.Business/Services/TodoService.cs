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

    public class TodoService : ITodoService
    {

        private readonly IToDoRepository _toDoRepository;
        private readonly IUserService _userService;
        public TodoService(IToDoRepository toDoRepository, IUserService userService)
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
            List<ToDoDto> toDoes = _toDoRepository.GetToDos().ToList();
            if (filterDtos != null && filterDtos.Any())
            {
                foreach(FilterDto filter in filterDtos)
                {
                    switch (filter.Column)
                    {
                        case "Title": 
                            toDoes = toDoes.Where(e => e.Title.ToLower().Contains(filter.Filter.ToLower())).ToList();
                            break;
                        case "Estimated_Hours": 
                            toDoes = toDoes.Where(e => e.ToString().Contains(filter.Filter.ToString())).ToList();
                            break;
                        case "Created_By":
                            toDoes = toDoes.Where(e => e.Created_By.ToLower().Contains(filter.Filter.ToLower())).ToList();
                            break;
                        case "Completed":
                            toDoes = toDoes.Where(e => e.Completed.ToString().Equals(filter.Filter.ToString())).ToList();
                            break;
                        default: break;
                    }
                }
            }
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

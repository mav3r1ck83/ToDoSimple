using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;

namespace GreenSlate.Business.Interfaces
{
    public interface ITodoService
    {
        List<ToDoDto> GetToDoes(List<FilterDto> filterDtos);
        ToDoDto UpdateToDo(ToDoDto toDoDto);
        ToDoDto CreateTodo(ToDoDto toDoDto);
    }
}

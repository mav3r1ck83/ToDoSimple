using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;

namespace GreenSlate.Database.Interfaces
{
    public interface IToDoRepository
    {
        ToDoDto GetToDo(int Id);
        List<ToDoDto> GetToDos();
        ToDoDto Add(ToDoDto toDo);
        ToDoDto Update(ToDoDto ToDoChanges);
        ToDoDto Delete(int id);
    }
}

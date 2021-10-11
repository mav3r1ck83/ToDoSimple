using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GreenSlate.Core.DTO;
using GreenSlate.Database.Interfaces;

namespace GreenSlate.Database.Repositories
{
    public class ToDoRepository : IToDoRepository
    {
        GSCapstoneEntities context;
        public ToDoRepository()
        {
            context = new GSCapstoneEntities();
        }
        public ToDoDto Add(ToDoDto toDoDto)
        {
            ToDo toDo = new ToDo();
            AutoMapper.Mapper.Map(toDoDto, toDo);
            context.ToDoes.Add(toDo);
            context.SaveChanges();
            AutoMapper.Mapper.Map(toDo, toDoDto);
            return toDoDto;
        }

        public ToDoDto Delete(int id)
        {
            ToDo toDo = context.ToDoes.FirstOrDefault(e => e.Id == id);
            context.ToDoes.Remove(toDo);
            context.SaveChanges();
            ToDoDto toDoDto = new ToDoDto();
            AutoMapper.Mapper.Map(toDo, toDoDto);
            return toDoDto;
        }

        public ToDoDto GetToDo(int Id)
        {
            ToDo toDo = context.ToDoes.FirstOrDefault(e => e.Id == Id);
            ToDoDto toDoDto = new ToDoDto();
            AutoMapper.Mapper.Map(toDo, toDoDto);
            return toDoDto;
        }

        public List<ToDoDto> GetToDos(List<FilterDto> filterDtos = null)
        {
            List<ToDo> toDos = new List<ToDo>();
            if (filterDtos != null && filterDtos.Any())
            {
                toDos = getFilteredToDos(filterDtos);
            } else
            {
                toDos = context.ToDoes.ToList();
            }
            List<ToDoDto> toDoDtos = new List<ToDoDto>();
            AutoMapper.Mapper.Map(toDos, toDoDtos);
            return toDoDtos;
        }

        public ToDoDto Update(ToDoDto ToDoChanges)
        {
            ToDo updateTodo = new ToDo();
            AutoMapper.Mapper.Map(ToDoChanges, updateTodo);
            context.ToDoes.AddOrUpdate(updateTodo);
            context.SaveChanges();
            ToDoDto toDoDto = new ToDoDto();
            AutoMapper.Mapper.Map(updateTodo, toDoDto);
            return toDoDto;
        }

        private List<ToDo> getFilteredToDos(List<FilterDto> filterDtos)
        {
            List<ToDo> toDos = new List<ToDo>();
            string filter = "";
            for (int i = 0; i < filterDtos.Count(); i++)
            {
                filter = filterDtos[i].Filter.ToString().ToLower();
                if (i == 0)
                {
                    switch (filterDtos[i].Column)
                    {
                        case "Title":
                            toDos = context.ToDoes.Where(e => e.Title.ToLower().Contains(filter)).ToList();
                            break;
                        case "Estimated_Hours":
                            toDos = context.ToDoes.Where(e => e.ToString().Contains(filter)).ToList();
                            break;
                        case "Created_By":
                            toDos = context.ToDoes.Where(e => e.Created_By.ToLower().Contains(filter)).ToList();
                            break;
                        case "Completed":
                            toDos = context.ToDoes.Where(e => e.Completed.ToString().Equals(filter)).ToList();
                            break;
                        default: break;

                    }

                }
                else
                {
                    switch (filterDtos[i].Column)
                    {
                        case "Title":
                            toDos = toDos.Where(e => e.Title.ToLower().Contains(filter)).ToList();
                            break;
                        case "Estimated_Hours":
                            toDos = toDos.Where(e => e.ToString().Contains(filter)).ToList();
                            break;
                        case "Created_By":
                            toDos = toDos.Where(e => e.Created_By.ToLower().Contains(filter)).ToList();
                            break;
                        case "Completed":
                            toDos = toDos.Where(e => e.Completed.ToString().Equals(filter)).ToList();
                            break;
                        default: break;

                    }

                }
            }
            return toDos;

        }
    }
}

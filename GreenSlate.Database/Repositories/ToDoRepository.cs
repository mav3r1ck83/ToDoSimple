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

        public List<ToDoDto> GetToDos()
        {
            List<ToDo> toDos = context.ToDoes.ToList();
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
    }
}

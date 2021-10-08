using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using GreenSlate.Database.Repositories;
using GreenSlate.Database;
using GreenSlate.Core.DTO;
using System.Linq;
using AutoMapper;
using GreenSlate.UnitTest.AutoMapperConfig;



namespace GreenSlate.UnitTest.ToDoUnitTest
{

    [TestClass]
    public class ToDoUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutomapperProfile>());
        }
        [TestMethod]
        public void TestMethod1()
        {
            ToDoRepository toDoRepositoryClass = new ToDoRepository();
            var testTodo = toDoRepositoryClass.GetToDos();
            Assert.IsTrue(testTodo.Any(e => e.Id == 5));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            AutoMapper.Mapper.Reset();
        }
    }
}

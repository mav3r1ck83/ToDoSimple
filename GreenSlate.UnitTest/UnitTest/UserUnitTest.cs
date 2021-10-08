using Microsoft.VisualStudio.TestTools.UnitTesting;
using GreenSlate.UnitTest.AutoMapperConfig;
using System;
using GreenSlate.Database.Repositories;
using GreenSlate.Database;
using GreenSlate.Core.DTO;
using System.Linq;
using AutoMapper;

namespace GreenSlate.UnitTest.UnitTest
{
    [TestClass]
    public class UserUnitTest
    {
        [TestInitialize]
        public void TestInitialize()
        {
            // consider creating automapper config here
            AutoMapper.Mapper.Initialize(cfg => cfg.AddProfile<AutomapperProfile>());
        }
        [TestMethod]
        public void TestMethod1()
        {
            UserRepository userRepositoryClass = new UserRepository();
            var testUser = userRepositoryClass.GetUsers();
            Assert.IsTrue(testUser.Any(e => e.Id == 5));
        }

        [TestCleanup]
        public void TestCleanup()
        {
            AutoMapper.Mapper.Reset();
        }
    }
}

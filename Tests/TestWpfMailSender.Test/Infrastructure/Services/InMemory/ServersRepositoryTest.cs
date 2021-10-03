using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Text.RegularExpressions;
using TestWpfMailSender.Infrastructure.Services.InMemory;
using WpfMailSender.lib.Entities;
using WpfMailSender.lib.Services;

namespace TestWpfMailSender.Test.Infrastructure.Services.InMemory
{
    [TestClass]
   public class ServersRepositoryTest
    {
        [TestMethod]
        public void GetAll_Test()
        {
            //A-A-A = Arrange-Act-Assert

            var repository = new ServersRepository();

            var all = repository.GetAll();

            Assert.IsTrue(all.Any());
        }
        [TestMethod]
        public void Add_Test()
        {
            var repository = new ServersRepository();
            Regex reg = new Regex(@"([a-zA-Z0-9_.+-]+\.[a-zA-Z0-9-]+\.[a-zA-Z0-9-]+)");
            var server = new Server
            {
                Id = 1,
                Name = "Unit test  name",
                Addres = $"smtp.server.com",
                Port = 25,
                UseSSL = false,
                Login = $"Login",
                Password = TextEncoder.Encode($"Password", 7),
            };

            var actual_id = repository.Add(server);

            var all = repository.GetAll().ToArray();

            Assert.AreEqual(actual_id, server.Id);
            CollectionAssert.Contains(all, server);
            StringAssert.Matches(server.Addres, reg);

        }
    }
}

using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestWpfMailSender.Infrastructure.Services.InMemory;
using WpfMailSender.lib.Entities;

namespace TestWpfMailSender.Test.Infrastructure.Services.InMemory
{
    [TestClass]
   public class SendersRepositoryTest
    {
        [TestMethod]
        public void GetAll_Test()
        {
            //A-A-A = Arrange-Act-Assert

            var repository = new SendersRepository();

            var all = repository.GetAll();

            Assert.IsTrue(all.Any());
        }
        [TestMethod]
        public void Add_Test()
        {
            var repository = new SendersRepository();
            Regex reg = new Regex(@"(\w+\.)*\w+@(\w+\.)+[A-Za-z]+");
            var sender = new Sender
            {
                Id = 1,
                Name = "Unit test  name",
                SenderAdress = "zxcvb@mail.ru Unit test adress"
            };

            var actual_id = repository.Add(sender);

            var all = repository.GetAll().ToArray();

            Assert.AreEqual(actual_id, sender.Id);
            CollectionAssert.Contains(all, sender);
            StringAssert.Matches(sender.SenderAdress, reg);

        }
    }
}

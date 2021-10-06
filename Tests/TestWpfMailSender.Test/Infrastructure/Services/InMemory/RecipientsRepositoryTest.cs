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
   public class RecipientsRepositoryTest
    {
        [TestMethod]
        public void GetAll_Test()
        {
            //A-A-A = Arrange-Act-Assert

            var repository = new RecipientsRepository();

            var all = repository.GetAll();

            Assert.IsTrue(all.Any());
        }
        [TestMethod]
        public void Add_Test()
        {
            var repository = new RecipientsRepository();
            Regex reg = new Regex(@"(\w+\.)*\w+@(\w+\.)+[A-Za-z]+");
            var recipient = new Recipient
            {
                Id = 1,
                Name = "Unit test  name",
                RecipientAdress ="zxcvb@mail.ru Unit test adress"
            };

            var actual_id = repository.Add(recipient);

            var all = repository.GetAll().ToArray();

            Assert.AreEqual(actual_id, recipient.Id);
            CollectionAssert.Contains(all, recipient);
            StringAssert.Matches(recipient.RecipientAdress, reg);

        }
    }
}

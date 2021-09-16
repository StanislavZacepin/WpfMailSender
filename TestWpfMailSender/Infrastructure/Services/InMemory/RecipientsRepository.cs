using System.Collections.Generic;
using System.Linq;
using TestWpfMailSender.Models;

namespace TestWpfMailSender.Infrastructure.Services.InMemory
{
   public class RecipientsRepository : RepositoryInMemory<Recipient>
    {
        public RecipientsRepository(): base(Enumerable.Range(1, 10)
           .Select(i => new Recipient
           {
               Id = i,
               Name = $"Получатель {i}",
               RecipientAdress = $"recipient-{i}@server.ru",
           }))
        {
        }

         public override void Update(Recipient item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Name = item.Name;
            db_item.RecipientAdress = item.RecipientAdress;
        }
    }
}
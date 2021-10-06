using System.Collections.Generic;
using System.Linq;
using WpfMailSender.lib.Entities;

namespace TestWpfMailSender.Infrastructure.Services.InMemory
{
    public class SendersRepository : RepositoryInMemory<Sender>
    {
        public SendersRepository() : base(Enumerable.Range(1, 10)
           .Select(i => new Sender
           {
               Id = i,
               Name = $"Отправитель {i}",
               SenderAdress = $"sender-{i}@server.ru",
               
           }))
        {
        }

        public override void Update(Sender item)
        {
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Name = item.Name;
            db_item.SenderAdress = item.SenderAdress;
        }
    }
}
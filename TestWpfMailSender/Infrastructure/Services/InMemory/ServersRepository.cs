using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Models;
using WpfMailSender.lib.Service;

namespace TestWpfMailSender.Infrastructure.Services.InMemory
{
    class ServersRepository : RepositoryInMemory<Server>
    {


        public ServersRepository() : base(Enumerable.Range(1, 10)
            .Select(i => new Server
            {
                Id = i,
                Name = $"Сервер-{i}",
                Addres = $"smtp.server{i}.com",
                Port = i % 2 == 0 ? 25 : 2525,
                UseSSL = i % 2 == 0,
                Login = $"Login-{i}",
                Password = TextEncoder.Encode($"Password-{i}", 7),
            }))
        { 
        }
        public override void Update(Server item)
        {            
            var db_item = GetById(item.Id);
            if (db_item is null || ReferenceEquals(db_item, item)) return;

            db_item.Name = item.Name;
            db_item.Addres = item.Addres;
            db_item.Port = item.Port;
            db_item.Login = item.Login;
            db_item.Password = item.Password;
        }       
    }
}

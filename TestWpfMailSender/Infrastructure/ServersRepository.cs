using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Models;
using WpfMailSender.lib.Service;

namespace TestWpfMailSender.Infrastructure
{
    class ServersRepository
    {
        private List<Server> _Servers;
      
        public ServersRepository()
        {
            _Servers = Enumerable.Range(1, 10)
            .Select(i => new Server
            {
                Name = $"Сервер-{i}",
                Addres = $"smtp.server{i}.com",
                Port = i % 2 == 0 ? 25 : 2525,
                UseSSL = i % 2 == 0,
                Login = $"Login-{i}",
                Password = TextEncoder.Encode($"Password-{i}", 7),
            })
            .ToList();
    }
        public IEnumerable<Server> GetAll() => _Servers;

        public void Add(Server server)
        {
            _Servers.Add(server);
        }
        public void Remove(Server server)
        {
            _Servers.Remove(server);
        }

    }
}

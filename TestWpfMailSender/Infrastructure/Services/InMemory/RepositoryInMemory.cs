using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;
using WpfMailSender.lib.Interfaces;

namespace TestWpfMailSender.Infrastructure.Services.InMemory
{
    public abstract class RepositoryInMemory<T> : IRepository<T> where T : Entity
    {

        private readonly List<T> _Items;
        private int _MaxId;

        protected RepositoryInMemory(IEnumerable<T> items)
        {
            _Items = items.ToList();
            _MaxId = _Items.Count > 0 ? _Items.Max(i => i.Id) + 1 : 1;
        }
        public int Add(T item)
        {
            if (_Items.Contains(item))
                return item.Id;
            item.Id = _MaxId++;
            _Items.Add(item);
            return item.Id;
        }

        public IEnumerable<T> GetAll() => _Items;

        public T GetById(int id) => _Items.FirstOrDefault(s => s.Id == id);

        public bool Remove(int id) => _Items.RemoveAll(s => s.Id == id)>0  ;

        public abstract void Update(T item);
    }
}

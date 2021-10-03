using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Data;
using WpfMailSender.lib.Entities.Base;
using WpfMailSender.lib.Interfaces;

namespace TestWpfMailSender.Infrastructure.Services.InDatabase
{
    public class DbRepository<T> : IRepository<T> where T : Entity
    {
        private readonly MailSenderDB _db;

        private DbSet<T> Set { get; }

        public DbRepository(MailSenderDB db)
        {
            _db = db;
            Set = db.Set<T>();
        }
        public int Add(T item)
        {
            //Set.Add(item);
            _db.Entry(item).State = EntityState.Added;
            _db.SaveChanges();

            return item.Id;
        }

        public IEnumerable<T> GetAll() => Set;

        //public T GetById(int id) => _db.Set<T>().FirstOrDefault(item => item.Id == id);
        public T GetById(int id) => Set.Find(id);

        public bool Remove(int id)
        {
            var item = GetById(id);
            if (item is null) return false;
           // Set.Remove(item);
            _db.Entry(item).State = EntityState.Deleted;
            _db.SaveChanges();

            return true;

        }

        public void Update(T item)
        {
            _db.Entry(item).State = EntityState.Modified;
        }
    }
}

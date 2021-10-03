using Microsoft.EntityFrameworkCore;
using TestWpfMailSender.Models;

namespace TestWpfMailSender.Data
{
    public class MailSenderDB : DbContext
    {
        public DbSet<Sender> Senders { get; set; }

        public DbSet<Recipient> Recipients { get; set; }

        public DbSet<Server> Servers { get; set; }

        public DbSet<Message> Messages { get; set; }

        public DbSet<SchedulerTask> Tasks { get; set; } 
        public MailSenderDB(DbContextOptions<MailSenderDB> options) : base(options)
        {

        }
    }
}

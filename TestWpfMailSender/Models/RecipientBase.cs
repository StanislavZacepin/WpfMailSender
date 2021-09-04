using TestWpfMailSender.Models.Base;

namespace TestWpfMailSender.Models
{
    public class RecipientBase : Entity
    {
        public string Name { get; set; }
        public string RecipientAdress { get; set; }
    }
}
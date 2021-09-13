using TestWpfMailSender.Models.Base;

namespace TestWpfMailSender.Models
{
    public class Recipient : Entity
    {
        public string Name { get; set; }
        public string RecipientAdress { get; set; }

        public override string ToString() => $"{Name}: {RecipientAdress}";

    }
}

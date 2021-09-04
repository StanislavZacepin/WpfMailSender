using TestWpfMailSender.Models.Base;

namespace TestWpfMailSender.Models
{
    public class Message : Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

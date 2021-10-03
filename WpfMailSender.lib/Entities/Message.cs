using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    public class Message : Entity
    {
        public string Title { get; set; }
        public string Text { get; set; }
    }
}

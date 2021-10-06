using System.ComponentModel.DataAnnotations;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
{
    public class Server : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Addres { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; }
        [Required]
        public string Login { get; set; }
        [Required]
        public string Password { get; set; }

        public override string ToString() => $"{Addres}: {Port}";
    }
}

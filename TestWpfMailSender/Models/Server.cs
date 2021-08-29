namespace TestWpfMailSender.Models
{
    public class Server
    {
        public string Name { get; set; }
        public string Addres { get; set; }

        public int Port { get; set; }

        public bool UseSSL { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public override string ToString() => $"{Name}: {Port}";
    }
}

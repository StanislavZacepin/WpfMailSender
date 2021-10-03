using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWpfMailSender.Models.Base;

namespace TestWpfMailSender.Models
{
    public class Sender : Entity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string SenderAdress { get; set; }

        public override string ToString() => $"{Name}: {SenderAdress}";

    }
}

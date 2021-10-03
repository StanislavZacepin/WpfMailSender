using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMailSender.lib.Entities.Base;

namespace WpfMailSender.lib.Entities
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

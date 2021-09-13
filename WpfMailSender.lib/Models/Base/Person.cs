using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Models.Base
{
    public abstract class Person : NamedEntity
    {
        public string Address { get; set; }

        public string Description { get; set; }
    }
}
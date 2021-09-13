using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfMailSender.lib.Models.Base
{
    public abstract class NamedEntity : Entity
    {
        public virtual string Name { get; set; }
    }
}
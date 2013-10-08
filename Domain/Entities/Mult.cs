using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSEsMS.Domain.Entities
{
    public class Mult
    {
        public virtual int Id { get; private set; }
        
        public virtual string Position { get; set; }
        public virtual string Skill { get; set; }
        public virtual double Multiplier { get; set; }

        public virtual Tactic Tactic { get; set; }
    }
}

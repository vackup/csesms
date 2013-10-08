using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSEsMS.Domain.Entities
{
    public class Player
    {
        public virtual int Id { get; private set; }
        
        public virtual string Name { get; set; }
        public virtual int Age { get; set; }
        public virtual string Nationality { get; set; }
        public virtual int ShootStopping { get; set; }
        public virtual int Tackling { get; set; }
        public virtual int Passing { get; set; }
        public virtual int Shooting { get; set; }
        public virtual int Aggression { get; set; }
        public virtual int ShootStoppingAbility { get; set; }
        public virtual int TacklingAbility { get; set; }
        public virtual int PassingAbility { get; set; }
        public virtual int ShootingAbility { get; set; }
        public virtual int Games { get; set; }
        public virtual int Saves { get; set; }
        public virtual int KeyTackles { get; set; }
        public virtual int KeyPasses { get; set; }
        public virtual int Shots { get; set; }
        public virtual int Goals { get; set; }
        public virtual int Assists { get; set; }
        public virtual int Dps { get; set; }
        public virtual int Injury { get; set; }
        public virtual int Suspension { get; set; }
        
        public virtual int PenaltyKicker { get; set; } // Establece el orden de los pateadores de penales
        public virtual string Role { get; set; }
        public virtual int Jugar { get; set; }  // Establece si es Titular (1), Suplente (2) o No juega (0)

        public virtual Team Team { get; set; }
    }
}

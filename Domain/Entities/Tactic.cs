using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSEsMS.Domain.Entities
{
    public class Tactic
    {
        public virtual int Id { get; private set; }
        
        public virtual string Name { get; set; }
        
        public virtual IList<Mult> Mults { get; private set; }
        public virtual IList<Bonus> Bonus { get; private set; }
        public virtual IList<Team> Teams { get; private set; }

        public Tactic()
        {
            Mults = new List<Mult>();
            Bonus = new List<Bonus>();
            Teams = new List<Team>();
        }

        public virtual void AddMult(Mult mult)
        {
            //if (Teams.Contains(team)) return;

            mult.Tactic = this;
            this.Mults.Add(mult);
        }

        public virtual void AddBonus(Bonus bonus)
        {
            //if (Teams.Contains(team)) return;

            bonus.Tactic = this;
            this.Bonus.Add(bonus);
        }

        public virtual void AddTeam(Team team)
        {
            //if (Teams.Contains(team)) return;

            team.Tactic = this;
            this.Teams.Add(team);
        }
    }
}

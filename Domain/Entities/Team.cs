using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Data;

namespace CSEsMS.Domain.Entities
{
    public class Team
    {
        public virtual int Id { get; private set; }
        public virtual string Name { get; set; }
        public virtual string AbbrName { get; set; }
        
        public virtual League League { get; set; }

        public virtual Tactic Tactic { get; set; }

        public virtual IList<Player> Players { get; private set; }

        public Team()
        {
            Players = new List<Player>();
        }

        public virtual void AddPlayer(Player player)
        {
            //if (Players.Contains(team)) return;

            player.Team = this;
            Players.Add(player);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentNHibernate.Data;

namespace CSEsMS.Domain.Entities
{
    /// <summary>
    /// Domain Model que representa la liga. Contiene la parametrizacion de la liga.
    /// </summary>
    public class League
    {
        public virtual int Id { get; private set; }

        public virtual string Name { get; set; }

        public virtual int HomeBonus { get; set; }
        public virtual int DpForYellow { get; set; }
        public virtual int DpForRed { get; set; }
        public virtual int SuspensionMargin { get; set; }
        public virtual int CupMatch { get; set; }
        public virtual int MaxInjuryLength { get; set; }
        public virtual int NumSubs { get; set; }
        public virtual int Substitutions { get; set; }
        public virtual int Promotions { get; set; }
        public virtual int Relegations { get; set; }

        public virtual int AbGoal { get; set; }
        public virtual int AbAssist { get; set; }
        public virtual int AbVictoryRandom { get; set; }
        public virtual int AbDefeatRandom { get; set; }
        public virtual int AbCleanSheet { get; set; }
        public virtual int AbKeyTackling { get; set; }
        public virtual int AbKeyPasses { get; set; }
        public virtual int AbShotsOn { get; set; }
        public virtual int AbShotsOff { get; set; }
        public virtual int AbSaves { get; set; }
        public virtual int AbConceded { get; set; }
        public virtual int AbYellow { get; set; }
        public virtual int AbRed { get; set; }

        public virtual int WinPoint { get; set; }
        public virtual int DrawPoint { get; set; }

        //public virtual int ShootoutNever { get; set; }
        //public virtual int ShootoutAsk { get; set; }
        //public virtual int ShootoutAlways { get; set; }

        public virtual bool Debug { get; set; }

        public virtual IList<Team> Teams { get; private set; }

        public League()
        {
            Teams = new List<Team>();
        }

        public virtual void AddTeam(Team team)
        {
            //if (Teams.Contains(team)) return;

            team.League = this;
            Teams.Add(team);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSEsMS.Domain.Entities;
using FluentNHibernate.Mapping;

namespace CSEsMS.Domain.Mappings
{
    public class PlayerMap : ClassMap<Player>
    {
        public PlayerMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).Not.Nullable().Length(255);
            Map(x => x.Age).Not.Nullable();
            Map(x => x.Nationality).Not.Nullable().Length(3);
            Map(x => x.ShootStopping).Not.Nullable();
            Map(x => x.Tackling).Not.Nullable();
            Map(x => x.Passing).Not.Nullable();
            Map(x => x.Shooting).Not.Nullable();
            Map(x => x.Aggression).Not.Nullable();
            Map(x => x.ShootStoppingAbility).Not.Nullable();
            Map(x => x.TacklingAbility).Not.Nullable();
            Map(x => x.PassingAbility).Not.Nullable();
            Map(x => x.ShootingAbility).Not.Nullable();
            Map(x => x.Games).Not.Nullable();
            Map(x => x.Saves).Not.Nullable();
            Map(x => x.KeyTackles).Not.Nullable();
            Map(x => x.KeyPasses).Not.Nullable();
            Map(x => x.Shots).Not.Nullable();
            Map(x => x.Goals).Not.Nullable();
            Map(x => x.Assists).Not.Nullable();
            Map(x => x.Dps).Not.Nullable();
            Map(x => x.Injury).Not.Nullable();
            Map(x => x.Suspension).Not.Nullable();

            References(x => x.Team).Not.Nullable();
        }
    }
}

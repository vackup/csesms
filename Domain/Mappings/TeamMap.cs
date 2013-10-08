using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSEsMS.Domain.Entities;
using FluentNHibernate.Mapping;

namespace CSEsMS.Domain.Mappings
{
    public class TeamMap : ClassMap<Team>
    {
        public TeamMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).Not.Nullable().Length(255);
            Map(x => x.AbbrName).Not.Nullable().Length(10);
            
            References(x => x.League).Not.Nullable();
            References(x => x.Tactic);

            HasMany(x => x.Players)
                .Inverse()
                .Cascade.All();
        }
    }
}

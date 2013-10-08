using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSEsMS.Domain.Entities;
using FluentNHibernate.Mapping;

namespace CSEsMS.Domain.Mappings
{
    public class TacticMap : ClassMap<Tactic>
    {
        public TacticMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).Not.Nullable().Length(1);

            HasMany(x => x.Teams)
                .Inverse()
                .Cascade.All();
            HasMany(x => x.Mults)
                .Inverse()
                .Cascade.All();
            HasMany(x => x.Bonus)
                .Inverse()
                .Cascade.All();
        }
    }
}

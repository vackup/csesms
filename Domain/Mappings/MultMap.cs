using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CSEsMS.Domain.Entities;
using FluentNHibernate.Mapping;

namespace CSEsMS.Domain.Mappings
{
    public class MultMap : ClassMap<Mult>
    {
        public MultMap()
        {
            Id(x => x.Id);

            Map(x => x.Position).Not.Nullable().Length(2);
            Map(x => x.Skill).Not.Nullable().Length(2);
            Map(x => x.Multiplier).Not.Nullable();

            References(x => x.Tactic).Not.Nullable();
        }
    }
}

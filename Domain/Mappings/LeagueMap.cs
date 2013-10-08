using CSEsMS.Domain.Entities;
using FluentNHibernate.Mapping;

namespace CSEsMS.Domain.Mappings
{
    public class LeagueMap : ClassMap<League>
    {
        public LeagueMap()
        {
            Id(x => x.Id);

            Map(x => x.Name).Not.Nullable().Length(255);

            Map(x => x.HomeBonus).Not.Nullable();
            Map(x => x.DpForYellow).Not.Nullable();
            Map(x => x.DpForRed).Not.Nullable();
            Map(x => x.SuspensionMargin).Not.Nullable();
            Map(x => x.CupMatch).Not.Nullable();
            Map(x => x.MaxInjuryLength).Not.Nullable();
            Map(x => x.NumSubs).Not.Nullable();
            Map(x => x.Substitutions).Not.Nullable();
            Map(x => x.Promotions).Not.Nullable();
            Map(x => x.Relegations).Not.Nullable();

            Map(x => x.AbGoal).Not.Nullable();
            Map(x => x.AbAssist).Not.Nullable();
            Map(x => x.AbVictoryRandom).Not.Nullable();
            Map(x => x.AbDefeatRandom).Not.Nullable();
            Map(x => x.AbCleanSheet).Not.Nullable();
            Map(x => x.AbKeyTackling).Not.Nullable();
            Map(x => x.AbKeyPasses).Not.Nullable();
            Map(x => x.AbShotsOn).Not.Nullable();
            Map(x => x.AbShotsOff).Not.Nullable();
            Map(x => x.AbSaves).Not.Nullable();
            Map(x => x.AbConceded).Not.Nullable();
            Map(x => x.AbYellow).Not.Nullable();
            Map(x => x.AbRed).Not.Nullable();

            Map(x => x.WinPoint).Not.Nullable();
            Map(x => x.DrawPoint).Not.Nullable();

            //Map(x => x.ShootoutNever).Not.Nullable();
            //Map(x => x.ShootoutAsk).Not.Nullable();
            //Map(x => x.ShootoutAlways).Not.Nullable();

            Map(x => x.Debug).Not.Nullable();

            HasMany(x => x.Teams)
                .Inverse()
                .Cascade.All();
        }
    }
}

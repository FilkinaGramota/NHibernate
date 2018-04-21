using FluentNHibernate.Mapping;
using Demo.Entities;

namespace Demo.Mapping
{
    public class GrandPrixMap : ClassMap<GrandPrix>
    {
        public GrandPrixMap()
        {
            Id(x => x.ID);
            Map(x => x.Title).Length(50);
            Map(x => x.DateOfStart);
            Map(x => x.DateOfEnd);
            References(x => x.City).Unique().Not.LazyLoad();
            HasMany(x => x.Results).Cascade.All().Inverse().Not.LazyLoad();
        }
    }
}

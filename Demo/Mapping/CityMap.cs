using FluentNHibernate.Mapping;
using Demo.Entities;

namespace Demo.Mapping
{
    public class CityMap : ClassMap<City>
    {
        public CityMap()
        {
            Id(x => x.ID);
            Map(x => x.CityName).Length(20);
            References(x => x.Country).Not.LazyLoad();
            HasOne(x => x.GrandPrix).PropertyRef(x => x.City).Cascade.Delete();
        }
    }
}

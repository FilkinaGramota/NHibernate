using FluentNHibernate.Mapping;
using Demo.Entities;

namespace Demo.Mapping
{
    public class CountryMap : ClassMap<Country>
    {
        public CountryMap()
        {
            Id(x => x.ID);
            Map(x => x.CountryName).Not.Nullable().Length(20);
            HasMany(x => x.Persons).Cascade.All().Inverse().Not.LazyLoad();
            HasMany(x => x.Cities).Cascade.All().Inverse().Not.LazyLoad();
        }
    }
}

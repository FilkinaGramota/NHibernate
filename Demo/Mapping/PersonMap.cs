using FluentNHibernate.Mapping;
using Demo.Entities;

namespace Demo.Mapping
{
    public class PersonMap : ClassMap<Person>
    {
        public PersonMap()
        {
            Id(x => x.ID);
            Component(x => x.PersonName);
            References(x => x.Country).Not.LazyLoad();
            Map(x => x.BirthDate);
            HasMany(x => x.Results).Cascade.Delete().Inverse().Not.LazyLoad();
        }
    }
}

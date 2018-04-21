using FluentNHibernate.Mapping;
using Demo.Entities;

namespace Demo.Mapping
{
    public class NameMap : ComponentMap<Name>
    {
        public NameMap()
        {
            Map(x => x.FirstName).Not.Nullable().Length(30);
            Map(x => x.MiddleName).Length(30);
            Map(x => x.LastName).Not.Nullable().Length(30);
        }
    }
}

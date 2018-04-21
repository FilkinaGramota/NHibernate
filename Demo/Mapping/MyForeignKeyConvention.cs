using System;
using FluentNHibernate.Conventions;
using FluentNHibernate;

namespace Demo.Mapping
{
    public class MyForeignKeyConvention : ForeignKeyConvention
    {
        protected override string GetKeyName(Member property, Type type)
        {
            var refName = property == null ? type.Name : property.Name;
            return string.Format("ID_{0}", refName);
        }
    }
}

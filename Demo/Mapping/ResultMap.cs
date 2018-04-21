using System;
using System.Collections.Generic;
using System.Linq;
using FluentNHibernate.Mapping;
using Demo.Entities;

namespace Demo.Mapping
{
    public class ResultMap : ClassMap<Result>
    {
        public ResultMap()
        {
            Id(x => x.ID);
            References(x => x.Person).Not.LazyLoad();
            References(x => x.GrandPrix).Not.LazyLoad();
            Component(x => x.Score);
        }
    }
}

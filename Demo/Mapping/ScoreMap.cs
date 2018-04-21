using Demo.Entities;
using FluentNHibernate.Mapping;

namespace Demo.Mapping
{
    public class ScoreMap: ComponentMap<Score>
    {
        public ScoreMap()
        {
            Map(x => x.ShortProgram).Precision(2);
            Map(x => x.FreeSkating).Precision(2);
            Map(x => x.TotalScore).Precision(2);
        }
    }
}

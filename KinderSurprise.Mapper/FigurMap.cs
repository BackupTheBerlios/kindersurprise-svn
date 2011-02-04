using FluentNHibernate.Mapping;
using KinderSurprise.Model;

namespace KinderSurprise.Mapper
{
    public sealed class FigurMap : ClassMap<Figur>
    {
        public FigurMap()
        {
            Table("tFigur");
            Id(x => x.Id).Column("FigurId");
            Map(x => x.Name).Column("FigurName");
            Map(x => x.Description);
            Map(x => x.Price);
            References(x => x.Serie, "FK_Serie_ID");
            Cache.ReadWrite();
        }
    }
}

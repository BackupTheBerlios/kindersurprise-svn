using FluentNHibernate.Mapping;

namespace KinderSurprise.Mapper.Mapping
{
    public sealed class FigurMap : ClassMap<Figur>
    {
        public FigurMap()
        {
            Table("tFigur");
            Id(x => x.FigurId);
            Map(x => x.FigurName);
            Map(x => x.Description);
            Map(x => x.Price);
            References(x => x.Serie, "FK_Serie_ID");
            Cache.ReadWrite();
        }
    }
}

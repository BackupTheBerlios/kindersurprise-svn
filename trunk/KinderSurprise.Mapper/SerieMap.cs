using FluentNHibernate.Mapping;
using KinderSurprise.Model;

namespace KinderSurprise.Mapper
{
    public sealed class SerieMap : ClassMap<Serie>
    {
        public SerieMap()
        {
            Table("tSerie");
            Id(x => x.Id).Column("SerieId");
            Map(x => x.Name).Column("SerieName");
            Map(x => x.Description);
            Map(x => x.PublicationYear);
            References(x => x.Category, "FK_Category_ID");
            Cache.ReadWrite();
        }
    }
}

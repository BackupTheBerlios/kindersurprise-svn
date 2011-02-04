using KinderSurprise.Model;
using FluentNHibernate.Mapping;

namespace KinderSurprise.Mapper
{
    public sealed class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("tCategory");
            Id(x => x.Id).Column("CategoryId");
            Map(x => x.Name).Column("CategoryName");
            Map(x => x.Description);
            Cache.ReadWrite();
        }
    }
}

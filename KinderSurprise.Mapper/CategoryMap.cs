using KinderSurprise.Model;
using FluentNHibernate.Mapping;

namespace KinderSurprise.Mapper
{
    public sealed class CategoryMap : ClassMap<Category>
    {
        public CategoryMap()
        {
            Table("tCategory");
            Id(x => x.CategoryId);
            Map(x => x.CategoryName);
            Map(x => x.Description);
            Cache.ReadWrite();
        }
    }
}

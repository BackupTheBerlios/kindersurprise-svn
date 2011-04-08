using FluentNHibernate.Mapping;
using KinderSurprise.Model;

namespace KinderSurprise.Mapper
{
	public sealed class PictureMap : ClassMap<Picture>
	{
		public PictureMap ()
		{
			Table("tPicture");
			Id(x => x.Id);
			Map(x => x.Path, "FullPath");
			References(x => x.Serie, "FK_Serie_ID");
			References(x => x.Figur, "FK_Figur_ID");
			References(x => x.Instructions, "FK_Instructions_ID");
			Cache.ReadWrite();
		}
	}
}

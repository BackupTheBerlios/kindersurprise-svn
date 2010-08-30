using FluentNHibernate.Mapping;

namespace KinderSurprise.Mapper
{
	public sealed class PictureMap : ClassMap<Picture>
	{
		public PictureMap ()
		{
			Table("tPicture");
			Id(x => x.Id);
			Map(x => x.Path, "FullPath");
			References(x => x.Fk_Serie_Id, "FK_Serie_ID");
			References(x => x.Fk_Figur_Id, "FK_Figur_ID");
			References(x => x.Fk_Instructions_Id, "FK_Instructions_ID");
			Cache.ReadWrite();
		}
	}
}

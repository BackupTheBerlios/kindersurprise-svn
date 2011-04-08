using FluentNHibernate.Mapping;
using KinderSurprise.Model;

namespace KinderSurprise.Mapper
{
	public sealed class InstructionMap : ClassMap<Instructions>
	{
		public InstructionMap()
		{
			Table("tInstructions");
			Id(x => x.Id);
			Map(x => x.Name);
			References(x => x.Figur, "FK_Figur_ID");
			Cache.ReadWrite();
		}
	}
}

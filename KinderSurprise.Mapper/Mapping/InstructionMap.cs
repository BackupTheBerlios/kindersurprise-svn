using System;
using FluentNHibernate.Mapping;

namespace KinderSurprise.Mapper
{
	public sealed class InstructionMap : ClassMap<Instructions>
	{
		public InstructionMap()
		{
			Table("tInstructions");
			Id(x => x.Id);
			Map(x => x.Name);
			References(x => x.Fk_Figur_Id, "FK_Figur_ID");
			Cache.ReadWrite();
		}
	}
}

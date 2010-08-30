using System;
using KinderSurprise.Mapper;

namespace KinderSurprise.DTO
{
	public class InstructionsDto
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public Figur Fk_Figur_Id { get; set; }
		
		public InstructionsDto(int id, string name, Figur fk_figur_id)
		{
			Id = id;
			Name = name;
			Fk_Figur_Id = fk_figur_id;
		}
	}
}

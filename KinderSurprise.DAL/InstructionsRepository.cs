using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using NHibernate;

namespace KinderSurprise.DAL
{
	public class InstructionsRepository : IInstructionsRepository
	{
		public List<InstructionsDto> GetByFigurId(int id)
		{
			using (ISession session = RepositoryBase.OpenSession())
			{
				List<InstructionsDto> instructionsDtos = new List<InstructionsDto>();
				ICriteria crit = session.CreateCriteria(typeof(Instructions));
				crit.Add(NHibernate.Criterion.Expression.Eq("Fk_Figur_Id.FigurId", id));
				
				var instructionsList = crit.List();
				
				foreach (Instructions i in instructionsList)
				{
					instructionsDtos.Add(new InstructionsDto(i.Id, i.Name, i.Fk_Figur_Id));
				}
				
				return instructionsDtos;
			}
		}
	}
}

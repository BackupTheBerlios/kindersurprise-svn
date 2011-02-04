using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.DAL
{
	public class InstructionsRepository : IInstructionRepository
	{
		public List<Instructions> GetByFigurId(int id)
		{
			using (ISession session = RepositoryBase.OpenSession())
			{
				ICriteria crit = session.CreateCriteria(typeof(Instructions));
				crit.Add(NHibernate.Criterion.Expression.Eq("Fk_Figur_Id.FigurId", id));
				
				return crit.List().Cast<Instructions>().ToList();
			}
		}
	}
}

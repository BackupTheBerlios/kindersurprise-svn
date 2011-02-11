using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;
using NHibernate.LambdaExtensions;

namespace KinderSurprise.DAL
{
	public class InstructionsRepository : IInstructionsRepository
	{
		public List<Instructions> GetByFigurId(int id)
		{
			using (ISession session = SessionBase.OpenSession())
			{
				ICriteria crit = session.CreateCriteria(typeof(Instructions));
				crit.Add<Instructions>(exp => exp.Fk_Figur_Id.Id == id);
				
				return crit.List().Cast<Instructions>().ToList();
			}
		}
	}
}

using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Repository;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.RepositoryImpl.NHImpl
{
	public class InstructionsRepository : IInstructionsRepository
	{
		public List<Instructions> GetByFigurId(int id)
		{
			using (ISession session = SessionBase.OpenSession())
			{
			    return session.QueryOver<Instructions>()
			        .Where(x => x.Figur.Id == id)
			        .CacheMode(CacheMode.Normal)
			        .List().ToList();
			}
		}
	}
}

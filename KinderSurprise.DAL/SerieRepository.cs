using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;
using NHibernate.LambdaExtensions;

namespace KinderSurprise.DAL
{
    public class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        public List<Serie> GetAllByCategoryId(int categoryId)
        {
            using (ISession session = SessionBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Serie));
				crit.Add<Serie>(exp => exp.Category.Id == categoryId);
								
				return crit.List().Cast<Serie>().ToList();
			}
        }
    }
}

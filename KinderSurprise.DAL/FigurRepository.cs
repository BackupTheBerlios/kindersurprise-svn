using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;
using NHibernate.LambdaExtensions;

namespace KinderSurprise.DAL
{
    public class FigurRepository : BaseRepository<Figur>, IFigurRepository
    {
        public List<Figur> GetAllBySerieId(int serieId)
        {
			using (ISession session = SessionBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Figur));
				crit.SetCacheMode(CacheMode.Normal);
				crit.Add<Figur>(exp => exp.Serie.Id == serieId);
								
				return crit.List().Cast<Figur>().ToList();
            }
        }
    }
}

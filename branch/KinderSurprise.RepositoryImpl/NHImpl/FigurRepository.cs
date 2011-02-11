using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using KinderSurprise.Repository;
using NHibernate;

namespace KinderSurprise.RepositoryImpl.NHImpl
{
    public class FigurRepository : BaseRepository<Figur>, IFigurRepository
    {
        public List<Figur> GetAllBySerieId(int serieId)
        {
			using (ISession session = SessionBase.OpenSession())
			{
			    return session.QueryOver<Figur>()
			        .Where(x => x.Serie.Id == serieId)
			        .CacheMode(CacheMode.Normal).Cacheable()
                    .List().ToList();
            }
        }
    }
}

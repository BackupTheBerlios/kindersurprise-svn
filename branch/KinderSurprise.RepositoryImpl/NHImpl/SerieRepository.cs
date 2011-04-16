using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Repository;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.RepositoryImpl.NHImpl
{
    public class SerieRepository : BaseRepository<Serie>, ISerieRepository
    {
        public List<Serie> GetAllByCategoryId(int categoryId)
        {
            using (ISession session = SessionBase.OpenSession())
            {
                return session.QueryOver<Serie>()
                    .Where(x => x.Category.Id == categoryId)
					.Cacheable()
                    .CacheMode(CacheMode.Normal)
                    .List().ToList();
			}
        }
    }
}

using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Repository;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.RepositoryImpl.NHImpl
{
	public class PictureRepository : IPictureRepository
	{
		public List<Picture> GetById(int id, EType type)
		{
			using (ISession session = SessionBase.OpenSession())
			{
			    var queryOver = session.QueryOver<Picture>();
				if(type.Equals(EType.Figur))
				{
				    queryOver.Where(x => x.Fk_Figur_Id.Id == id);
				}
				if(type.Equals(EType.Serie))
				{
				    queryOver.Where(x => x.Fk_Serie_Id.Id == id);
				}
				if(type.Equals(EType.Instructions))
				{
				    queryOver.Where(x => x.Fk_Instructions_Id.Id == id);
				}

			    return queryOver.CacheMode(CacheMode.Normal).Cacheable()
			        .List().ToList();
			}
		}
	}
}

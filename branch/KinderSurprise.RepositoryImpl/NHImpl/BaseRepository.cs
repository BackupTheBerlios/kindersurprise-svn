using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.RepositoryImpl.NHImpl
{
	public class BaseRepository<T> where T : BaseObject
	{
		public bool HasId(int id)
        {
			using (ISession session = SessionBase.OpenSession())
            {
                var hasObject = session.Get<T>(id);

                return hasObject != null;
            }
        }
		
		public List<T> GetAll()
        {
			using (ISession session = SessionBase.OpenSession())
			{
			    return session.QueryOver<T>()
			        .CacheMode(CacheMode.Normal).Cacheable()
			        .List().ToList();
            }
        }
		
		public T GetById(int id)
        {
            using (ISession session = SessionBase.OpenSession())
            {
                return session.Get<T>(id);
            }
        }
		
		public void DeleteById(int id)
        {
			using (ISession session = SessionBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(GetById(id));
                    transaction.Commit();
                }
            }
        }
		
		public int Add(T dto)
        {
			using (ISession session = SessionBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(dto);
                    transaction.Commit();
                }
            }
			
			return dto.Id;
        }
		
		public void Update(T dto)
        {
			using (ISession session = SessionBase.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(dto);
                    transaction.Commit();
                }
            }
        }
	}
}


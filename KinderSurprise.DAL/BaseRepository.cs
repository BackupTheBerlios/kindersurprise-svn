using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.DAL
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
				ICriteria crit = session.CreateCriteria(typeof(T));
				return crit.List().Cast<T>().ToList();
            }
        }
		
		public T GetById(int id)
        {
            using (ISession session = SessionBase.OpenSession())
            {
                var returnObject = session.Get<T>(id);
                return returnObject == null
                           ? null
                           : returnObject;
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
		
		public void Add(T dto)
        {
            using (ISession session = SessionBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(dto);
                    transaction.Commit();
                }
            }
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


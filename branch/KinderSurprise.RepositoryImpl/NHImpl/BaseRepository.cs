using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;
using NHibernate;
using StructureMap;

namespace KinderSurprise.RepositoryImpl.NHImpl
{
	public class BaseRepository<T> where T : BaseObject
	{
		public bool HasId(int id)
        {
			var hasObject = UnitOfWork.CurrentSession.Get<T>(id);
	    	return hasObject != null;
        }
		
		public List<T> GetAll()
        {
		    return UnitOfWork.CurrentSession.QueryOver<T>()
		        .CacheMode(CacheMode.Normal).Cacheable()
		        .List().ToList();
        }
		
		public T GetById(int id)
        {
            return UnitOfWork.CurrentSession.Get<T>(id);
        }
		
		public void DeleteById(int id)
        {
            UnitOfWork.CurrentSession.Delete(GetById(id));
        }
		
		public int Add(T dto)
        {
            UnitOfWork.CurrentSession.Save(dto);
			return dto.Id;
        }
		
		public void Update(T dto)
        {
            UnitOfWork.CurrentSession.Update(dto);
        }
	}
}


using System.Collections.Generic;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.Repository;
using KinderSurprise.Model;
using StructureMap;
using KinderSurprise.RepositoryImpl;

namespace KinderSurprise.MVP.Model
{
	public class BaseServices<T,TU> : IBaseServices<T>
		where T : BaseObject
		where TU : IBaseRepository<T>
	{
		public List<T> GetAll()
        {
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
    	        var repository = ObjectFactory.GetInstance<TU>();
        	    return repository.GetAll();
			}
        }
		
		public T GetById(int id)
        {
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				var repository = ObjectFactory.GetInstance<TU>();
            	return repository.GetById(id);
			}
        }
		
		public void SaveOrUpdate(T dto)
        {
            var repository = ObjectFactory.GetInstance<TU>();
			
 			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					if(repository.HasId(dto.Id))
	                	repository.Update(dto);
	            	else
	                	repository.Add(dto);
					transaction.Commit();
				}
			}
        }
		
		public void DeleteById(int id)
        {
			using (IUnitOfWork uow = UnitOfWork.Start())
			{
				using (IGenericTransaction transaction = uow.BeginTransaction())
				{
					var repository = ObjectFactory.GetInstance<TU>();
            		repository.DeleteById(id);
					transaction.Commit();
				}
			}
        }
	}
}


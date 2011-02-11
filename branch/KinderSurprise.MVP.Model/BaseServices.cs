using System.Collections.Generic;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.Repository;
using KinderSurprise.Model;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
	public class BaseServices<T,TU> : IBaseServices<T>
		where T : BaseObject
		where TU : IBaseRepository<T>
	{
		public List<T> GetAll()
        {
            var repository = ObjectFactory.GetInstance<TU>();
            return repository.GetAll();
        }
		
		public T GetById(int id)
        {
            var repository = ObjectFactory.GetInstance<TU>();
            return repository.GetById(id);
        }
		
		public void SaveOrUpdate(T dto)
        {
            var repository = ObjectFactory.GetInstance<TU>();

            if(repository.HasId(dto.Id))
                repository.Update(dto);
            else
                repository.Add(dto);
        }
		
		public void DeleteById(int id)
        {
            var repository = ObjectFactory.GetInstance<TU>();
            repository.DeleteById(id);
        }
	}
}


using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL;
using KinderSurprise.Model;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
	public class BaseServices<T,U> : IBaseServices<T>
		where T : BaseObject
		where U : BaseRepository<T>
	{
		public List<T> GetAll()
        {
            var repository = ObjectFactory.GetInstance<U>();
            return repository.GetAll();
        }
		
		public T GetById(int id)
        {
            var repository = ObjectFactory.GetInstance<U>();
            return repository.GetById(id);
        }
		
		public void SaveOrUpdate(T dto)
        {
            var repository = ObjectFactory.GetInstance<U>();

            if(repository.HasId(dto.Id))
                repository.Update(dto);
            else
                repository.Add(dto);
        }
		
		public void DeleteById(int id)
        {
            var repository = ObjectFactory.GetInstance<U>();
            repository.DeleteById(id);
        }
	}
}


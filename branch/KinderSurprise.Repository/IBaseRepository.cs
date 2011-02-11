using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.Repository
{
	public interface IBaseRepository<T> where T : BaseObject
	{
		bool HasId(int id);
		List<T> GetAll();
		T GetById(int id);
		void DeleteById(int id);
		int Add(T dto);
		void Update(T dto);
	}
}


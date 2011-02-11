using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
	public interface IBaseServices<T> where T : BaseObject
	{
		List<T> GetAll();
		T GetById(int id);
		void SaveOrUpdate(T dto);
		void DeleteById(int id);
	}
}


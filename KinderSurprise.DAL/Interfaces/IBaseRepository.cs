using System;
using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
	public interface IBaseRepository<T> where T : BaseObject
	{
		bool HasId(int id);
		List<T> GetAll();
		T GetById(int id);
		void DeleteById(int id);
		void Add(T dto);
	}
}


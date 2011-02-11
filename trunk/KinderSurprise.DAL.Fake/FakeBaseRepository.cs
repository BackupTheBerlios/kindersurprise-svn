using System;
using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Fake
{
	public class FakeBaseRepository<T> where T : BaseObject
	{
		public T GetById (int id)
		{
			throw new NotImplementedException ();
		}

		public void DeleteById (int id)
		{
			throw new NotImplementedException ();
		}

		public int Add (T dto)
		{
			throw new NotImplementedException ();
		}

		public void Update (T dto)
		{
			throw new NotImplementedException ();
		}
	}
}


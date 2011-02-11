using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Model;

namespace KinderSurprise.RepositoryImpl.Fake
{
	public class FakeBaseRepository<T> where T : BaseObject
	{
		protected Dictionary<int, T> m_Data = new Dictionary<int, T>();
		
		public bool HasId (int id)
		{
			if(m_Data.ContainsKey(id))
			{
				return true;
			}
			
			return false;
		}

		public List<T> GetAll ()
		{
			return m_Data.Select(x => x.Value).ToList();
		}

		public T GetById (int id)
		{
		    return m_Data.ContainsKey(id) ? m_Data[id] : null;
		}

	    public void DeleteById (int id)
		{
			m_Data.Remove(id);
		}

		protected int GetId(int wantedId)
		{
		    int nextFreeId = m_Data.Count + 1;

		    return wantedId <= 0 ? nextFreeId : wantedId;
		}
	}
}


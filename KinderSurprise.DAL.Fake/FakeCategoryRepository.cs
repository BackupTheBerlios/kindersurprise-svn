using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Fake
{
	public class FakeCategoryRepository : ICategoryRepository
	{
		private Dictionary<int, Category> m_Data = new Dictionary<int, Category>();
		
		public FakeCategoryRepository ()
		{
			m_Data.Add(1, new Category { Id = 1, Name = "Plastik", Description = "Alles was plaste ist"});
			m_Data.Add(2, new Category { Id = 2, Name = "Figur", Description = "Alle Figuren"});
			m_Data.Add(3, new Category { Id = 3, Name = "Zinn", Description = "Zinnfiguren"});
		}
		
		public bool HasId (int id)
		{
			if(m_Data.ContainsKey(id))
			{
				return true;
			}
			
			return false;
		}

		public List<Category> GetAll ()
		{
			List<Category> dataList = new List<Category>();
			foreach(Category element in m_Data.Values)
			{
				dataList.Add(element);
			}
			
			return dataList;
		}

		public Category GetById (int id)
		{
			if(m_Data.ContainsKey(id))
			{
				return m_Data[id];
			}
			else
			{
				return null;
			}
		}

		public void DeleteById (int id)
		{
			m_Data.Remove(id);
		}

		public int Add (Category dto)
		{
			dto.Id = GetId(dto.Id);
			m_Data.Add(dto.Id, new Category { Id = dto.Id, Name = dto.Name, Description = dto.Description });
			return dto.Id;
		}

		public void Update (Category dto)
		{
			if(dto.Id > 0)
			{
				m_Data[dto.Id].Name = dto.Name;
				m_Data[dto.Id].Description = dto.Description;
			}
			else
			{
				throw new ApplicationException();
			}
		}
		
		private int GetId(int wantedId)
		{
			int nextFreeId = m_Data.Count + 1;
			
			if(wantedId <= 0)
			{
				return nextFreeId;
			}
			else
			{
				return wantedId;
			}
		}
	}
}


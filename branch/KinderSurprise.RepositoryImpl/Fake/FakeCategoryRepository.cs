using System;
using KinderSurprise.Repository;
using KinderSurprise.Model;

namespace KinderSurprise.RepositoryImpl.Fake
{
	public class FakeCategoryRepository : FakeBaseRepository<Category>, ICategoryRepository
	{
		public FakeCategoryRepository ()
		{
			m_Data.Add(1, new Category { Id = 1, Name = "Plastik", Description = "Alles was plaste ist"});
			m_Data.Add(2, new Category { Id = 2, Name = "Figur", Description = "Alle Figuren"});
			m_Data.Add(3, new Category { Id = 3, Name = "Zinn", Description = "Zinnfiguren"});
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
	}
}


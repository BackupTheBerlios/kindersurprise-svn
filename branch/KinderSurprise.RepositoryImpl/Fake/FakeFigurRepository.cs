using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.Repository;
using KinderSurprise.Model;

namespace KinderSurprise.RepositoryImpl.Fake
{
	public class FakeFigurRepository : FakeBaseRepository<Figur>, IFigurRepository
	{
		public FakeFigurRepository ()
		{
#region data
		    m_Data.Add(1,
		               new Figur
		                   {
		                       Id = 1,
		                       Name = "PlasteFigur1",
		                       Description = "Plastefigur Serie1",
		                       Price = (decimal) 18.00,
		                       Serie = new Serie {Id = 1}
		                   });
		    m_Data.Add(2,
		               new Figur
		                   {
		                       Id = 2,
		                       Name = "PlasteFigur2",
		                       Description = "Plastefigur Serie1",
		                       Price = (decimal) 9.25,
		                       Serie = new Serie {Id = 1}
		                   });
		    m_Data.Add(3,
		               new Figur
		                   {
		                       Id = 3,
		                       Name = "PlasteFigur1",
		                       Description = "Plastefigur Serie2",
		                       Price = (decimal) 11.00,
		                       Serie = new Serie {Id = 2}
		                   });
		    m_Data.Add(4,
		               new Figur
		                   {
		                       Id = 4,
		                       Name = "PlasteFigur2",
		                       Description = "Plastefigur Serie2",
		                       Price = (decimal) 4.75,
		                       Serie = new Serie {Id = 2}
		                   });
		    m_Data.Add(5,
		               new Figur
		                   {
		                       Id = 5,
		                       Name = "Happy Hippo1",
		                       Description = "Figur",
		                       Price = (decimal) 5.11,
		                       Serie = new Serie {Id = 3}
		                   });
		    m_Data.Add(6,
		               new Figur
		                   {
		                       Id = 6,
		                       Name = "Happy Hippo2",
		                       Description = "Figur",
		                       Price = (decimal) 5.00,
		                       Serie = new Serie {Id = 3}
		                   });
		    m_Data.Add(7,
		               new Figur
		                   {
		                       Id = 7,
		                       Name = "Happy Hippo3",
		                       Description = "Figur",
		                       Price = (decimal) 5.11,
		                       Serie = new Serie {Id = 3}
		                   });
		    m_Data.Add(8,
		               new Figur
		                   {
		                       Id = 8,
		                       Name = "Mr. Sonnenschein",
		                       Description = "Figur",
		                       Price = (decimal) 11.00,
		                       Serie = new Serie {Id = 4}
		                   });
		    m_Data.Add(9,
		               new Figur
		                   {
		                       Id = 9,
		                       Name = "Zinnsoldat",
		                       Description = "Zinnfigur",
		                       Price = (decimal) 0.77,
		                       Serie = new Serie {Id = 5}
		                   });
#endregion data
		}

		public int Add (Figur dto)
		{
			dto.Id = GetId(dto.Id);
			m_Data.Add(dto.Id, new Figur { Id = dto.Id, Name = dto.Name, Description = dto.Description, Price = dto.Price, Serie = new Serie { Id = dto.Serie.Id }});
			return dto.Id;
		}
		
		public void Update (Figur dto)
		{
			if(dto.Id > 0)
			{
				m_Data[dto.Id].Name = dto.Name;
				m_Data[dto.Id].Description = dto.Description;
				m_Data[dto.Id].Price = dto.Price;
				m_Data[dto.Id].Serie = new Serie { Id = dto.Serie.Id };
			}
			else
			{
				throw new ApplicationException();
			}
		}
	
		public List<Figur> GetAllBySerieId (int serieId)
		{
			return m_Data.Where(x => x.Value.Serie.Id == serieId)
							.Select(x => x.Value).ToList();
		}
	}	
}


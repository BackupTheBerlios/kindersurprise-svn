using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
	public class PictureService : IPictureService
	{
		private List<Picture> m_Pictures;
		
		public PictureService(int id, EType type)
		{
			IPictureRepository pictureRepository = ObjectFactory.GetInstance<IPictureRepository>();
			List<Picture> pictures = pictureRepository.GetById(id, type);
			
			if(pictures == null)
				m_Pictures = new List<Picture>();
			else
				m_Pictures = pictures;			
		}
		
		public int GetSize()
		{
			return m_Pictures.Count;
		}
		
		public List<Picture> GetPictures()
		{
			return m_Pictures;
		}
	}
}

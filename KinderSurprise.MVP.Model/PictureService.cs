using System;
using System.Collections.Generic;
using KinderSurprise.Model;
using KinderSurprise.DAL;

namespace KinderSurprise.MVP.Model
{
	public class PictureService
	{
		private List<Picture> m_Pictures;
		
		public PictureService(int id, EType type)
		{
			PictureRepository pictureRepository = new PictureRepository();
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

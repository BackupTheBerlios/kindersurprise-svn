using System;
using System.Collections.Generic;
using KinderSurprise.DTO;
using KinderSurprise.DAL;

namespace KinderSurprise.MVP.Model
{
	public class PictureService
	{
		private List<PictureDto> m_PictureDtos;
		
		public PictureService(int id, EType type)
		{
			PictureRepository pictureRepository = new PictureRepository();
			List<PictureDto> pictureDtos = pictureRepository.GetById(id, type);
			
			if(pictureDtos == null)
				m_PictureDtos = new List<PictureDto>();
			else
				m_PictureDtos = pictureDtos;			
		}
		
		public int GetSize()
		{
			return m_PictureDtos.Count;
		}
		
		public List<PictureDto> GetPictures()
		{
			return m_PictureDtos;
		}
	}
}

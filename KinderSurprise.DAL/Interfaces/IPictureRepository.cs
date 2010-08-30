using System;
using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.DAL
{
	public interface IPictureRepository
	{
		List<PictureDto> GetById(int id, EType type);
	}
}

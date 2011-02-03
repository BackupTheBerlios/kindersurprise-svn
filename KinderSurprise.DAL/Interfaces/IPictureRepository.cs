using System;
using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL
{
	public interface IPictureRepository
	{
		List<Picture> GetById(int id, EType type);
	}
}

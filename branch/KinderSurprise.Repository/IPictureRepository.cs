using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.Repository
{
	public interface IPictureRepository
	{
		List<Picture> GetById(int id, EType type);
	}
}

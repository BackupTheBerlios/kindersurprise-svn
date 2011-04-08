using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
	public interface IPictureService
	{
		int GetSize();
		List<Picture> GetPictures();
	}
}


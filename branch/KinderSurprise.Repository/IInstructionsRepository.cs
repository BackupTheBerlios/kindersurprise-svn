using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.Repository
{
	public interface IInstructionsRepository
	{
		List<Instructions> GetByFigurId(int id);
	}
}

using System;
using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
	public interface IInstructionsRepository
	{
		List<Instructions> GetByFigurId(int id);
	}
}

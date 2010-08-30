using System;
using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.DAL
{
	public interface IInstructionsRepository
	{
		List<InstructionsDto> GetByFigurId(int id);
	}
}

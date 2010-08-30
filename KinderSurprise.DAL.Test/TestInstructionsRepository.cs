using System;
using NUnit.Framework;

namespace KinderSurprise.DAL.Test
{
	[TestFixture]
	public class TestInstructionsRepository
	{
		[Test]
		public void Test_GetByFigurId_IdDoesNotExist()
		{
			IInstructionsRepository instructionsRepository = new InstructionsRepository();
			var instructionsDtos = instructionsRepository.GetByFigurId(1);
			
			Assert.AreEqual(0, instructionsDtos.Count);
		}
		
		[Test]
		public void Test_GetByFigurId_Valid()
		{
			IInstructionsRepository instructionsRepository = new InstructionsRepository();
			var instructionsDtos = instructionsRepository.GetByFigurId(3);
			
			Assert.AreEqual(2, instructionsDtos[0].Id);
			Assert.AreEqual("instruction2", instructionsDtos[0].Name);
		}
	}
}

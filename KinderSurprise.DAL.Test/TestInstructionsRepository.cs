using KinderSurprise.BootStrap;
using KinderSurprise.DAL.Interfaces;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.DAL.Test
{
	[TestFixture]
	public class TestInstructionsRepository
	{
		[SetUp]
		public void Initialize()
		{
			Productive.Initialize();
		}
		
		[Test]
		public void Test_GetByFigurId_IdDoesNotExist()
		{
			IInstructionsRepository instructionsRepository = 
				ObjectFactory.GetInstance<IInstructionsRepository>();
			
			var instructions = instructionsRepository.GetByFigurId(1);
			
			Assert.AreEqual(0, instructions.Count);
		}
		
		[Test]
		public void Test_GetByFigurId_Valid()
		{
			IInstructionsRepository instructionsRepository = 
				ObjectFactory.GetInstance<IInstructionsRepository>();
			var instructions = instructionsRepository.GetByFigurId(3);
			
			Assert.AreEqual(2, instructions[0].Id);
			Assert.AreEqual("instruction2", instructions[0].Name);
		}
	}
}

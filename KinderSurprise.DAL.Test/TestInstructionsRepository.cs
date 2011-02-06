using System.Collections.Generic;
using KinderSurprise.BootStrap;
using KinderSurprise.DAL.Test;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.DAL.TestInstructionsRepos
{
	[TestFixture]
	public class WhenRequestingInstructionForFigurByIdWithoutInstruction : RepositoryBase
	{
		private IInstructionsRepository m_InstructionsRepository;
		private List<Instructions> m_Instructions;
		
		[SetUp]
		protected override void Preparation ()
		{
			m_InstructionsRepository = ObjectFactory.GetInstance<IInstructionsRepository>();
			Because();
		}
		
		protected override void Because ()
		{
			m_Instructions = m_InstructionsRepository.GetByFigurId(1);
		}
		
		[TearDown]
		protected override void TearDown ()
		{
		}
		
		[Test]
		public void ShouldHaveNoInstructions()
		{
			Assert.AreEqual(0, m_Instructions.Count);
		}
	}
	
	[TestFixture]
	public class WhenRequestingInstructionForFigurByIdWithInstruction : RepositoryBase
	{
		private IInstructionsRepository m_InstructionsRepository;
		private List<Instructions> m_Instructions;
		
		[SetUp]
		protected override void Preparation ()
		{
			m_InstructionsRepository = ObjectFactory.GetInstance<IInstructionsRepository>();
			Because();
		}
		
		protected override void Because ()
		{
			m_Instructions = m_InstructionsRepository.GetByFigurId(3);
		}
		
		[TearDown]
		protected override void TearDown ()
		{
		}
		
		[Test]
		public void ShouldHaveInstructions()
		{
			Assert.AreEqual(2, m_Instructions[0].Id);
			Assert.AreEqual("instruction2", m_Instructions[0].Name);
		}
	}
}

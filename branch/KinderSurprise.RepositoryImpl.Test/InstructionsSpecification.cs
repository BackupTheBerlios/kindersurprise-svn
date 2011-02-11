using System.Collections.Generic;
using KinderSurprise.Model;
using KinderSurprise.Repository;
using KinderSurprise.RepositoryImpl.Test;
using NUnit.Framework;
using StructureMap;

namespace KinderSurprise.RepositoryImpl.TestInstructionsRepos
{
	[TestFixture]
	public class WhenRequestingInstructionForFigurByIdWithoutInstruction : RepositoryFixture
	{
		private IInstructionsRepository m_InstructionsRepository;
		private List<Instructions> m_Instructions;
		
		protected override void Context()
		{
			m_InstructionsRepository = ObjectFactory.GetInstance<IInstructionsRepository>();
		}
		
		protected override void Because ()
		{
			m_Instructions = m_InstructionsRepository.GetByFigurId(1);
		}
		
		[Test]
		public void ShouldHaveNoInstructions()
		{
			Assert.AreEqual(0, m_Instructions.Count);
		}
	}
	
	[TestFixture]
	public class WhenRequestingInstructionForFigurByIdWithInstruction : RepositoryFixture
	{
		private IInstructionsRepository m_InstructionsRepository;
		private List<Instructions> m_Instructions;
		
		protected override void Context()
		{
			m_InstructionsRepository = ObjectFactory.GetInstance<IInstructionsRepository>();
		}
		
		protected override void Because ()
		{
			m_Instructions = m_InstructionsRepository.GetByFigurId(3);
		}
		
		[Test]
		public void ShouldHaveInstructions()
		{
			Assert.AreEqual(2, m_Instructions[0].Id);
			Assert.AreEqual("instruction2", m_Instructions[0].Name);
		}
	}
}

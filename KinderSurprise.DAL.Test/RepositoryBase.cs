using System;
using KinderSurprise.BootStrap;
using NUnit.Framework;

namespace KinderSurprise.DAL.Test
{
	public abstract class RepositoryBase
	{
		[TestFixtureSetUp]
		public void Setup()
		{
			Testing.Initialize();
		}
		
		protected abstract void Preparation();
		protected abstract void Because();
		protected abstract void TearDown();
	}
}


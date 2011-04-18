using System;
using StructureMap;
using NUnit.Framework;
using KinderSurprise.BootStrap;
using KinderSurprise.MVP.Model.Interfaces;
namespace KinderSurprise.MVP.Model.Test
{
	public abstract class ServiceFixture
	{
        [SetUp]
		public void FixtureSetupContext()
		{
			Testing.Initialize();
			ReConfigureServices();
            
			Context();
            Because();
		}

        [TearDown]
        public void FixtureTearDown()
        {
			Testing.ResetMocks();
        }

        protected abstract void Context();
        protected abstract void Because();
	    protected abstract void TearDownContext();
		
		private void ReConfigureServices()
		{
			ObjectFactory.Configure(x => x.For<ICategoryService>().Use<CategoryService>());
		}
	}
}


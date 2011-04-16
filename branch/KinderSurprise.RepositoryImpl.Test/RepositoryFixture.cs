using KinderSurprise.BootStrap;
using NUnit.Framework;

namespace KinderSurprise.RepositoryImpl.Test
{
	public abstract class RepositoryFixture
	{
        [SetUp]
		public void FixtureSetupContext()
		{
			Productive.Initialize();

            Context();
            Because();
		}

        [TearDown]
        public void FixtureTearDown()
        {
            TearDownContext();
        }

        protected abstract void Context();
        protected abstract void Because();
	    protected abstract void TearDownContext();
	}
}


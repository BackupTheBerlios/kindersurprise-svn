using KinderSurprise.BootStrap;
using NUnit.Framework;

namespace KinderSurprise.RepositoryImpl.Test
{
	public class RepositoryFixture
	{
        [SetUp]
		public void SetupContext()
		{
			Testing.Initialize();

            Context();
            Because();
		}

        [TearDown]
        public void TearDown()
        {
            TearDownContext();
        }

        protected virtual void Context()
        {
        }

        protected virtual void Because()
        {
        }

	    protected virtual void TearDownContext()
	    {
	    }
	}
}


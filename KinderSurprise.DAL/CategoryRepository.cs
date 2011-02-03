using System.Collections.Generic;
using System;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;


namespace KinderSurprise.DAL
{
    public class CategoryRepository : ICategoryRepository
    {
        public bool HasId(int categoryId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var hasObject = session.Get<Category>(categoryId);

                return hasObject != null;
            }
        }

        public List<Category> GetAll()
        {
			using (ISession session = RepositoryBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Category));
				return crit.List().Cast<Category>().ToList();
	        }
		}

        public Category GetById(int categoryId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var category = session.Get<Category>(categoryId);
                return category == null
                           ? null
                           : category;
            }
        }

        public void DeleteById(int categoryId)
        {
            using(ISession session = RepositoryBase.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(GetById(categoryId));
                    transaction.Commit();
                }
            }
        }

        public void Update(Category category)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(category);
                    transaction.Commit();
                }
            }
        }

        public void Add(Category category)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(category);
                    transaction.Commit();
                }
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.DAL
{
    public class SerieRepository : ISerieRepository
    {
        public bool HasId(int serieId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var hasObject = session.Get<Serie>(serieId);
                
                return hasObject != null;
            }
        }

        public List<Serie> GetAll()
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Serie));
				return crit.List().Cast<Serie>().ToList();
            }
        }

        public Serie GetById(int serieId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                Serie serie = session.Get<Serie>(serieId);

                return serie == null
                           ? null
                           : serie;
            }
        }

        public void DeleteById(int serieId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(GetById(serieId));
                    transaction.Commit();
                }
            }
        }

        public void Add(Serie serie)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(serie);
                    transaction.Commit();
                }
            }
        }

        public List<Serie> GetAllByCategoryId(int categoryId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Serie));
				crit.Add(NHibernate.Criterion.Expression.Eq("Category.CategoryId", categoryId));
								
				return crit.List().Cast<Serie>().ToList();
			}
        }

        public void Update(Serie serie)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(serie);
                    transaction.Commit();
                }
            }
        }
    }
}

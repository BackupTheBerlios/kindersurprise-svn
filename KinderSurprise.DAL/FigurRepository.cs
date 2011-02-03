using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using NHibernate;

namespace KinderSurprise.DAL
{
    public class FigurRepository : IFigurRepository
    {
        public bool HasId(int figurId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var hasObject = session.Get<Figur>(figurId);
                
                return hasObject != null;
            }
        }

        public List<Figur> GetAll()
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Figur));
				return crit.List().Cast<Figur>().ToList();
            }
        }

        public Figur GetById(int figurId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                Figur figur = session.Get<Figur>(figurId);
             
                return figur == null
                           ? null
                           : figur;
            }
        }

        public void Add(Figur figur)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(figur);
                    transaction.Commit();
                }
            }
        }

        public List<Figur> GetAllBySerieId(int serieId)
        {
			using (ISession session = RepositoryBase.OpenSession())
            {
				ICriteria crit = session.CreateCriteria(typeof(Figur));
				crit.Add(NHibernate.Criterion.Expression.Eq("Serie.SerieId", serieId));
								
				return crit.List().Cast<Figur>().ToList();
            }
        }

        public void Update(Figur figur)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(figur);
                    transaction.Commit();
                }
            }
        }

        public void DeleteById(int figurId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(GetById(figurId));
                    transaction.Commit();
                }
            }
        }
    }
}

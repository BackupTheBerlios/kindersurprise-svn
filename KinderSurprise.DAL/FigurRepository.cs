using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.DAL.Interfaces;
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

        public List<FigurDto> GetAll()
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
				List<FigurDto> figurDtos = new List<FigurDto>();
				ICriteria crit = session.CreateCriteria(typeof(Figur));
				var figurList = crit.List().Cast<Figur>().ToList();
				
				foreach (Figur figur in figurList)
				{
					figurDtos.Add(new FigurDto(figur.FigurId, figur.FigurName, figur.Description, figur.Price, figur.Serie));
				}
					                 
				return figurDtos;
            }
        }

        public FigurDto GetById(int figurId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var figur = session.Get<Figur>(figurId);
             
                return figur == null
                           ? null
                           : new FigurDto(figur.FigurId, figur.FigurName, figur.Description,
                                          Convert.ToDecimal(figur.Price),
                                          new Serie { SerieId = figur.Serie.SerieId });
            }
        }

        public void Add(FigurDto figurDto)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(ConvertToModel(figurDto));
                    transaction.Commit();
                }
            }
        }

        public List<FigurDto> GetAllBySerieId(int serieId)
        {
			using (ISession session = RepositoryBase.OpenSession())
            {
				List<FigurDto> figurDtos = new List<FigurDto>();
				ICriteria crit = session.CreateCriteria(typeof(Figur));
				crit.Add(NHibernate.Criterion.Expression.Eq("Serie.SerieId", serieId));
								
				var figurList = crit.List().Cast<Figur>().ToList();
				
				foreach (Figur figur in figurList)
				{
					figurDtos.Add(new FigurDto(figur.FigurId, figur.FigurName, figur.Description, figur.Price, figur.Serie));
				}
					                 
				return figurDtos;
            }
        }

        public void Update(FigurDto figurDto)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(ConvertToModel(figurDto));
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
                    session.Delete(ConvertToModel(GetById(figurId)));
                    transaction.Commit();
                }
            }
        }

        private static Figur ConvertToModel(FigurDto figurDto)
        {
            return new Figur
            {
                FigurId = figurDto.FigurId,
                FigurName = figurDto.FigurName,
                Description = figurDto.Description,
                Price = figurDto.Price,
                Serie = new Serie { SerieId = figurDto.Serie.SerieId }
            };
        }
    }
}

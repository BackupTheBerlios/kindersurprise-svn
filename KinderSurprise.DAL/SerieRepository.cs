using System;
using System.Collections.Generic;
using System.Linq;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.DAL.Interfaces;
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

        public List<SerieDto> GetAll()
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                List<SerieDto> serieDtos = new List<SerieDto>();
				ICriteria crit = session.CreateCriteria(typeof(Serie));
				var serieList = crit.List().Cast<Serie>().ToList();
				
				foreach (Serie s in serieList)
				{
					serieDtos.Add(new SerieDto(s.SerieId, s.SerieName, s.Description, s.PublicationYear, s.Category ));
				}
				
				return serieDtos;
            }
        }

        public SerieDto GetById(int serieId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var s = session.Get<Serie>(serieId);

                return s == null
                           ? null
                           : new SerieDto(s.SerieId, s.SerieName, s.Description, s.PublicationYear, new Category { CategoryId = s.Category.CategoryId });
            }
        }

        public void DeleteById(int serieId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(ConvertToModel(GetById(serieId)));
                    transaction.Commit();
                }
            }
        }

        public void Add(SerieDto serieDto)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(ConvertToModel(serieDto));
                    transaction.Commit();
                }
            }
        }

        public List<SerieDto> GetAllByCategoryId(int categoryId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
				List<SerieDto> serieDtos = new List<SerieDto>();
				ICriteria crit = session.CreateCriteria(typeof(Serie));
				crit.Add(NHibernate.Criterion.Expression.Eq("Category.CategoryId", categoryId));
								
				var serieList = crit.List().Cast<Serie>().ToList();
				
				foreach (Serie serie in serieList)
				{
					serieDtos.Add(new SerieDto(serie.SerieId, serie.SerieName, serie.Description, serie.PublicationYear, serie.Category));
				}
			
				return serieDtos;
			}
        }

        public void Update(SerieDto serieDto)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(ConvertToModel(serieDto));
                    transaction.Commit();
                }
            }
        }

        private static Serie ConvertToModel(SerieDto serieDto)
        {
            var serie = new Serie
                            {
                                SerieId = serieDto.SerieId,
                                SerieName = serieDto.SerieName,
                                Description = serieDto.Description,
                                PublicationYear = serieDto.PublicationYear,
                                Category =
                                    new Category
                                        {
                                            CategoryId = serieDto.Category.CategoryId,
                                            CategoryName = serieDto.Category.CategoryName,
                                            Description = serieDto.Category.Description
                                        }
                            };
            
            return serie;
        }
    }
}

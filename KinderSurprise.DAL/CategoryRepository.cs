using System.Collections.Generic;
using System;
using System.Linq;
using KinderSurprise.DTO;
using KinderSurprise.Mapper;
using KinderSurprise.DAL.Interfaces;
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

        public List<CategoryDto> GetAll()
        {
			using (ISession session = RepositoryBase.OpenSession())
            {
				List<CategoryDto> categoryDtos = new List<CategoryDto>();
				ICriteria crit = session.CreateCriteria(typeof(Category));
				var categoryList = crit.List().Cast<Category>().ToList();
				
				foreach (Category category in categoryList)
				{
					categoryDtos.Add(new CategoryDto(category.CategoryId, category.CategoryName, category.Description));
				}
					                 
				return categoryDtos;
	        }
		}

        public CategoryDto GetById(int categoryId)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                var category = session.Get<Category>(categoryId);
                return category == null
                           ? null
                           : new CategoryDto(category.CategoryId, category.CategoryName, category.Description);
            }
        }

        public void DeleteById(int categoryId)
        {
            using(ISession session = RepositoryBase.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Delete(ConvertToModel(GetById(categoryId)));
                    transaction.Commit();
                }
            }
        }

        public void Update(CategoryDto categoryDto)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using(ITransaction transaction = session.BeginTransaction())
                {
                    session.Update(ConvertToModel(categoryDto));
                    transaction.Commit();
                }
            }
        }

        public void Add(CategoryDto categoryDto)
        {
            using (ISession session = RepositoryBase.OpenSession())
            {
                using (ITransaction transaction = session.BeginTransaction())
                {
                    session.Save(ConvertToModel(categoryDto));
                    transaction.Commit();
                }
            }
        }

        private static Category ConvertToModel(CategoryDto categoryDto)
        {
            return new Category
                       {

                           CategoryId = categoryDto.CategoryId,
                           CategoryName = categoryDto.CategoryName,
                           Description =
                               categoryDto.Description,

                       };
        }
    }
}

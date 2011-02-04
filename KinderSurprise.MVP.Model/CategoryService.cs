using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class CategoryService : ICategoryService
    {
        public List<Category> GetAll()
        {
            ICategoryRepository categoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
            return categoryRepository.GetAll();
        }

        public Category GetById(int categoryId)
        {
            ICategoryRepository categoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
            return categoryRepository.GetById(categoryId);
        }

        public void SaveOrUpdate(Category category)
        {
            ICategoryRepository categoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
            
            if(categoryRepository.HasId(category.Id))
                categoryRepository.Update(category);
            else
                categoryRepository.Add(category);

        }

        public void DeleteById(int categoryId)
        {
            ICategoryRepository categoryRepository = ObjectFactory.GetInstance<ICategoryRepository>();
            categoryRepository.DeleteById(categoryId);
        }
    }
}

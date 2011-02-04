using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;

namespace KinderSurprise.MVP.Model
{
    public class CategoryService : ICategoryService
    {
        public List<Category> GetAll()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.GetAll();
        }

        public Category GetById(int categoryId)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.GetById(categoryId);
        }

        public void SaveOrUpdate(Category category)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            
            if(categoryRepository.HasId(category.Id))
                categoryRepository.Update(category);
            else
                categoryRepository.Add(category);

        }

        public void DeleteById(int categoryId)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.DeleteById(categoryId);
        }
    }
}

using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Model
{
    public class CategoryService : ICategoryService
    {
        public List<CategoryDto> GetAll()
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.GetAll();
        }

        public CategoryDto GetById(int categoryId)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            return categoryRepository.GetById(categoryId);
        }

        public void SaveOrUpdate(CategoryDto categoryDto)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            
            if(categoryRepository.HasId(categoryDto.CategoryId))
                categoryRepository.Update(categoryDto);
            else
                categoryRepository.Add(categoryDto);

        }

        public void DeleteById(int categoryId)
        {
            ICategoryRepository categoryRepository = new CategoryRepository();
            categoryRepository.DeleteById(categoryId);
        }
    }
}

using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface ICategoryService
    {
        List<CategoryDto> GetAll();
        CategoryDto GetById(int categoryId);
        void SaveOrUpdate(CategoryDto categoryDto);
        void DeleteById(int categoryId);
    }
}

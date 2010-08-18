using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        bool HasId(int categoryId);
        List<CategoryDto> GetAll();
        CategoryDto GetById(int categoryId);
        void DeleteById(int categoryId);
        void Add(CategoryDto category);
        void Update(CategoryDto category);

    }
}

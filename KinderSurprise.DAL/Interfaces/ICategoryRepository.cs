using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
    public interface ICategoryRepository
    {
        bool HasId(int categoryId);
        List<Category> GetAll();
        Category GetById(int categoryId);
        void DeleteById(int categoryId);
        void Add(Category category);
        void Update(Category category);

    }
}

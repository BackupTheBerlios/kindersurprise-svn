using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface ICategoryService
    {
        List<Category> GetAll();
        Category GetById(int categoryId);
        void SaveOrUpdate(Category category);
        void DeleteById(int categoryId);
    }
}

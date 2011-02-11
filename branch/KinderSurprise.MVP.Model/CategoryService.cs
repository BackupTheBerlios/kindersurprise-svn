using KinderSurprise.Repository;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;

namespace KinderSurprise.MVP.Model
{
    public class CategoryService : BaseServices<Category, ICategoryRepository>, ICategoryService
    {
    }
}

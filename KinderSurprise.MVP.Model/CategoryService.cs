using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class CategoryService : BaseServices<Category, CategoryRepository>, ICategoryService
    {
    }
}

using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.Repository
{
    public interface ISerieRepository : IBaseRepository<Serie>
    {
        List<Serie> GetAllByCategoryId(int categoryId);
    }
}

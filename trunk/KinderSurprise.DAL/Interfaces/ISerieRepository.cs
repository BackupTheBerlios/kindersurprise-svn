using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
    public interface ISerieRepository : IBaseRepository<Serie>
    {
        List<Serie> GetAllByCategoryId(int categoryId);
    }
}

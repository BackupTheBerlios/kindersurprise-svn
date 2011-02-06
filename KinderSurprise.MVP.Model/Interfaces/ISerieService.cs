using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface ISerieService : IBaseServices<Serie>
    {
        List<Serie> GetAllByCategoryId(int categoryId);
    }
}

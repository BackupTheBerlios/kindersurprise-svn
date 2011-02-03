using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface ISerieService
    {
        List<Serie> GetAll();
        List<Serie> GetAllByCategoryId(int categoryId);
        Serie GetById(int serieId);
        void SaveOrUpdate(Serie serie);
        void DeleteById(int serieId);
    }
}

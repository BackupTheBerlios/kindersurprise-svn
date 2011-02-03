using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
    public interface ISerieRepository
    {
        bool HasId(int serieId);
        List<Serie> GetAll();
        Serie GetById(int serieId);
        void DeleteById(int serieId);
        void Add(Serie serie);
        List<Serie> GetAllByCategoryId(int categoryId);
        void Update(Serie serie);
    }
}

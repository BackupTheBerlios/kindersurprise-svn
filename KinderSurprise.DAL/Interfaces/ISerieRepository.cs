using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.DAL.Interfaces
{
    public interface ISerieRepository
    {
        bool HasId(int serieId);
        List<SerieDto> GetAll();
        SerieDto GetById(int serieId);
        void DeleteById(int serieId);
        void Add(SerieDto serieDto);
        List<SerieDto> GetAllByCategoryId(int categoryId);
        void Update(SerieDto serieDto);
    }
}

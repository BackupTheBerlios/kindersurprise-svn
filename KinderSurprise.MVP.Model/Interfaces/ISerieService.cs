using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface ISerieService
    {
        List<SerieDto> GetAll();
        List<SerieDto> GetAllByCategoryId(int categoryId);
        SerieDto GetById(int serieId);
        void SaveOrUpdate(SerieDto serieDto);
        void DeleteById(int serieId);
    }
}

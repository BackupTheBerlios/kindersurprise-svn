using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.DTO;


namespace KinderSurprise.MVP.Model
{
    public class SerieService : ISerieService
    {
        public List<SerieDto> GetAll()
        {
            ISerieRepository serieRepository = new SerieRepository();
            return serieRepository.GetAll();
        }

        public List<SerieDto> GetAllByCategoryId(int categoryId)
        {
            ISerieRepository serieRepository = new SerieRepository();
            return serieRepository.GetAllByCategoryId(categoryId);
        }

        public SerieDto GetById(int serieId)
        {
            ISerieRepository serieRepository = new SerieRepository();
            return serieRepository.GetById(serieId);
        }

        public void SaveOrUpdate(SerieDto serieDto)
        {
            ISerieRepository serieRepository = new SerieRepository();
            
            if(serieRepository.HasId(serieDto.SerieId))
                serieRepository.Update(serieDto);
            else
                serieRepository.Add(serieDto);
        }

        public void DeleteById(int serieId)
        {
            ISerieRepository serieRepository = new SerieRepository();
            serieRepository.DeleteById(serieId);
        }
    }
}

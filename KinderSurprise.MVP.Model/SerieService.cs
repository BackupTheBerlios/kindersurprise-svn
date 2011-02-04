using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;

namespace KinderSurprise.MVP.Model
{
    public class SerieService : ISerieService
    {
        public List<Serie> GetAll()
        {
            ISerieRepository serieRepository = new SerieRepository();
            return serieRepository.GetAll();
        }

        public List<Serie> GetAllByCategoryId(int categoryId)
        {
            ISerieRepository serieRepository = new SerieRepository();
            return serieRepository.GetAllByCategoryId(categoryId);
        }

        public Serie GetById(int serieId)
        {
            ISerieRepository serieRepository = new SerieRepository();
            return serieRepository.GetById(serieId);
        }

        public void SaveOrUpdate(Serie serie)
        {
            ISerieRepository serieRepository = new SerieRepository();
            
            if(serieRepository.HasId(serie.Id))
                serieRepository.Update(serie);
            else
                serieRepository.Add(serie);
        }

        public void DeleteById(int serieId)
        {
            ISerieRepository serieRepository = new SerieRepository();
            serieRepository.DeleteById(serieId);
        }
    }
}

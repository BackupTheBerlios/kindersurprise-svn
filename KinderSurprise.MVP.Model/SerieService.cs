using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class SerieService : ISerieService
    {
        public List<Serie> GetAll()
        {
            ISerieRepository serieRepository = ObjectFactory.GetInstance<ISerieRepository>();
            return serieRepository.GetAll();
        }

        public List<Serie> GetAllByCategoryId(int categoryId)
        {
            ISerieRepository serieRepository = ObjectFactory.GetInstance<ISerieRepository>();
            return serieRepository.GetAllByCategoryId(categoryId);
        }

        public Serie GetById(int serieId)
        {
            ISerieRepository serieRepository = ObjectFactory.GetInstance<ISerieRepository>();
            return serieRepository.GetById(serieId);
        }

        public void SaveOrUpdate(Serie serie)
        {
            ISerieRepository serieRepository = ObjectFactory.GetInstance<ISerieRepository>();
            
            if(serieRepository.HasId(serie.Id))
                serieRepository.Update(serie);
            else
                serieRepository.Add(serie);
        }

        public void DeleteById(int serieId)
        {
            ISerieRepository serieRepository = ObjectFactory.GetInstance<ISerieRepository>();
            serieRepository.DeleteById(serieId);
        }
    }
}

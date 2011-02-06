using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class SerieService : BaseServices<Serie, SerieRepository>, ISerieService
    {
        public List<Serie> GetAllByCategoryId(int categoryId)
        {
            ISerieRepository serieRepository = ObjectFactory.GetInstance<ISerieRepository>();
            return serieRepository.GetAllByCategoryId(categoryId);
        }
    }
}

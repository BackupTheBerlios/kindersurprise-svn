using System.Collections.Generic;
using KinderSurprise.Repository;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class FigurService : BaseServices<Figur, IFigurRepository>, IFigurService
    {
        public List<Figur> GetAllBySerieId(int serieId)
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();
            return figurRepository.GetAllBySerieId(serieId);
        }
    }
}

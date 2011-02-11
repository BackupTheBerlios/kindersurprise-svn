using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class FigurService : BaseServices<Figur, FigurRepository>, IFigurService
    {
        public List<Figur> GetAllBySerieId(int serieId)
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();
            return figurRepository.GetAllBySerieId(serieId);
        }
    }
}

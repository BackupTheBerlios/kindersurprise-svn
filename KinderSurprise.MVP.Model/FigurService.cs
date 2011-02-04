using System.Collections.Generic;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;
using StructureMap;

namespace KinderSurprise.MVP.Model
{
    public class FigurService : IFigurService
    {
        public List<Figur> GetAll()
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();
            return figurRepository.GetAll();
        }

        public List<Figur> GetAllBySerieId(int serieId)
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();
            return figurRepository.GetAllBySerieId(serieId);
        }

        public Figur GetById(int figurId)
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();
            return figurRepository.GetById(figurId);
        }

        public void SaveOrUpdate(Figur figur)
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();

            if(figurRepository.HasId(figur.Id))
                figurRepository.Update(figur);
            else
                figurRepository.Add(figur);
        }

        public void DeleteById(int figurId)
        {
            IFigurRepository figurRepository = ObjectFactory.GetInstance<IFigurRepository>();
            figurRepository.DeleteById(figurId);
        }
    }
}

using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.Model;
using KinderSurprise.MVP.Model.Interfaces;

namespace KinderSurprise.MVP.Model
{
    public class FigurService : IFigurService
    {
        public List<Figur> GetAll()
        {
            IFigurRepository figurRepository = new FigurRepository();
            return figurRepository.GetAll();
        }

        public List<Figur> GetAllBySerieId(int serieId)
        {
            IFigurRepository figurRepository = new FigurRepository();
            return figurRepository.GetAllBySerieId(serieId);
        }

        public Figur GetById(int figurId)
        {
            IFigurRepository figurRepository = new FigurRepository();
            return figurRepository.GetById(figurId);
        }

        public void SaveOrUpdate(Figur figur)
        {
            IFigurRepository figurRepository = new FigurRepository();

            if(figurRepository.HasId(figur.FigurId))
                figurRepository.Update(figur);
            else
                figurRepository.Add(figur);
        }

        public void DeleteById(int figurId)
        {
            IFigurRepository figurRepository = new FigurRepository();
            figurRepository.DeleteById(figurId);
        }
    }
}

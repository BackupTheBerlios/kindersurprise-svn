using System.Collections.Generic;
using KinderSurprise.DAL;
using KinderSurprise.DAL.Interfaces;
using KinderSurprise.MVP.Model.Interfaces;
using KinderSurprise.DTO;


namespace KinderSurprise.MVP.Model
{
    public class FigurService : IFigurService
    {
        public List<FigurDto> GetAll()
        {
            IFigurRepository figurRepository = new FigurRepository();
            return figurRepository.GetAll();
        }

        public List<FigurDto> GetAllBySerieId(int serieId)
        {
            IFigurRepository figurRepository = new FigurRepository();
            return figurRepository.GetAllBySerieId(serieId);
        }

        public FigurDto GetById(int figurId)
        {
            IFigurRepository figurRepository = new FigurRepository();
            return figurRepository.GetById(figurId);
        }

        public void SaveOrUpdate(FigurDto figurDto)
        {
            IFigurRepository figurRepository = new FigurRepository();

            if(figurRepository.HasId(figurDto.FigurId))
                figurRepository.Update(figurDto);
            else
                figurRepository.Add(figurDto);
        }

        public void DeleteById(int figurId)
        {
            IFigurRepository figurRepository = new FigurRepository();
            figurRepository.DeleteById(figurId);
        }
    }
}

using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface IFigurService
    {
        List<FigurDto> GetAll();
        List<FigurDto> GetAllBySerieId(int serieId);
        FigurDto GetById(int figurId);
        void SaveOrUpdate(FigurDto figurDto);
        void DeleteById(int figurId);
    }
}

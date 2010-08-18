using System.Collections.Generic;
using KinderSurprise.DTO;

namespace KinderSurprise.DAL.Interfaces
{
    public interface IFigurRepository
    {
        bool HasId(int figurId);
        List<FigurDto> GetAll();
        FigurDto GetById(int figurId);
        void DeleteById(int figurId);
        void Add(FigurDto figurDto);
        List<FigurDto> GetAllBySerieId(int serieId);
        void Update(FigurDto figurDto);
    }
}

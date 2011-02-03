using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface IFigurService
    {
        List<Figur> GetAll();
        List<Figur> GetAllBySerieId(int serieId);
        Figur GetById(int figurId);
        void SaveOrUpdate(Figur figur);
        void DeleteById(int figurId);
    }
}

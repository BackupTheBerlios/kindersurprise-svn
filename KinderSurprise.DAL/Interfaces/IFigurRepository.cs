using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
    public interface IFigurRepository
    {
        bool HasId(int figurId);
        List<Figur> GetAll();
        Figur GetById(int figurId);
        void DeleteById(int figurId);
        void Add(Figur figur);
        List<Figur> GetAllBySerieId(int serieId);
        void Update(Figur figur);
    }
}

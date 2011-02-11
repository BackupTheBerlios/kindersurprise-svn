using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.DAL.Interfaces
{
    public interface IFigurRepository : IBaseRepository<Figur>
    {
        List<Figur> GetAllBySerieId(int serieId);
    }
}

using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.Repository
{
    public interface IFigurRepository : IBaseRepository<Figur>
    {
        List<Figur> GetAllBySerieId(int serieId);
    }
}

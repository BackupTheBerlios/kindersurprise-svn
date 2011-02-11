using System.Collections.Generic;
using KinderSurprise.Model;

namespace KinderSurprise.MVP.Model.Interfaces
{
    public interface IFigurService : IBaseServices<Figur>
    {
        List<Figur> GetAllBySerieId(int serieId);
    }
}

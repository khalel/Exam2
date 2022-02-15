using QLESS.Domain.Model;
using System.Collections.Generic;

namespace QLESS.Domain.Repository
{
    public interface ICardLoadHistRepository : IGenericRepository<CardLoadHist>
    {
        IEnumerable<CardLoadHist> GetCardLoadHists();
        CardLoadHist AddCardLoadHist(CardLoadHist card);
    }
}

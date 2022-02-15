using QLESS.Domain.Model;
using System.Collections.Generic;

namespace QLESS.Domain.Repository
{
    public interface ICardRegTypeRepository : IGenericRepository<CardRegType>
    {
        IEnumerable<CardRegType> GetCardRegTypes();
    }
}

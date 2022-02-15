using QLESS.Domain.Model;
using QLESS.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace QLESS.Data.Repository
{
    public class CardRegTypeRepository : GenericRepository<CardRegType>, ICardRegTypeRepository
    {
        public CardRegTypeRepository(QLESSContext context) : base(context)
        {
        }

        public IEnumerable<CardRegType> GetCardRegTypes()
        {
            return _context.CardRegTypes.ToList();
        }
    }
}

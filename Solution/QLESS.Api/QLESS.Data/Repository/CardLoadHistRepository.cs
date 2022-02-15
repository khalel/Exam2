using QLESS.Domain.Model;
using QLESS.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace QLESS.Data.Repository
{
    public class CardLoadHistRepository : GenericRepository<CardLoadHist>, ICardLoadHistRepository
    {
        public CardLoadHistRepository(QLESSContext context) : base(context)
        {
        }

        public IEnumerable<CardLoadHist> GetCardLoadHists()
        {
            return _context.CardLoadHists.ToList();
        }

        public CardLoadHist AddCardLoadHist(CardLoadHist cardLoadHist)
        {
            _context.Add(cardLoadHist);
            _context.SaveChanges();

            return cardLoadHist;
        }
    }
}

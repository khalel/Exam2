using QLESS.Domain.Model;
using QLESS.Domain.Repository;
using System.Collections.Generic;
using System.Linq;

namespace QLESS.Data.Repository
{
    public class CardRepository : GenericRepository<Card>, ICardRepository
    {
        public CardRepository(QLESSContext context) : base(context)
        {
        }

        public IEnumerable<Card> GetCards()
        {
            return _context.Cards.ToList();
        }

        public Card AddCard(Card card)
        {
            _context.Add(card);
            _context.SaveChanges();

            return card;
        }

        public Card UpdateCard(Card card)
        {
            _context.Update(card);
            _context.SaveChanges();

            return card;
        }

        public Card GetCardBySerialNumber(string serialNumber)
        {
            return _context
                .Cards
                .Where(q => q.SerialNumber.Equals(serialNumber))
                .SingleOrDefault();
        }

    }
}

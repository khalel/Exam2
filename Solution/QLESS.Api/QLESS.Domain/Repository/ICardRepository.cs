using QLESS.Domain.Model;
using System.Collections.Generic;

namespace QLESS.Domain.Repository
{
    public interface ICardRepository : IGenericRepository<Card>
    {
        IEnumerable<Card> GetCards();
        Card AddCard(Card card);
        Card UpdateCard(Card card);
        Card GetCardBySerialNumber(string serialNumber);
    }
}

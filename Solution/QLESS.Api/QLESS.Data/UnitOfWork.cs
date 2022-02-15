using QLESS.Data.Repository;
using QLESS.Domain;
using QLESS.Domain.Repository;

namespace QLESS.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        public ICardRepository Cards { get; private set; }
        public ICardRegTypeRepository CardRegTypes { get; private set; }
        public ICardLoadHistRepository CardLoadHists { get; private set; }

        private readonly QLESSContext _context;

        public UnitOfWork(QLESSContext context)
        {
            _context = context;
            Cards = new CardRepository(_context);
            CardRegTypes = new CardRegTypeRepository(_context);
            CardLoadHists = new CardLoadHistRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}

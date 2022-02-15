using QLESS.Domain.Repository;
using System;

namespace QLESS.Domain
{
    public interface IUnitOfWork : IDisposable
    {
        ICardRepository Cards { get; }
        ICardRegTypeRepository CardRegTypes { get; }
        ICardLoadHistRepository CardLoadHists { get; }
        int Complete();
    }
}

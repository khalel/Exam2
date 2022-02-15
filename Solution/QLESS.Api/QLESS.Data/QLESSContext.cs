using Microsoft.EntityFrameworkCore;
using QLESS.Domain.Model;

namespace QLESS.Data
{
    public class QLESSContext : DbContext
    {
        public QLESSContext(DbContextOptions<QLESSContext> options) : base(options)
        {
        }

        public DbSet<CardRegType> CardRegTypes { get; set; }
        public DbSet<Card> Cards { get; set; }
        public DbSet<CardLoadHist> CardLoadHists { get; set; }
    }
}

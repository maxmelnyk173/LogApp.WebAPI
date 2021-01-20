using LogApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace LogApp.Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        public DbSet<Business> Businesses { get; set; }

        public DbSet<Carrier> Carriers { get; set; }

        public DbSet<Export> Exports { get; set; }

        public DbSet<Import> Imports { get; set; }

        public DbSet<Order> Orders { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

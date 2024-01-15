using Microsoft.EntityFrameworkCore;
using Versta24.Domain;

namespace Versta24.Application.interfaces
{
    public interface IOrdersDbContext
    {
        DbSet<Order> Orders { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}

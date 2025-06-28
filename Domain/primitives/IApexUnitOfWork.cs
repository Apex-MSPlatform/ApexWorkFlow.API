

namespace Domain.primitives
{
    public interface IApexUnitOfWork
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}

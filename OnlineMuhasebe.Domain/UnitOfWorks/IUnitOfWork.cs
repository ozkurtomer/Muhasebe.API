namespace OnlineMuhasebe.Domain;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken token = default);
}

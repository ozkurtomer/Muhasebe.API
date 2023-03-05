namespace OnlineMuhasebe.Domain.UnitOfWorks;

public interface IUnitOfWork
{
    Task<int> SaveChangesAsync(CancellationToken token);
}

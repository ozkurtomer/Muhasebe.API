using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    void SetDbContextInstance(DbContext dbContext);
    DbSet<TEntity> Entity { get; set; }
}

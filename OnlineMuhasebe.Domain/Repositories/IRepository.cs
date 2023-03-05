using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface IRepository<TEntity> where TEntity : Entity
{
    DbSet<TEntity> Entity { get; set; }
}

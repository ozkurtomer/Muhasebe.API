﻿using Microsoft.EntityFrameworkCore;
using OnlineMuhasebe.Domain.Abstractions;

namespace OnlineMuhasebe.Domain.Repositories;

public interface ICompanyRepository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    void SetDbContextInstance(DbContext dbContext);
}

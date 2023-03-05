﻿using OnlineMuhasebe.Domain.UnitOfWorks;
using OnlineMuhasebe.Persistence.Context;

namespace OnlineMuhasebe.Persistence.UnitOfWorks;

public sealed class AppUnitOfWork : IAppUnitOfWork
{
    private readonly AppDbContext Context;
    public async Task<int> SaveChangesAsync(CancellationToken token)
    {
        return await Context.SaveChangesAsync(token);
    }
}
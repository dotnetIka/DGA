﻿using System;
namespace Infrastructure.Repositories.Interfaces
{
	public interface IUnitOfWork
	{
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}


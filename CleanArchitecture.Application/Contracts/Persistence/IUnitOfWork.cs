﻿using CleanArchitecture.Domain.Common;

namespace CleanArchitecture.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {

        IVideoRepository VideoRepository { get; }
        IStreamerRepository StreamerRepository { get; }
        
        IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel;


        Task<int> Complete();


    }
}

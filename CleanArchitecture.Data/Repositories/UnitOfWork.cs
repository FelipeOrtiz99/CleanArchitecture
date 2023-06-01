﻿using CleanArchitecture.Application.Contracts.Persistence;
using CleanArchitecture.Domain.Common;
using CleanArchitecture.Infrastructure.Persistence;
using System.Collections;

namespace CleanArchitecture.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private Hashtable _repositories;
        private readonly StreamerDbContext _context;
        private IVideoRepository videoRepository;
        private IStreamerRepository streamerRepository;


        public IVideoRepository VideoRepository => videoRepository ??= new VideoRepository(_context);
        public IStreamerRepository StreamerRepository => streamerRepository ??= new StreamerRepository(_context);

        public UnitOfWork(StreamerDbContext context)
        {
            _context = context;
        }

        public StreamerDbContext StreamerDbContext => _context;

        public async Task<int> Complete()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public IAsyncRepository<TEntity> Repository<TEntity>() where TEntity : BaseDomainModel
        {
            if (_repositories == null)
            {
                _repositories = new Hashtable();
            }

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type)) 
            { 
            
                var repositoryType = typeof(RepositoryBase<>);
                var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(TEntity)), _context);
                _repositories.Add(type, repositoryInstance);

            }
            return (IAsyncRepository<TEntity>)_repositories[type];
        }
    }
}

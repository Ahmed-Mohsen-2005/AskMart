using Domain.Interfaces.GenericrRepositoryInterfaces;
using Domain.Interfaces.UnitOfWorkInterfaces;
using Infrastructure.Repository.Implementations;

namespace Infrastructure.UnitOfWorkImplementation
{
    public partial class UnitOfWork : IRepositoryUnitOfWork
    {

        public IGenericRepository<T> GetRepository<T>() where T : class
        {
            var type = typeof(T);

            // Check if repository already exists in the cache
            if (_repositories.ContainsKey(type))
            {
                return (IGenericRepository<T>)_repositories[type];
            }

            // Fallback to generic repository
            var genericRepository = new GenericRepository<T>(_context);
            _repositories.Add(type, genericRepository);
            return genericRepository;
        }

    }
}


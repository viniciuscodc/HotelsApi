using System;
using HotelsApi.Data;
using System.Threading.Tasks;


namespace HotelsApi.IRepository
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<Country> Countries { get; }

        IGenericRepository<Hotel> Hotels { get; }

        Task Save();
    }
}
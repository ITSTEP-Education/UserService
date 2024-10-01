using UserService.DAL.Entities;

namespace UserService.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<OrderDetail> orderDetails { get; }

        public void Save();
    }
}

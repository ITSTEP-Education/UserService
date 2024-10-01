using UserService.DAL.Entities;

namespace UserService.DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IRepository<OrderDetail> orderDetails { get; }
        public IRepository<ClientData> clientsData { get; }

        public void Save();
    }
}

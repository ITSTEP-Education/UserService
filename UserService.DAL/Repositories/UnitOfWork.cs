using UserService.DAL.EF;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserContext context;
        private OrderDetailRepository orderDetailRepository = null!;
        private ClientDataRepository clientsDataRepository = null!;

        private bool disposed = false;

        public UnitOfWork(UserContext context)
        {
            this.context = context;
        }

        public IRepository<OrderDetail> orderDetails
        {
            get
            {
                if (orderDetailRepository == null)
                    orderDetailRepository = new OrderDetailRepository(context);
                return orderDetailRepository;
            }
        }

        public IRepository<ClientData> clientsData
        {
            get
            {
                if (clientsDataRepository == null)
                    clientsDataRepository = new ClientDataRepository(context);
                return clientsDataRepository;
            }
        }

        public void Save()
        {
            context.SaveChanges();
        }

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}

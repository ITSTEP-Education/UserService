using UserService.DAL.EF;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;
using UserService.DAL.Repositories;

namespace AdminService.DAL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private UserContext context;
        private OrderDetailRepository orderDetailRepository = null!;

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

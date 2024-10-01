using UserService.BLL.Interfaces;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Services
{
    public class OrderDetailService : IOrderDetailService
    {
        public IUnitOfWork db { get; }

        public OrderDetailService(IUnitOfWork db)
        {
            this.db = db;
        }

        public IEnumerable<OrderDetail> getOrderDetails(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            return db.orderDetails.getItems(name);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

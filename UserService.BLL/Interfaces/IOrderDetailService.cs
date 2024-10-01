using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Interfaces
{
    public interface IOrderDetailService
    {
        IUnitOfWork db { get; }

        IEnumerable<OrderDetail> getOrderDetails(string? name);

        void Dispose();
    }
}

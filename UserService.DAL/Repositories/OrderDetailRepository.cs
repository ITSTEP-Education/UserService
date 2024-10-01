using UserService.DAL.EF;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;
using AdminService.DAL.Infrastructures;

namespace UserService.DAL.Repositories
{
    public class OrderDetailRepository : IRepository<OrderDetail>
    {
        public UserContext context;

        public OrderDetailRepository(UserContext context)
        {
            this.context = context;
        }

        public IEnumerable<OrderDetail> getItems(string name)
        {                  
            var orderDetails = (from order in this.context.orderDetails
                          where order.name == name.ToLower()
                          select order);

            if (orderDetails == null || orderDetails.Count() == 0) throw new StatusCode404(name);

            return orderDetails;
        }

    }
}

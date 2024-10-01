using UserService.BLL.BusisinesModel;
using UserService.BLL.Interfaces;
using UserService.DAL.Infrastructures;
using UserService.DAL.Interfaces;
using UserService.Model;

namespace UserService.BLL.Services
{
    public class ClientDataService : IClientDataService
    {
        public IUnitOfWork db { get; }

        public ClientDataService(IUnitOfWork db)
        {
            this.db = db;
        }

        public ClientCourseData getClientData(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            var clientData = db.clientsData.getItem(name);

            if (clientData.clientOrder == null) throw new StatusCode404("ClientOrder");

            var clientCourseData = new ClientCourseData() { 
                userName = clientData.firstName + " " + clientData.lastName,
                age = clientData.age,
                phone = clientData.mobile,
                productName = clientData.clientOrder.name,
                typeEngeeniring = clientData.clientOrder.typeEngeeniring,
                mounthPay = new MonthPayment(clientData.clientOrder.sumPay, clientData.clientOrder.timeStudy).getMountрPay(),
                mounthQty = clientData.clientOrder.timeStudy,
            };

            return clientCourseData;
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

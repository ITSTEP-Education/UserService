using UserService.BLL.Interfaces;
using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Services
{
    public class ClientDataService : IClientDataService
    {
        public IUnitOfWork db { get; }

        public ClientDataService(IUnitOfWork db)
        {
            this.db = db;
        }

        public ClientData getClientData(string? name)
        {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));

            return db.clientsData.getItem(name);
        }

        public void Dispose()
        {
            db?.Dispose();
        }
    }
}

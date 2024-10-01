using UserService.DAL.Entities;
using UserService.DAL.Interfaces;

namespace UserService.BLL.Interfaces
{
    public interface IClientDataService
    {
        IUnitOfWork db { get; }

        ClientData getClientData(string? name);

        void Dispose();
    }
}

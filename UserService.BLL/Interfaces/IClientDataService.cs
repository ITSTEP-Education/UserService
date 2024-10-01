using UserService.DAL.Entities;
using UserService.DAL.Interfaces;
using UserService.Model;

namespace UserService.BLL.Interfaces
{
    public interface IClientDataService
    {
        IUnitOfWork db { get; }

        ClientCourseData getClientData(string? name);

        void Dispose();
    }
}

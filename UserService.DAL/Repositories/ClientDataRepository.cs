using UserService.DAL.EF;
using UserService.DAL.Entities;
using UserService.DAL.Infrastructures;
using UserService.DAL.Interfaces;

namespace UserService.DAL.Repositories
{
    public class ClientDataRepository : IRepository<ClientData>
    {
        public UserContext context;

        public ClientDataRepository(UserContext context)
        {
            this.context = context;
        }

        public IEnumerable<ClientData> getItems(string name) 
        { 
            throw new NotImplementedException("blank method of IRepository<ClientData>");
        }

        public ClientData getItem(string name)
        {
            (string firstName, string lastName) = getFirstLastName(name);

            ClientData? clientData = this.context.clientsData.FirstOrDefault(cd => (cd.firstName.Equals(firstName) && cd.lastName.Equals(lastName)));
            if (clientData == null) throw new StatusCode404(name);

            return clientData;
        }

        private (string, string) getFirstLastName(string name)
        {
            var names = name.ToLower().Split('-');

            if(names.Length != 2) throw new StatusCode400(name);

            return (names[0], names[1]);
        }
    }
}

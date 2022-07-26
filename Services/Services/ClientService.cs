using DatabaseConnection.Interfaces;
using Entities;
using Entities.Model;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services
{
    public class ClientService : IClientService
    {
        private IClientDAL _clientDAL;
        public ClientService(IClientDAL clientDAL)
        {
            _clientDAL = clientDAL;
        }

        public List<Client> GetAllClients()
        {
            return _clientDAL.GetAllClients();
        }

        public List<Invoice> GetClientInvoices(int clientID)
        {
            return _clientDAL.GetClientInvoices(clientID);
        }
    }
}

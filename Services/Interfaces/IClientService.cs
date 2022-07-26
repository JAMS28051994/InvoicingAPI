using Entities;
using Entities.Model;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IClientService
    {
        public List<Invoice> GetClientInvoices(int clientId);
        public List<Client> GetAllClients();
    }
}

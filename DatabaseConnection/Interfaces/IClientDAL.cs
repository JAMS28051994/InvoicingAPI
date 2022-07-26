using Entities;
using Entities.Model;
using System.Collections.Generic;

namespace DatabaseConnection.Interfaces
{
    public interface IClientDAL
    {
        public List<Client> GetAllClients();
        public List<Invoice> GetClientInvoices(int clientId);
    }
}

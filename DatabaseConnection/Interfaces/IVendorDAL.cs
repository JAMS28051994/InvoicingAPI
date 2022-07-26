using Entities;
using System.Collections.Generic;

namespace DatabaseConnection.Interfaces
{
    public interface IVendorDAL
    {
        public List<Vendor> GetAllVendors();
    }
}

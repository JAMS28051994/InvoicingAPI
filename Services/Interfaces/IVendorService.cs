using Entities;
using System.Collections.Generic;

namespace Services.Interfaces
{
    public interface IVendorService
    {
        public List<Vendor> GetAllVendors();
    }
}

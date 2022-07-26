using DatabaseConnection.Interfaces;
using Entities;
using Services.Interfaces;
using System.Collections.Generic;

namespace Services.Services
{
    public class VendorService : IVendorService
    {
        private IVendorDAL _vendorDAL;

        public VendorService(IVendorDAL vendorDAL)
        {
            _vendorDAL = vendorDAL;
        }

        public List<Vendor> GetAllVendors()
        {
            return _vendorDAL.GetAllVendors();
        }
    }
}

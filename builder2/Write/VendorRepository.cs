using System;
using System.Collections.Generic;
using CreationalPatterns.Builder2.Catalog;

namespace CreationalPatterns.Builder2.Write
{
    public class VendorRepository
    {
        private readonly Dictionary<Guid, Vendor> _vendors = new()
        {
            { Vendor.PepsiCo.Id, Vendor.PepsiCo }
        };

        public Vendor Find(Guid id) => _vendors[id];
    }
}

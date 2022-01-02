using System;
using System.Collections.Generic;
using DesignPatterns.Builder2.Catalog;

namespace DesignPatterns.Builder2.Write
{
    public class VendorRepository
    {
        private readonly Dictionary<Guid, Vendor> _vendors = new()
        {
            { Vendor.PepsiCo.Id, Vendor.PepsiCo }
        };

        #region Public Interface

        public Vendor Find(Guid id) => _vendors[id];

        #endregion
    }
}

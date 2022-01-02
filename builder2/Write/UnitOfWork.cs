namespace DesignPatterns.Builder2.Write
{
    public class UnitOfWork
    {
        private VendorRepository _vendors;

        #region Public Interface

        public VendorRepository Vendors => _vendors ??= new VendorRepository();

        #endregion
    }
}

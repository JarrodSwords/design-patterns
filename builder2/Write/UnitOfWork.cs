namespace CreationalPatterns.Builder2.Write
{
    public class UnitOfWork
    {
        private VendorRepository _vendors;

        public VendorRepository Vendors => _vendors ??= new VendorRepository();
    }
}

namespace CarDealer.Services
{
    using Models.Suppliers;
    using System.Collections.Generic;

    public interface ISupplierService
    {
        IEnumerable<SupplierListingModel> AllListings(bool isImporter);

        IEnumerable<SupplierModel> All();
    }
}
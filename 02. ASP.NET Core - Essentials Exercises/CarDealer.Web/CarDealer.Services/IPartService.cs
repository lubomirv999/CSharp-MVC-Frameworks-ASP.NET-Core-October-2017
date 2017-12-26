namespace CarDealer.Services
{
    using Models.Parts;
    using System.Collections.Generic;

    public interface IPartService
    {
        IEnumerable<PartListingModel> AllListings(int page = 1, int pageSize = 10);

        IEnumerable<PartBasicModel> All();

        PartDetailsModel ById(int id);

        void Create(string name, decimal price, int quantity, int supplierId);

        void Edit(int id, decimal price, int quantity);

        void Delete(int id);

        int Total();
    }
}

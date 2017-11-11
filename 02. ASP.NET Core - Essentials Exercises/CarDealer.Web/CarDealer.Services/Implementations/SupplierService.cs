namespace CarDealer.Services.Implementations
{
    using Data;
    using Models;
    using System.Collections.Generic;
    using System.Linq;

    public class SupplierService : ISupplierService
    {
        private readonly CarDealerDbContext db;

        public SupplierService(CarDealerDbContext db)
        {
            this.db = db;
        }

        public IEnumerable<SupplierModel> All(bool isImporter)
            => this.db
                .Suppliers
            .Where(s => s.IsImporter == isImporter)
            .Select(s => new SupplierModel
            {
                Id = s.Id,
                Name = s.Name,
                TotalParts = s.Parts.Count
            })
            .ToList();
    }
}
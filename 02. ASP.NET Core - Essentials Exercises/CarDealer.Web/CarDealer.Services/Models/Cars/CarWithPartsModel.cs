namespace CarDealer.Services.Models.Cars
{
    using Parts;
    using System.Collections.Generic;

    public class CarWithPartsModel : CarModel
    {
        public IEnumerable<PartModel> Parts { get; set; }
    }
}

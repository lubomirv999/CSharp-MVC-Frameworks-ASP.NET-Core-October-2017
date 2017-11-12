namespace CarDealer.Web.Models.Parts
{
    using Services.Models.Parts;
    using System.Collections.Generic;

    public class PartPageListingModel
    {
        public IEnumerable<PartListingModel> Parts { get; set; }

        public int CurrentPage { get; set; }

        public int Totalpages { get; set; }

        public int PreviousPage => this.CurrentPage == 1 
            ? 1 
            : this.CurrentPage - 1;

        public int NextPage => this.CurrentPage == this.Totalpages 
            ? this.Totalpages 
            : this.CurrentPage + 1;
    }
}
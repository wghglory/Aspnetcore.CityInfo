using System.Collections.Generic;
using Aspnetcore.CityInfo.Api.Entities;

namespace Aspnetcore.CityInfo.Api.ViewModels
{
    public class CityViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<PointOfInterestViewModel> PointsOfInterest { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Aspnetcore.CityInfo.Api.ViewModels
{
    public class PointOfInterestViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "You should provide a name value.")]
        [MaxLength(50)]
        public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "maxlength should less than 200 characters.")]
        public string Description { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace DevSpot.ViewModels
{
    public class JobPostingsViewModel
    {
        [Required]
        public string Title { get; set; }
        [Required]
        public string Description { get; set; }
        [Required]
        public string Company { get; set; }
        [Required]
        public string Location { get; set; }
    }
}

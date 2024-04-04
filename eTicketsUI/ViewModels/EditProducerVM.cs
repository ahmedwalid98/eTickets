using System.ComponentModel.DataAnnotations;

namespace eTicketsUI.ViewModels
{
    public class EditProducerVM
    {
        [Required(ErrorMessage = "Profile Picture is required")]
        public string ProfilePictureUrl { get; set; }
        [Required(ErrorMessage = "Full name is required")]
        [Length(3, 50, ErrorMessage = "Nam must be between 3 - 50 chars")]
        public string FullName { get; set; }
        [Required(ErrorMessage = "Bio is required")]
        public string Bio { get; set; }
    }
}

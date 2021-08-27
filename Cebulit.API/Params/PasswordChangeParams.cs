using System.ComponentModel.DataAnnotations;

namespace Cebulit.API.Params
{
    public class PasswordChangeParams
    {
        [Required]
        [MinLength(6)]
        public string CurrentPassword { get; set; }
        [Required]
        [MinLength(6)]
        public string NewPassword { get; set; }
    }
}
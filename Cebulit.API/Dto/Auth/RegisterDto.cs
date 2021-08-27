using System.ComponentModel.DataAnnotations;

namespace Cebulit.API.Dto.Auth
{
    public class RegisterDto
    {
        [Required]
        [MinLength(4)]
        public string Login { get; set; }
        [Required]
        [MinLength(6)]
        public string Password { get; set; }
    }
}
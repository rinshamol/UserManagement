using System.ComponentModel.DataAnnotations;

namespace UserManagementApi.Dtos
{
    public class UserUpdateDto
    {
        [Required]
        [StringLength(100, MinimumLength = 2)]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        [StringLength(150)]
        public string Email { get; set; } = string.Empty;

        [Range(1, 120)]
        public int Age { get; set; }
    }
}

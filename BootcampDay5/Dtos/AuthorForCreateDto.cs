using BootcampDay5.ValidationAttributes;
using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Dtos
{
    [AuthorFirstLastMustBeDifferent]
    public class AuthorForCreateDto
    {
        [Required]
        [MaxLength(50)]
        public string FirstName { get; set; }
        [Required]
        [MaxLength(50)]
        public string LastName { get; set; }
        [Required]
        public System.DateTime DateOfBirth { get; set; }
        [Required]
        [MaxLength(50)]
        public string MainCategory { get; set; }
    }
}

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Dtos
{
    public class CourseForCreateDto
    {
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }
        [Required]
        public int AuthorId { get; set; }
    }
}

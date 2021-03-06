using System.ComponentModel.DataAnnotations;

namespace BootcampDay5.Models
{
    public class Course
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string Title { get; set; }
        [Required]
        [MaxLength(500)]
        public string Description { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }
    }
}

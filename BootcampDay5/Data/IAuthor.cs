using BootcampDay5.Dtos;
using BootcampDay5.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BootcampDay5.Data
{
    public interface IAuthor : ICrud<Author>
    {
        Task<IEnumerable<Author>> GetCourseByAuthor(string name);
    }
}

using BootcampDay5.Models;
using System;
using System.Linq;

namespace BootcampDay5.Data
{
    public static class DbInit
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            if (context.Authors.Any())
            {
                return;
            }

            var author = new Author[]
            {
                new Author{FirstName="Irfhando",LastName="Mahendra",DateOfBirth=DateTime.Parse("2000-1-1")},
                new Author{FirstName="El",LastName="Risitas",DateOfBirth=DateTime.Parse("2000-1-1")},
                new Author{FirstName="Giga",LastName="Chad",DateOfBirth=DateTime.Parse("2000-1-1")},
                new Author{FirstName="Jaka",LastName="Tarub",DateOfBirth=DateTime.Parse("2000-1-1")},
                new Author{FirstName="Kungfu",LastName="Panda",DateOfBirth=DateTime.Parse("2000-1-1")},
                new Author{FirstName="Black",LastName="Klansman",DateOfBirth=DateTime.Parse("2000-1-1")}
            };
            foreach (var a in author)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Aljabar Boolean",Description="Course ini akan banya belajar tentang aljabar boolean dan pengaplikasiannya"},
                new Course{Title="Fisika",Description="Course ini akan banya belajar tentang fisika dan pengaplikasiannya"},
                new Course{Title="Kalkulus",Description="Course ini akan banya belajar tentang kalkulus dan pengaplikasiannya"},
                new Course{Title="Rangkaian Listrik",Description="Course ini akan banya belajar tentang rangkaian listrik dan pengaplikasiannya"},
                new Course{Title="Kendali Cerdas",Description="Course ini akan banya belajar tentang kendali cerdas dan pengaplikasiannya"},
                new Course{Title="Control System",Description="Course ini akan banya belajar tentang system control dan pengaplikasiannya"},
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }
    }
}

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
                new Author{FirstName="Irfhando",LastName="Mahendra",DateOfBirth=DateTime.Parse("2000-1-1"),MainCategory="Scfi"},
                new Author{FirstName="El",LastName="Risitas",DateOfBirth=DateTime.Parse("2000-1-1"),MainCategory="Math"},
                new Author{FirstName="Giga",LastName="Chad",DateOfBirth=DateTime.Parse("2000-1-1"),MainCategory="Physics"},
                new Author{FirstName="Jaka",LastName="Tarub",DateOfBirth=DateTime.Parse("2000-1-1"),MainCategory="Electrical"},
                new Author{FirstName="Kungfu",LastName="Panda",DateOfBirth=DateTime.Parse("2000-1-1"),MainCategory="Novel"},
                new Author{FirstName="Black",LastName="Klansman",DateOfBirth=DateTime.Parse("2000-1-1"),MainCategory="Industrial"}
            };
            foreach (var a in author)
            {
                context.Authors.Add(a);
            }
            context.SaveChanges();

            var courses = new Course[]
            {
                new Course{Title="Aljabar Boolean",Description="Course ini akan banya belajar tentang aljabar boolean dan pengaplikasiannya",AuthorId=1},
                new Course{Title="Fisika",Description="Course ini akan banya belajar tentang fisika dan pengaplikasiannya",AuthorId=1},
                new Course{Title="Kalkulus",Description="Course ini akan banya belajar tentang kalkulus dan pengaplikasiannya",AuthorId=1},
                new Course{Title="Rangkaian Listrik",Description="Course ini akan banya belajar tentang rangkaian listrik dan pengaplikasiannya",AuthorId=2},
                new Course{Title="Kendali Cerdas",Description="Course ini akan banya belajar tentang kendali cerdas dan pengaplikasiannya",AuthorId=3},
                new Course{Title="a",Description="Course ini akan banya belajar tentang a dan pengaplikasiannya",AuthorId=3},
                new Course{Title="b",Description="Course ini akan banya belajar tentang b dan pengaplikasiannya",AuthorId=3},
                new Course{Title="c",Description="Course ini akan banya belajar tentang c dan pengaplikasiannya",AuthorId=4},
                new Course{Title="d",Description="Course ini akan banya belajar tentang d dan pengaplikasiannya",AuthorId=4},
                new Course{Title="e",Description="Course ini akan banya belajar tentang e dan pengaplikasiannya",AuthorId=4},
                new Course{Title="f",Description="Course ini akan banya belajar tentang f dan pengaplikasiannya",AuthorId=5},
            };

            foreach (var c in courses)
            {
                context.Courses.Add(c);
            }

            context.SaveChanges();
        }
    }
}

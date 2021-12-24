using AutoMapper;
using System;

namespace BootcampDay5.Profiles
{
    public class AuthorsProfile : Profile
    {
        public AuthorsProfile()
        {           
            CreateMap<Models.Author, Dtos.AuthorDto>()
                .ForMember(dest => dest.Name,
                opt => opt.MapFrom(src => $"{src.FirstName} {src.LastName}"))
                .ForMember(dest => dest.Age,
                opt => opt.MapFrom(src => Age(src.DateOfBirth)));

            CreateMap<Dtos.AuthorForCreateDto, Models.Author>();
        }
        public int Age(DateTime bday)
        {
            DateTime now = DateTime.Today;
            int age = now.Year - bday.Year;
            if (now < bday.AddYears(age))
                age--;
            return age;
        }
    }
}

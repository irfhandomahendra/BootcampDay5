using AutoMapper;
using System;

namespace BootcampDay5.Profiles
{
    public class CoursesProfile : Profile
    {
        public CoursesProfile()
        {
            CreateMap<Models.Course, Dtos.CourseDto>();

            CreateMap<Dtos.CourseForCreateDto, Models.Course>();
        }
    }
}

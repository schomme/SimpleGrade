using SimpleGrade.Base.Model.Person;
using SimpleGradeApi.Dto;

namespace SimpleGradeApi.Mapper
{
    public class MappingProfile : AutoMapper.Profile
    {
        public MappingProfile()
        {
            CreateMap<PersonDto, Person>();
            CreateMap<Person, PersonDto>();
        }
    }
}

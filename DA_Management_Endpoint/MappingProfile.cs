using AutoMapper;
using DA_Management_Endpoint.Dto.CreateDtos;
using DA_Management_Endpoint.Dtos;
using DA_Management_Endpoint.Models;

public class MappingProfile : AutoMapper.Profile
{
    public MappingProfile()
    {

        CreateMap<Attendance, AttendanceDto>()
            .ForMember(dest => dest.CreatedByCatechist, opt => opt.MapFrom(src => src.CreatedByCatechist))
            .ForMember(dest => dest.UpdatedByCatechist, opt => opt.MapFrom(src => src.UpdatedByCatechist));

        CreateMap<Block, BlockDto>()
            .ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes));

        CreateMap<Catechist, CatechistDto>()
            //.ForMember(dest => dest.Classes, opt => opt.MapFrom(src => src.Classes))
            .ForMember(dest => dest.CatechistProfiles, opt => opt.MapFrom(src => src.CatechistProfiles));

        CreateMap<Class, ClassDto>()
            .ForMember(dest => dest.Block, opt => opt.MapFrom(src => src.Block));

        CreateMap<DA_Management_Endpoint.Models.Profile, ProfileDto>()
            .ForMember(dest => dest.CreatedByCatechist, opt => opt.MapFrom(src => src.CreatedByCatechist))
            .ForMember(dest => dest.UpdatedByCatechist, opt => opt.MapFrom(src => src.UpdatedByCatechist));

        //CreateMap<Score, ScoreDto>()
        //    .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
        //    .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student));

        CreateMap<Student, StudentDto>()
            .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
            .ForMember(dest => dest.CreatedByCatechist, opt => opt.MapFrom(src => src.CreatedByCatechist))
            .ForMember(dest => dest.UpdatedByCatechist, opt => opt.MapFrom(src => src.UpdatedByCatechist))
            .ForMember(dest => dest.Attendances, opt => opt.MapFrom(src => src.Attendances))
            .ForMember(dest => dest.StudentRevisions, opt => opt.MapFrom(src => src.StudentRevisions))
            .ForMember(dest => dest.Scores, opt => opt.MapFrom(src => src.Scores))
            .ReverseMap();

        CreateMap<StudentRevision, StudentRevisionDto>()
            .ForMember(dest => dest.Class, opt => opt.MapFrom(src => src.Class))
            .ForMember(dest => dest.Student, opt => opt.MapFrom(src => src.Student))
            .ForMember(dest => dest.CreatedByCatechist, opt => opt.MapFrom(src => src.CreatedByCatechist));

        CreateMap<User, UserDto>()
            .ForMember(dest => dest.Catechist, opt => opt.MapFrom(src => src.Catechist));

        CreateMap<CreateAttendanceDto, Attendance>();
        CreateMap<CreateCatechistDto, Catechist>();
        CreateMap<CreateCatechistProfileDto, CatechistProfile>();
        CreateMap<CreateClassDto, Class>();
        CreateMap<CreateScoreDto, Score>();
        CreateMap<CreateStudentDto, Student>();
        CreateMap<CreateProfileDto, DA_Management_Endpoint.Models.Profile>();
    }
}

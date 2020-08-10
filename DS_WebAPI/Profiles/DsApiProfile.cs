using AutoMapper;
using DS_WebAPI.Dtos;
using SistemeTeShperndara.Models;

namespace DS_WebAPI.Profiles
{
    public class DsApiProfile : Profile
    {
        // Source -> Destination
        public DsApiProfile()
        {
            // Student
            CreateMap<AddStudentDto, Student>();
            CreateMap<Student, ReadStudentDto>();
            CreateMap<UpdateStudentDto, Student>();
            CreateMap<Student, UpdateStudentDto>();

            // User
            CreateMap<User, ReadUserDto>();

            // Professor
            CreateMap<Professor, ReadProfessorDto>();

            // Subjects
            CreateMap<Subject, ReadSubjectDto>();

            // Exam
            CreateMap<AddExamDto, Exam>();
            CreateMap<Exam, ReadExamDto>();
        }
    }
}

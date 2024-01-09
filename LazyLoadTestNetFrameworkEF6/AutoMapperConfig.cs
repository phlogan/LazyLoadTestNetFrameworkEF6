using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using LazyLoadTestNetFrameworkEF6.Entities;
using LazyLoadTestNetFrameworkEF6.ViewModels;

namespace LazyLoadTestNetFrameworkEF6
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static bool Initialized { get { return Mapper != null; } }

        public static IMapper GetMapper()
        {
            if (Mapper != null) return Mapper;

            var config = new MapperConfiguration(x =>
            {
                x.AddExpressionMapping();
                x.AddProfile<AutoMapperProfile>();

                x.ForAllMaps(
                     (mType, exp) => exp.MaxDepth(mType.MaxDepth == 0 ? 1 : mType.MaxDepth)
                 );
            });

            Mapper = new Mapper(config);
            return Mapper;
        }
    }

    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Student, StudentViewModel>();
            CreateMap<Grade, GradeViewModel>();
            CreateMap<Teacher, TeacherViewModel>();
            CreateMap<Enrollment, EnrollmentViewModel>();
            CreateMap<Course, CourseViewModel>();
            CreateMap<School, SchoolViewModel>();


            CreateMap<StudentViewModel, Student>();
            CreateMap<GradeViewModel, Grade>();
            CreateMap<TeacherViewModel, Teacher>();
            CreateMap<EnrollmentViewModel, Enrollment>();
            CreateMap<CourseViewModel, Course>();
            CreateMap<SchoolViewModel, School>();
        }
    }
}


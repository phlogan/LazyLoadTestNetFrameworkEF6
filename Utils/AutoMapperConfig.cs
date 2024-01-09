using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using LazyLoadTestNetFrameworkEFCore.Entities;
using LazyLoadTestNetFrameworkEFCore.ViewModels;

namespace LazyLoadTestNetFrameworkEFCore
{
    public class AutoMapperConfig
    {
        public static IMapper Mapper { get; set; }

        public static bool Initialized { get { return Mapper != null; } }

        public static IMapper GetMapper(params Profile[] profilesToLoad)
        {
            if (Mapper != null) return Mapper;

            var config = new MapperConfiguration(x =>
            {
                x.AddExpressionMapping();
                x.AddProfile<AutoMapperProfile>();
                if (profilesToLoad != null && profilesToLoad.Any())
                {
                    foreach (var p in profilesToLoad)
                        x.AddProfile(p);
                }

                x.ForAllMaps(
                     (mType, exp) => exp.MaxDepth(mType.MaxDepth == 0 ? 2 : mType.MaxDepth)
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


using LazyLoadTestNetFrameworkEFCore;
using LazyLoadTestNetFrameworkEFCore.ViewModels;
using LazyLoadTestNetFrameworkEFCore.DataContext;

var mapper = AutoMapperConfig.GetMapper();
using (var context = new DataContextEFCore())
{
    var student = context.Students.ToList();
    var studentVM = mapper.Map<IEnumerable<StudentViewModel>>(student);//<- this should take even more time
}
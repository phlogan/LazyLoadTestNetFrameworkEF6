using LazyLoadTestNetFrameworkEF6.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LazyLoadTestNetFrameworkEF6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var mapper = AutoMapperConfig.GetMapper();
            using (var context = new DataContext.DataContext())
            {
                var student = context.Students.ToList();
                var studentVM = mapper.Map<IEnumerable<StudentViewModel>>(student);//<- this should take a long time
            }

            Console.ReadKey();
        }
    }
}

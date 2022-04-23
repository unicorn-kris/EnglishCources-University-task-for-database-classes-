using Autofac;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Implements;

namespace EnglishCources.Repository
{
    public class RepositoryModule : Module
    {
        public string ConnectionString { get; set; }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().As<IBookRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<EnglishLevelRepository>().As<IEnglishLevelRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<ExamRepository>().As<IExamRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<ExamResultsRepository>().As<IExamResultsRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<TransitionToTheGroupRepository>().As<ITransitionToTheGroupRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
            builder.RegisterType<TransitionToTheLevelRepository>().As<ITransitionToTheLevelRepository>()
                .WithParameter("connectionString", ConnectionString).SingleInstance();
        }
    }
}

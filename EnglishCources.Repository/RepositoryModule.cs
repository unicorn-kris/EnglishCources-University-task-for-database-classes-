using Autofac;
using EnglishCources.Repository.Contracts;
using EnglishCources.Repository.Implements;

namespace EnglishCources.Repository
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookRepository>().As<IBookRepository>().SingleInstance();
            builder.RegisterType<EnglishLevelRepository>().As<IEnglishLevelRepository>().SingleInstance();
            builder.RegisterType<ExamRepository>().As<IExamRepository>().SingleInstance();
            builder.RegisterType<ExamResultsRepository>().As<IExamResultsRepository>().SingleInstance();
            builder.RegisterType<GroupRepository>().As<IGroupRepository>().SingleInstance();
            builder.RegisterType<LessonRepository>().As<ILessonRepository>().SingleInstance();
            builder.RegisterType<StudentRepository>().As<IStudentRepository>().SingleInstance();
            builder.RegisterType<TeacherRepository>().As<ITeacherRepository>().SingleInstance();
            builder.RegisterType<TransitionToTheGroupRepository>().As<ITransitionToTheGroupRepository>().SingleInstance();
            builder.RegisterType<TransitionToTheLevelRepository>().As<ITransitionToTheLevelRepository>().SingleInstance();
        }
    }
}

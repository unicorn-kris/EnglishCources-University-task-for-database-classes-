using Autofac;
using EnglishCources.Logic.Contracts;
using EnglishCources.Logic.Implements;
using EnglishCources.Repository;
using System.Configuration;

namespace EnglishCources.Logic
{
    public class LogicModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<BookLogic>().As<IBookLogic>().SingleInstance();
            builder.RegisterType<EnglishLevelLogic>().As<IEnglishLevelLogic>().SingleInstance();
            builder.RegisterType<ExamLogic>().As<IExamLogic>().SingleInstance();
            builder.RegisterType<ExamResultsLogic>().As<IExamResultsLogic>().SingleInstance();
            builder.RegisterType<GroupLogic>().As<IGroupLogic>().SingleInstance();
            builder.RegisterType<LessonLogic>().As<ILessonLogic>().SingleInstance();
            builder.RegisterType<StudentLogic>().As<IStudentLogic>().SingleInstance();
            builder.RegisterType<TeacherLogic>().As<ITeacherLogic>().SingleInstance();
            builder.RegisterType<TransitionToTheGroupLogic>().As<ITransitionToTheGroupLogic>().SingleInstance();
            builder.RegisterType<TransitionToTheLevelLogic>().As<ITransitionToTheLevelLogic>().SingleInstance();

            builder.RegisterModule(new RepositoryModule {
                ConnectionString = ConfigurationManager.ConnectionStrings["EnglishCourses"].ConnectionString});
        }
    }
}

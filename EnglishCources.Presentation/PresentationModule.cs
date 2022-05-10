using Autofac;
using EnglishCources.Logic;
using EnglishCources.Presentation.ViewModels;

namespace EnglishCources.Presentation
{
    internal class PresentationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<LogicModule>();

            builder.RegisterType<BookWindowViewModel>().AsSelf();
            builder.RegisterType<EnglishLevelWindowViewModel>().AsSelf();
            builder.RegisterType<ExamResultsWindowViewModel>().AsSelf();
            builder.RegisterType<ExamWindowViewModel>().AsSelf();
            builder.RegisterType<GroupWindowViewModel>().AsSelf();
            builder.RegisterType<LessonWindowViewModel>().AsSelf();
            builder.RegisterType<MainWindowViewModel>().AsSelf();
            builder.RegisterType<StudentWindowViewModel>().AsSelf();
            builder.RegisterType<TeacherWindowViewModel>().AsSelf();
        }
    }
}

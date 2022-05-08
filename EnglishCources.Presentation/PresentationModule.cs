using Autofac;
using EnglishCources.Logic;

namespace EnglishCources.Presentation
{
    internal class PresentationModule: Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterModule<LogicModule>();
        }
    }
}

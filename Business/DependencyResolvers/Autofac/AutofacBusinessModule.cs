using Autofac;
using Business.Abstract;
using Business.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<VacancyManager>().As<IVacancyService>().SingleInstance();
            builder.RegisterType<EfVacancyDal>().As<IVacancyDal>().SingleInstance();
        }
    }
}

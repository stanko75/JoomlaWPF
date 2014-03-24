namespace RightModule
{
  using Autofac;

  public class RightModuleRegistry: Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder.RegisterType<RightModule>();

      /*
      builder.RegisterType<CategoriesTreeGetter>().As<ICategoriesTreeGetter>();
      builder.RegisterType<GetJoomlaCategories>().As<IGetCategories>();
      builder.RegisterType<CategoriesViewModel>();

      builder.RegisterType<LeftView>().UsingConstructor(typeof(CategoriesViewModel));
       */
    }
  }
}
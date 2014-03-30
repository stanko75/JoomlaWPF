namespace LeftModule
{
  using Autofac;

  using global::LeftModule.Model;
  using global::LeftModule.View;
  using global::LeftModule.ViewModel;

  public class LeftModuleRegistry: Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder.RegisterType<LeftModule>();

      builder.RegisterType<CategoriesTreeGetter>().As<ICategoriesTreeGetter>();
      builder.RegisterType<GetJoomlaCategories>().As<IGetCategories>();
      builder.RegisterType<CategoriesTreeViewModel>();

      builder.RegisterType<LeftView>().UsingConstructor(typeof(CategoriesTreeViewModel));
    }
  }
}

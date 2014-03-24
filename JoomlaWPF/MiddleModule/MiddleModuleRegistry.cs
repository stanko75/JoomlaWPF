namespace MiddleModule
{
  using Autofac;

  public class MiddleModuleRegistry : Autofac.Module
  {
    protected override void Load(ContainerBuilder builder)
    {
      base.Load(builder);

      builder.RegisterType<MiddleModule>();
    }
  }
}

using System.Windows;

namespace JoomlaWPF
{
  using System;

  using Autofac;

  using LeftModule;

  using Microsoft.Practices.Prism.Modularity;

  using MiddleModule;

  using Prism.AutofacExtension;

  using RightModule;

  public class Bootstrapper : AutofacBootstrapper
  {

    protected override void ConfigureContainer(ContainerBuilder builder)
    {
      base.ConfigureContainer(builder);
      builder.RegisterType<Shell>();

      // register autofac module
      builder.RegisterModule<LeftModuleRegistry>();
      builder.RegisterModule<MiddleModuleRegistry>();
      builder.RegisterModule<RightModuleRegistry>();
    }

    protected override void ConfigureModuleCatalog()
    {
      base.ConfigureModuleCatalog();

      // register prism module
      Type leftModule = typeof(LeftModule);
      Type middleModule = typeof(MiddleModule);
      Type rightModule = typeof(RightModule);

      ModuleCatalog.AddModule(new ModuleInfo(leftModule.Name, leftModule.AssemblyQualifiedName));
      ModuleCatalog.AddModule(new ModuleInfo(middleModule.Name, middleModule.AssemblyQualifiedName));
      ModuleCatalog.AddModule(new ModuleInfo(rightModule.Name, rightModule.AssemblyQualifiedName));
    }

    protected override DependencyObject CreateShell()
    {
      return this.Container.Resolve<Shell>();
    }

    protected override void InitializeShell()
    {
      base.InitializeShell();
      Application.Current.MainWindow = (Shell) this.Shell;
      Application.Current.MainWindow.Show();
    }

  }
}
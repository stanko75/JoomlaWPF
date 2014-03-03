using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;
using System.Net.Security;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using LeftModule;
using Microsoft.Practices.Prism.MefExtensions;

namespace JoomlaWPF
{
  public class Bootstrapper: MefBootstrapper
  {
    protected override DependencyObject CreateShell()
    {
      return this.Container.GetExportedValue<Shell>();
    }

    protected override void InitializeShell()
    {
      base.InitializeShell();
      Application.Current.MainWindow = (Shell) this.Shell;
      Application.Current.MainWindow.Show();
    }

    protected override void ConfigureAggregateCatalog()
    {
      base.ConfigureAggregateCatalog();
      var executingAssembly = Assembly.GetExecutingAssembly();
      this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(executingAssembly));
      this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(LeftModule.LeftModule).Assembly));
      this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(RightModule.RightModule).Assembly));
      this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MiddleModule.MiddleModule).Assembly));
    }

    protected override CompositionContainer CreateContainer()
    {
      var container = base.CreateContainer();
      container.ComposeExportedValue(container);
      return container;
    }
  }
}

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace LeftModule
{
  using global::LeftModule.View;

  using Microsoft.Practices.Prism.Regions;

  [ModuleExport(typeof(LeftModule))]
  public class LeftModule: IModule
  {
    private readonly IRegionManager _regionManager;

    public LeftModule(IRegionManager regionManager)
    {
      _regionManager = regionManager;
    }

    public void Initialize()
    {
      //because of autofac (look at https://bitbucket.org/stmu/prism.aufofacextension/wiki/Home section A prism module (autofac independent))
      _regionManager.RegisterViewWithRegion("LeftRegion", typeof(LeftView));
    }
  }
}
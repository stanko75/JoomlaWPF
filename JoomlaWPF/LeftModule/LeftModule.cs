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
      _regionManager.RegisterViewWithRegion("LeftRegion", typeof(LeftView));
    }
  }
}
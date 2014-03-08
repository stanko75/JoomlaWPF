using System.ComponentModel.Composition;
using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;
using Microsoft.Practices.Prism.Regions;

namespace LeftModule
{
  [ModuleExport(typeof(LeftModule))]
  public class LeftModule: IModule
  {
    [Import]
    public IRegionManager Region { get; set; }
    public void Initialize()
    {
      Region.RequestNavigate("LeftRegion", "LeftView");
    }
  }
}
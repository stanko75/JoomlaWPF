using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace LeftModule
{
  [ModuleExport(typeof(LeftModule))]
  public class LeftModule: IModule
  {
    public void Initialize()
    {
      
    }
  }
}

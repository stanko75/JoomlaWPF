using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace RightModule
{
  [ModuleExport(typeof(RightModule))]
  public class RightModule: IModule
  {
    public void Initialize()
    {
      throw new System.NotImplementedException();
    }
  }
}

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace Left
{
  [ModuleExport(typeof(LeftModule))]
  public class LeftModule: IModule
  {
    public void Initialize()
    {
      throw new System.NotImplementedException();
    }
  }
}

using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace Middle
{
  [ModuleExport(typeof(MiddleModule))]
  public class MiddleModule : IModule
  {
    public void Initialize()
    {
      throw new System.NotImplementedException();
    }
  }
}

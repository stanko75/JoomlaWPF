using Microsoft.Practices.Prism.MefExtensions.Modularity;
using Microsoft.Practices.Prism.Modularity;

namespace MiddleModule
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

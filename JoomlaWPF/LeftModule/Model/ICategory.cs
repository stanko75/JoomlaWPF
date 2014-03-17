using System.Collections.Generic;

namespace LeftModule.Model
{
  public interface ICategory
  {
      string Name { get; }
      List<ICategory> Categories { get; }
  }
}
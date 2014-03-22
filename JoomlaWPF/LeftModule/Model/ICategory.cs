using System.Collections.Generic;

namespace LeftModule.Model
{
  public interface ICategory
  {
      string Name { get; }
      int Id { get; }
      List<ICategory> Categories { get; }
  }
}
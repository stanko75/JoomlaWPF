using System.Collections.Generic;

namespace LeftModule.Model
{
  public interface ITreeCategory
  {
      string Name { get; }
      int Id { get; }
      List<ITreeCategory> Categories { get; }
  }
}
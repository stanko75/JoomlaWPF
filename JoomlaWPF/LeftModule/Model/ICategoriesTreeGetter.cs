namespace LeftModule.Model
{
  using System.Collections.Generic;

  public interface ICategoriesTreeGetter
  {
    List<ITreeCategory> GetCategoriesInTree();
  }
}

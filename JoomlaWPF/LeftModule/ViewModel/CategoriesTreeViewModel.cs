using System.ComponentModel.Composition;

namespace LeftModule.ViewModel
{
  using System.Collections.Generic;
  using Model;

  [Export]
  public class CategoriesTreeViewModel
  {
    public List<ITreeCategory> CategoriesList { get; set; }

    [ImportingConstructor]
    public CategoriesTreeViewModel(ICategoriesTreeGetter categoriesTreeGetter)
    {
      CategoriesList = categoriesTreeGetter.GetCategoriesInTree();
    }
  }
}
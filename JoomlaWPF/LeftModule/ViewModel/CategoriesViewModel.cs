using System.ComponentModel.Composition;

namespace LeftModule.ViewModel
{
  using System.Collections.Generic;

  using Autofac;

  using global::LeftModule.Model;
  using global::LeftModule.View;

  [Export]
  public class CategoriesViewModel
  {

    private ICategoriesTreeGetter categoriesTreeGetter;

    private readonly IGetCategories _output;
    public List<ICategory> CategoriesList { get; set; }

    [ImportingConstructor]
    public CategoriesViewModel(ICategoriesTreeGetter categoriesTreeGetter)
    {
      CategoriesList = categoriesTreeGetter.GetCategoriesInTree();
    }
  }
}
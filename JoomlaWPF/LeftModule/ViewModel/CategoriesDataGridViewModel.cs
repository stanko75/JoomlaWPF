using System.Collections.Generic;
using System.ComponentModel.Composition;
using LeftModule.Model;

namespace LeftModule.ViewModel
{
  [Export]
  public class CategoriesDataGridViewModel
  {
    public List<IDataGridCategory> CategoriesList { get; set; }

    [ImportingConstructor]
    public CategoriesDataGridViewModel(ICategoriesDataGridGetter categoriesDataGridGetter)
    {
      CategoriesList = categoriesDataGridGetter.GetCategoriesInDataGrid();
    }
  }
}
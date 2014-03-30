using System.Collections.Generic;

namespace LeftModule.Model
{
  public interface ICategoriesDataGridGetter
  {
    List<IDataGridCategory> GetCategoriesInDataGrid();
  }
}

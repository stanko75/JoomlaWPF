using System.Collections.Generic;

namespace LeftModule.Model
{
  public class CategoriesModel: ICategory
  {
    private readonly List<ICategory> m_categories;
    public CategoriesModel()
    {
      m_categories = new List<ICategory>();
    }
    public string Name { get; set; }
    public int Id { get; set; }

    public List<ICategory> Categories
    {
      get { return m_categories; }
    }
  }
}
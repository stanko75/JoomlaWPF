using System.Collections.Generic;

namespace LeftModule.Model
{
  public class TreeCategoriesModel: ITreeCategory
  {
    private readonly List<ITreeCategory> m_categories;
    public TreeCategoriesModel()
    {
      m_categories = new List<ITreeCategory>();
    }
    public string Name { get; set; }
    public int Id { get; set; }

    public List<ITreeCategory> Categories
    {
      get { return m_categories; }
    }
  }
}
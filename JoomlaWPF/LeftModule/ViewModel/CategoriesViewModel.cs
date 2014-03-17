using System.Collections.Generic;
using System.ComponentModel.Composition;
using LeftModule.Model;
using MySql.Data.MySqlClient;

namespace LeftModule.ViewModel
{
  [Export]
  public class CategoriesViewModel
  {
    public List<ICategory> CategoriesList
    {
      get { return m_categories; }
      set
      {
        m_categories = value;
        //NotifiyPropertyChanged("Folders");
      }
    }

    private List<ICategory> m_categories;

    [ImportingConstructor]
    public CategoriesViewModel()
    {
      m_categories = new List<ICategory>();

      string MyConString =
      "SERVER=myServer;" +
      "DATABASE=myDb;" +
      "UID=myUid;" +
      "PASSWORD=myPass;Convert Zero Datetime=True";

      var connection = new MySqlConnection(MyConString);

      string sql = "select * from jos_categories order by level";

      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      CategoriesList = new List<ICategory>();
      var i = 0;
      while (dataReader.Read())
      {
        int level = int.Parse(dataReader["level"].ToString());
        if (level == 0)
        {
          CategoriesList.Add(new CategoriesModel { Name = dataReader["title"].ToString() });          
        }
        else if (level == 1)
        {
          CategoriesList[level - 1].Categories.Add(new CategoriesModel { Name = dataReader["title"].ToString() });          
        }
      }
    }
  }
}

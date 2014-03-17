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
      "DATABASE=MyDb;" +
      "UID=myUid;" +
      "PASSWORD=myPass;Convert Zero Datetime=True";

      var connection = new MySqlConnection(MyConString);

      string sql = "select * from jos_categories where parent_id = 0";

      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      CategoriesList = new List<ICategory>();
      while (dataReader.Read())
      {
        CategoriesList.Add(new CategoriesModel { Name = dataReader["title"].ToString() });
      }
      sql = "select * from jos_categories";
      connection.Close();
      cmdSel = new MySqlCommand(sql, connection);
      connection.Open();
      dataReader = cmdSel.ExecuteReader();
      var i = 0;
      while (dataReader.Read())
      {
        //CategoriesList.Add(new CategoriesModel { Name = dataReader["title"].ToString() });
        CategoriesList[0].Categories.Add(new CategoriesModel { Name = dataReader["title"].ToString() });
        //i++;
        //CategoriesList.Add(dataReader["title"].ToString());
      }

    }
  }
}

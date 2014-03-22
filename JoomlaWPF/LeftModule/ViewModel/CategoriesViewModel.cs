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

      string sql = "select * from jos_categories where level = 0 order by id ";

      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      CategoriesList = new List<ICategory>();
      var i = 0;
      while (dataReader.Read())
      {
        i++;

        CategoriesList.Add(new CategoriesModel
        {
          Name = dataReader["title"].ToString(),
          Id = int.Parse(dataReader["id"].ToString())
        });
      }

      CreateListRecursively(CategoriesList);
    }

    private void CreateListRecursively(List<ICategory> CategoriesList)
    {
      int i = -1;
      foreach (ICategory category in CategoriesList)
      {
        i++;
        string MyConString =
"SERVER=myServer;" +
"DATABASE=myDb;" +
"UID=myUid;" +
"PASSWORD=myPass;Convert Zero Datetime=True";

        var connection = new MySqlConnection(MyConString);

        string sql = "select * from jos_categories where parent_id = " + category.Id + " order by id ";

        var cmdSel = new MySqlCommand(sql, connection);

        connection.Open();

        MySqlDataReader dataReader = cmdSel.ExecuteReader();

        while (dataReader.Read())
        {
          CategoriesList[i].Categories.Add(new CategoriesModel
          {
            Name = dataReader["title"].ToString(),
            Id = int.Parse(dataReader["id"].ToString())
          });
        }

        CreateListRecursively(CategoriesList[i].Categories);
      }
    }
  }
}

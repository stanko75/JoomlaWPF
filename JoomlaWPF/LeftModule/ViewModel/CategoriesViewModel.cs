using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Configuration;
using LeftModule.Model;
using MySql.Data.MySqlClient;

namespace LeftModule.ViewModel
{
  [Export]
  public class CategoriesViewModel
  {
    private string JoomlaConStr = ConfigurationManager.ConnectionStrings["JoomlaCon"].ConnectionString;
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

      var connection = new MySqlConnection(JoomlaConStr);

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

        var connection = new MySqlConnection(JoomlaConStr);

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

namespace LeftModule.ViewModel
{
  using System.Collections.Generic;
  using System.Configuration;

  using Model;

  using MySql.Data.MySqlClient;

  public class CategoriesTreeGetter: ICategoriesTreeGetter
  {
    private string JoomlaConStr = ConfigurationManager.ConnectionStrings["JoomlaCon"].ConnectionString;

    public List<ITreeCategory> GetCategoriesInTree()
    {
      var connection = new MySqlConnection(JoomlaConStr);

      string sql = "select * from jos_categories where level = 0 order by id ";

      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      List<ITreeCategory>  CategoriesList = new List<ITreeCategory>();
      var i = 0;
      while (dataReader.Read())
      {
        i++;

        CategoriesList.Add(new TreeCategoriesModel
        {
          Name = dataReader["title"].ToString(),
          Id = int.Parse(dataReader["id"].ToString())
        });
      }

      CreateListRecursively(CategoriesList);

      return CategoriesList;
    }

    private void CreateListRecursively(List<ITreeCategory> CategoriesList)
    {
      int i = -1;
      foreach (ITreeCategory category in CategoriesList)
      {
        i++;

        var connection = new MySqlConnection(JoomlaConStr);

        string sql = "select * from jos_categories where parent_id = " + category.Id + " order by id ";

        var cmdSel = new MySqlCommand(sql, connection);

        connection.Open();

        MySqlDataReader dataReader = cmdSel.ExecuteReader();

        while (dataReader.Read())
        {
          CategoriesList[i].Categories.Add(new TreeCategoriesModel
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
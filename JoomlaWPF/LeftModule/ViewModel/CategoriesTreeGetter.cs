namespace LeftModule.ViewModel
{
  using System.Collections.Generic;
  using System.Configuration;

  using global::LeftModule.Model;

  using MySql.Data.MySqlClient;

  public class CategoriesTreeGetter: ICategoriesTreeGetter
  {
    private string JoomlaConStr = ConfigurationManager.ConnectionStrings["JoomlaCon"].ConnectionString;

    public List<ICategory> GetCategoriesInTree()
    {
      var connection = new MySqlConnection(JoomlaConStr);

      string sql = "select * from jos_categories where level = 0 order by id ";

      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      List<ICategory>  CategoriesList = new List<ICategory>();
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

      return CategoriesList;
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
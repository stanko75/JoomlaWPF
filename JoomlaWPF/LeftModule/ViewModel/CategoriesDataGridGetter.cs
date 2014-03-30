using System.Collections.Generic;
using System.Configuration;
using LeftModule.Model;
using MySql.Data.MySqlClient;

namespace LeftModule.ViewModel
{
  public class CategoriesDataGridGetter: ICategoriesDataGridGetter
  {
    private List<IDataGridCategory> _dataGridList;
    private string JoomlaConStr = ConfigurationManager.ConnectionStrings["JoomlaCon"].ConnectionString;
    public List<IDataGridCategory> GetCategoriesInDataGrid()
    {
      var connection = new MySqlConnection(JoomlaConStr);

      string sql = "select * from jos_categories order by id ";

      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      List<IDataGridCategory> CategoriesList = new List<IDataGridCategory>();
      while (dataReader.Read())
      {
        CategoriesList.Add(new DataGridCategory
        {
          id = int.Parse(dataReader["id"].ToString()),
          parent_id = int.Parse(dataReader["parent_id"].ToString()),
          level = int.Parse(dataReader["level"].ToString()),
          path = dataReader["path"].ToString(),
          title = dataReader["title"].ToString(),
          alias = dataReader["alias"].ToString(),
          note = dataReader["note"].ToString(),
          description = dataReader["description"].ToString(),
          published = dataReader["published"].ToString(),
          checked_out = dataReader["checked_out"].ToString(),
          checked_out_time = dataReader["checked_out_time"].ToString(),
          created_user_id = dataReader["created_user_id"].ToString(),
          created_time = dataReader["created_time"].ToString(),
          modified_user_id = dataReader["modified_user_id"].ToString(),
          modified_time = dataReader["modified_time"].ToString(),
          hits = dataReader["hits"].ToString(),
        });
      }

      return CategoriesList;
    }

    public List<IDataGridCategory> DataGridList
    {
      get { return GetCategoriesInDataGrid(); }
      //set { GetCategoriesInDataGrid() = value; }
    }
  }
}
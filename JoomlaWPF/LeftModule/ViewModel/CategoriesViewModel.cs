using System.Collections.Generic;
using System.ComponentModel.Composition;
using MySql.Data.MySqlClient;

namespace LeftModule.ViewModel
{
  [Export]
  public class CategoriesViewModel
  {
    public List<string> CategoriesList { get; set; }

    [ImportingConstructor]
    public CategoriesViewModel()
    {
      string MyConString =
"SERVER=myServer" +
"DATABASE=myDb;" +
"UID=myUid;" +
"PASSWORD=myPass;Convert Zero Datetime=True";

      string sql = "select * from jos_categories";

      var connection = new MySqlConnection(MyConString);
      var cmdSel = new MySqlCommand(sql, connection);

      connection.Open();

      MySqlDataReader dataReader = cmdSel.ExecuteReader();

      CategoriesList = new List<string>();
      while (dataReader.Read())
      {
        CategoriesList.Add(dataReader["title"].ToString());
        //CategoriesList[0].SubCategoriesModels = new List<CategoriesModel>();
        //CategoriesList[0].SubCategoriesModels.Add(new CategoriesModel { Name = dataReader["title"].ToString() });
        //ArticleRoots.Add(dataReader["title"].ToString());
        //ttt.Name = Add(dataReader["title"].ToString());
        //ttt.Add(new ;
      }
      //return ttt;
    }
  }
}

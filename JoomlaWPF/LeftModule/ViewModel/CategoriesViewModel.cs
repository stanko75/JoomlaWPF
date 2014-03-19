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

      string MyConString = "SERVER=myServer;DATABASE=myDb;UID=myUid;PASSWORD=myPass;Convert Zero Datetime=True";

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

        CategoriesList.Add(new CategoriesModel { Name = dataReader["title"].ToString() });

        var childConnection = new MySqlConnection(MyConString);

        string childSql = "select * from jos_categories where parent_id = " + dataReader["id"].ToString()
                          + " order by id";

        var childcmdSel = new MySqlCommand(childSql, childConnection);

        childConnection.Open();

        MySqlDataReader childDataReader = childcmdSel.ExecuteReader();

        var childi = 0;
        while (childDataReader.Read())
        {
          childi++;
          CategoriesList[i - 1].Categories.Add(new CategoriesModel { Name = childDataReader["title"].ToString() });

          var childchildConnection = new MySqlConnection(MyConString);

          string childchildSql = "select * from jos_categories where parent_id = " + childDataReader["id"].ToString()
                                 + " order by id";

          var childchildcmdSel = new MySqlCommand(childchildSql, childchildConnection);

          childchildConnection.Open();

          MySqlDataReader childchildDataReader = childchildcmdSel.ExecuteReader();

          var childchildi = 0;
          while (childchildDataReader.Read())
          {
            childchildi++;
            CategoriesList[i - 1].Categories[childi - 1].Categories.Add(
              new CategoriesModel { Name = childchildDataReader["title"].ToString() });

            var childchildchildConnection = new MySqlConnection(MyConString);

            string childchildchildSql = "select * from jos_categories where parent_id = "
                                        + childchildDataReader["id"].ToString() + " order by id";

            var childchildchildcmdSel = new MySqlCommand(childchildchildSql, childchildchildConnection);

            childchildchildConnection.Open();

            MySqlDataReader childchildchildDataReader = childchildchildcmdSel.ExecuteReader();

            while (childchildchildDataReader.Read())
            {
              CategoriesList[i - 1].Categories[childi - 1].Categories[childchildi - 1].Categories.Add(
                new CategoriesModel { Name = childchildchildDataReader["title"].ToString() });
            }
          }
        }
      }
    }
  }
}

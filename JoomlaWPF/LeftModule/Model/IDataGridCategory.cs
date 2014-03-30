namespace LeftModule.Model
{
  public interface IDataGridCategory
  {
    int id { get; set; }
    int parent_id { get; set; }
    int level { get; set; }
    string path { get; set; }
    string title { get; set; }
    string alias { get; set; }
    string note { get; set; }
    string description { get; set; }
    string published { get; set; }
    string checked_out { get; set; }
    string checked_out_time { get; set; }
    string created_user_id { get; set; }
    string created_time { get; set; }
    string modified_user_id { get; set; }
    string modified_time { get; set; }
    string hits { get; set; }
  }
}

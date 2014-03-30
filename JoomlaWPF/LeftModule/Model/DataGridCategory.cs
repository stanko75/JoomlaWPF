namespace LeftModule.Model
{
  class DataGridCategory: IDataGridCategory
  {
    public int id { get; set; }
    public int parent_id { get; set; }
    public int level { get; set; }
    public string path { get; set; }
    public string title { get; set; }
    public string alias { get; set; }
    public string note { get; set; }
    public string description { get; set; }
    public string published { get; set; }
    public string checked_out { get; set; }
    public string checked_out_time { get; set; }
    public string created_user_id { get; set; }
    public string created_time { get; set; }
    public string modified_user_id { get; set; }
    public string modified_time { get; set; }
    public string hits { get; set; }
  }
}

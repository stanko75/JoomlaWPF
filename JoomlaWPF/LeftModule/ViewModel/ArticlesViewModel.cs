using System.Collections.Generic;
using System.ComponentModel.Composition;

namespace LeftModule.ViewModel
{
  [Export]
  public class ArticlesViewModel
  {
    public List<string> Articles { get; set; }

    [ImportingConstructor]
    public ArticlesViewModel()
    {
      Articles = new List<string> {"test"};
    }
  }
}

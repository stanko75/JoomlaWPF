using System.ComponentModel.Composition;
using System.Windows;

namespace JoomlaWPF
{
  [Export(typeof(Shell))]
  public partial class Shell : Window
  {
    
    public Shell()
    {
      InitializeComponent();
    }
  }
}

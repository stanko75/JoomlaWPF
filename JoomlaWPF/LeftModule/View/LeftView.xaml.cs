using System.ComponentModel.Composition;
using System.Windows.Controls;
using LeftModule.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace LeftModule.View
{
  using Autofac;

  [Export("LeftView")]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  [RegionMemberLifetime(KeepAlive = false)]
  public partial class LeftView : UserControl
  {
    public static IContainer Container { get; set; }
    [ImportingConstructor]
    public LeftView(CategoriesViewModel avm)
    {
      InitializeComponent();
      this.DataContext = avm;
    }
  }
}
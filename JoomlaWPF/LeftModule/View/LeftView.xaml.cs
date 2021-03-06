﻿using System.ComponentModel.Composition;
using System.Windows.Controls;
using LeftModule.ViewModel;
using Microsoft.Practices.Prism.Regions;

namespace LeftModule.View
{
  [Export("LeftView")]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  [RegionMemberLifetime(KeepAlive = false)]
  public partial class LeftView : UserControl
  {
    [ImportingConstructor]
    public LeftView(CategoriesTreeViewModel dataContext)
    {
      this.DataContext = dataContext;
      this.InitializeComponent();
    }
  }
}
using System.ComponentModel.Composition;

namespace LeftModule.ViewModel
{
  using System.Collections.Generic;

  using Autofac;

  using global::LeftModule.Model;
  using global::LeftModule.View;

  [Export]
  public class CategoriesViewModel
  {

    public static List<ICategory> GetCategoriesInTree()
    {
      var scope = LeftView.Container.BeginLifetimeScope();
      var writer = scope.Resolve<ICategoriesTreeGetter>();
      return writer.GetCategoriesInTree();
    }

    private readonly IGetCategories _output;
    public List<ICategory> CategoriesList { get; set; }

    [ImportingConstructor]
    public CategoriesViewModel()
    {
      var builder = new ContainerBuilder();
      builder.RegisterType<CategoriesTreeGetter>().As<ICategoriesTreeGetter>();
      builder.RegisterType<GetJoomlaCategories>().As<IGetCategories>();
      LeftView.Container = builder.Build();

      CategoriesList = GetCategoriesInTree();

    }
  }
}
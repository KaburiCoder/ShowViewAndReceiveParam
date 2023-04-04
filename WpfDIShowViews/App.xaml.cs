using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfDIShowViews.Services;
using WpfDIShowViews.ViewModels;
using WpfDIShowViews.Views;

namespace WpfDIShowViews
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {
    private IServiceProvider _services = default!;

    private IServiceProvider ConfigurationService()
    {
      IServiceCollection services = new ServiceCollection();

      // Views
      services.AddSingleton<MainView>();      
      services.AddTransient<SubView>();

      // Services
      services.AddSingleton<IViewService, ViewService>();

      // ViewModels
      services.AddSingleton<MainViewModel>();
      services.AddTransient<SubViewModel>();

      return services.BuildServiceProvider();
    }

    public App()
    {
      _services = ConfigurationService();
    }

    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);

      var viewService = (IViewService)_services.GetService(typeof(IViewService))!;
      viewService.ShowMainView();
    }
  }
}

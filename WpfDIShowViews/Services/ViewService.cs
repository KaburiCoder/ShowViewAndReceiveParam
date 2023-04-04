using System;
using System.ComponentModel;
using System.Windows;
using WpfDIShowViews.Models;
using WpfDIShowViews.ViewModels;
using WpfDIShowViews.Views;

namespace WpfDIShowViews.Services
{
  public class ViewService : IViewService
  {
    private readonly IServiceProvider _serviceProvider;

    public ViewService(IServiceProvider serviceProvider)
    {
      _serviceProvider = serviceProvider;
    }

    public void ShowView<TView, TViewModel>(object? parameter = null)
     where TView : Window
     where TViewModel : INotifyPropertyChanged
    {
      INotifyPropertyChanged viewModel = (INotifyPropertyChanged)_serviceProvider.GetService(typeof(TViewModel))!;
      Window view = (Window)_serviceProvider.GetService(typeof(TView))!;

      if (parameter != null && viewModel is IParameterReceiver parameterReceiver)
      {
        parameterReceiver.ReceiveParameter(parameter);
      }

      view.DataContext = viewModel;
      view.Show();
    }

    public void ShowMainView()
    {
      ShowView<MainView, MainViewModel>();
    }

    public void ShowSubView(SubData subData)
    {
      ShowView<SubView, SubViewModel>(subData);
    }
  }
}

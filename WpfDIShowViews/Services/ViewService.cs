using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
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
     where TViewModel : ViewModelBase
    {
      ViewModelBase viewModel = (ViewModelBase)_serviceProvider.GetService(typeof(TViewModel))!;
      Window view = (Window)_serviceProvider.GetService(typeof(TView))!;

      viewModel.SetWindow(view);

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

    private bool ActivateView<TView>() where TView : Window
    {
      IEnumerable<Window> windows = Application.Current.Windows.OfType<TView>();
      if (windows.Any())
      {
        windows.ElementAt(0).Activate();
        return true;
      }
      return false;
    }

    public void ShowSubView(SubData subData)
    {
      if (!ActivateView<SubView>())
      {
        ShowView<SubView, SubViewModel>(subData);
      }      
    }
  }
}

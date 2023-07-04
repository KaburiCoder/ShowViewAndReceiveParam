using CommunityToolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfDIShowViews.ViewModels
{
  public abstract class ViewModelBase : ObservableObject
  {
    protected Window? Window;
    
    protected virtual void OnWindowClosing(object? sender, System.ComponentModel.CancelEventArgs e) { }

    protected virtual void OnWindowLoaded(object sender, RoutedEventArgs e) { }

    private void AddLifecycleHandler()
    {
      Window!.Loaded += OnWindowLoaded;
      Window!.Closing += OnWindowClosing;
    }

    internal void SetWindow(Window window)
    {
      Window = window;
      AddLifecycleHandler();
    }
  }
}

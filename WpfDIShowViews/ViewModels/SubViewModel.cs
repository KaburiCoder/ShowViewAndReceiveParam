using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfDIShowViews.Models;

namespace WpfDIShowViews.ViewModels
{
  public class SubViewModel : ViewModelBase, IParameterReceiver
  {
    public SubData SubData { get; set; } = default!;

    public void ReceiveParameter(object parameter)
    {
      if (parameter is SubData subData)
      {
        SubData = subData;
      }
    }

    protected override void OnWindowLoaded(object sender, RoutedEventArgs e)
    {
      MessageBox.Show("SubWindow Loaded");
    }

    protected override void OnWindowClosing(object? sender, CancelEventArgs e)
    {
      MessageBox.Show("SubWindow Closing");
    }

    public ICommand CloseCommand => new RelayCommand<object>(_ => Window?.Close());
    }
}

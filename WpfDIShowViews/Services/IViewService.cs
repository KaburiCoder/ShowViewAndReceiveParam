using System.ComponentModel;
using System.Windows;
using WpfDIShowViews.Models;
using WpfDIShowViews.ViewModels;

namespace WpfDIShowViews.Services
{
  public interface IViewService
  {
    void ShowView<TView, TViewModel>(object? parameter = null)
      where TView : Window
      where TViewModel : ViewModelBase;

    void ShowMainView();

    void ShowSubView(SubData subData);
  }
}

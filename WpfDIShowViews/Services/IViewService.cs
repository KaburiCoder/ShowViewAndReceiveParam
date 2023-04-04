﻿using System.ComponentModel;
using System.Windows;
using WpfDIShowViews.Models;

namespace WpfDIShowViews.Services
{
  public interface IViewService
  {
    void ShowView<TView, TViewModel>(object? parameter = null)
      where TView : Window
      where TViewModel : INotifyPropertyChanged;

    void ShowMainView();

    void ShowSubView(SubData subData);
  }
}

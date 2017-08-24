using GeoLib.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading;
using System.Windows;

namespace GeoLib.WindowsHost
{
  public partial class MainWindow : Window
  {
    public MainWindow()
    {
      InitializeComponent();

      btnStart.IsEnabled = true;
      btnStop.IsEnabled = false;

      this.Title = "UI Running on Thread " + Thread.CurrentThread.ManagedThreadId;
    }

    ServiceHost _HostGeoManager = null;

    private void btnStart_Click(object sender, RoutedEventArgs e)
    {
      _HostGeoManager = new ServiceHost(typeof(GeoManager));
      _HostGeoManager.Open();

      btnStart.IsEnabled = false;
      btnStop.IsEnabled = true;
    }

    private void btnStop_Click(object sender, RoutedEventArgs e)
    {
      _HostGeoManager.Close();

      btnStart.IsEnabled = true;
      btnStop.IsEnabled = false;
    }
  }
}

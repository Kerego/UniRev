using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using UniRev.Domain.Models;
using UniRev.Infrastructure;
using UniRev.Repositories.Interfaces;

namespace UniRev
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			this.Loaded += WindowLoaded;
		}

		private void WindowLoaded(object sender, RoutedEventArgs e)
		{
			ServiceLocator.RegisterAll();
			CreateTab.DataContext = ServiceLocator.Get<CreateViewModel>();
			ReadTab.DataContext = ServiceLocator.Get<ReadViewModel>();
		}
	}
}

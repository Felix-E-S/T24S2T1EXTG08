using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class Menu : Page
	{
		public Menu()
		{
			this.InitializeComponent();
		}
		//menu navigation
		private void mathsCalculator_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}
		//menu navigation
		private void mortgageCalculator_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MortgageCalc));
		}
		//menu navigation
		private void currencyConverter_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CurrencyConv));
		}
		//menu navigation
		private void exit_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}


	}
}

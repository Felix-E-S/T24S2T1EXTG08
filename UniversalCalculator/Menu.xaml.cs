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

		private void mathsCalculator_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MainPage));
		}
		private void mortgageCalculator_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(MortgageCalc));
		}
		private void currencyConverter_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(CurrencyConv));
		}
		private void exit_Click(object sender, RoutedEventArgs e)
		{
			Environment.Exit(0);
		}

		private void Trip_Click(object sender, RoutedEventArgs e)
		{
			//“Trip calculator C# code will be developed later”. 
		}
	}
}

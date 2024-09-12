using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class CurrencyConv : Page
	{
		const double USD_TO_EURO = 0.85189982;
		const double USD_TO_POUND = 0.72872436;
		const double USD_TO_RUPEE = 74.257327;
		const double EURO_TO_USD = 1.1739732;
		const double EURO_TO_POUND = 0.8556672;
		const double EURO_TO_RUPEE = 87.00755;
		const double POUND_TO_USD = 1.371907;
		const double POUND_TO_EURO = 1.1686692;
		const double POUND_TO_RUPEE = 101.68635;
		const double RUPEE_TO_USD = 0.011492628;
		const double RUPEE_TO_EURO = 0.013492774;
		const double RUPEE_TO_POUND = 0.0098339397;

		private static readonly double[,] conversionRates = new double[,]
	  {
			{ 1, USD_TO_EURO, USD_TO_POUND, USD_TO_RUPEE },  
            { EURO_TO_USD, 1, EURO_TO_POUND, EURO_TO_RUPEE },  
            { POUND_TO_USD, POUND_TO_EURO, 1, POUND_TO_RUPEE }, 
            { RUPEE_TO_USD, RUPEE_TO_EURO, RUPEE_TO_POUND, 1 }  
	  };

		private static readonly string[] currencyNames = new string[]
		   {
			"US Dollar",
			"Euro",
			"British Pound",
			"Indian Rupee"
		   };
		private static readonly string[] currencySymbols = new string[]
	   {
			"$",
			"€",
			"£",
			"₹"
	   };

		public CurrencyConv()
		{
			this.InitializeComponent();
		}

		private double Calculate(double amount, int currencyFrom, int currencyTo)
		{
			
			if (currencyFrom == currencyTo)
			{
				return amount; 
			}

			
			double conversionRate = conversionRates[currencyFrom, currencyTo];
			return amount * conversionRate;
		}

		private double CalculateReverse(double amount, int currencyFrom, int currencyTo)
		{
			
			if (currencyFrom == currencyTo)
			{
				return amount; 
			}

			double conversionRate = conversionRates[currencyTo, currencyFrom];
			return amount * conversionRate;
		}


		private async void calcButton_Click(object sender, RoutedEventArgs e)
		{
			double amount;
			if (string.IsNullOrWhiteSpace(amountTextBox.Text))
			{
				var dialogMessage = new MessageDialog($"Error! Please Enter an amount to convert");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}

			try
			{
				amount = double.Parse(amountTextBox.Text);
			}
			catch
			{
				var dialogMessage = new MessageDialog($"Error! Amount must be a number to perform conversion");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;
			}
			if (amount <= 0)
			{
				var dialogMessage = new MessageDialog($"Error! Please Enter an amount that is greater than");
				await dialogMessage.ShowAsync();
				amountTextBox.Focus(FocusState.Programmatic);
				amountTextBox.SelectAll();
				return;

			}

			int currencyFromIndex = fromComboBox.SelectedIndex;
			int currencyToIndex = toComboBox.SelectedIndex;

			double forwardCalculatedAmount = Calculate(amount, currencyFromIndex, currencyToIndex);
			double reverseCalculatedAmount = CalculateReverse(amount, currencyFromIndex, currencyToIndex);
			double unitCalculateed = Calculate(1, currencyFromIndex, currencyToIndex);
			double reverseUnitCalculateed = CalculateReverse(1, currencyFromIndex, currencyToIndex);

			resultsTextBlock.Text = $"{currencySymbols[currencyFromIndex]}{amount} {currencyNames[currencyFromIndex]} = {currencySymbols[currencyToIndex]}{forwardCalculatedAmount.ToString("F2")} {currencyNames[currencyToIndex]}";
			reverseTextBlock.Text = $"{currencySymbols[currencyToIndex]}{amount}{currencyNames[currencyToIndex]} = {currencySymbols[currencyFromIndex]}{reverseCalculatedAmount.ToString("F2")} {currencyNames[currencyFromIndex]}";
			from1UnitBlock.Text = $"{currencySymbols[currencyFromIndex]}1 {currencyNames[currencyFromIndex]} = {currencySymbols[currencyToIndex]}{unitCalculateed.ToString("F2")} {currencyNames[currencyToIndex]} ";
			to1UnitBlock.Text = $"{currencySymbols[currencyToIndex]}1 {currencyNames[currencyToIndex]} = {currencySymbols[currencyFromIndex]}{reverseUnitCalculateed.ToString("F2")} {currencyNames[currencyFromIndex]}";

		}

		private void exitButton_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Menu));
		}
	}
}

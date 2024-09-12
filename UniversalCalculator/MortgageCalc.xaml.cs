using System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Calculator
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MortgageCalc : Page
	{
		public MortgageCalc()
		{
			this.InitializeComponent();
		}
		private void calc_Click(object sender, RoutedEventArgs e)
		{
			double principleLoan, monthlyInterestRate, yearlyInterestRate, monthlyRepayment, years, months;

			principleLoan = double.Parse(principleBorrowInput.Text);
			yearlyInterestRate = double.Parse(yearlyInterestInput.Text);
			years = double.Parse(yearsInput.Text);
			months = double.Parse(monthsInput.Text);

			monthlyInterestRate = (yearlyInterestRate / 12) / 100;
			monthlyInterestInput.Text = monthlyInterestRate.ToString("N4") + "%";
			months = months + (years * 12);
			monthlyRepayment = principleLoan * (monthlyInterestRate * Math.Pow((1 + monthlyInterestRate), months)) / (Math.Pow((1 + monthlyInterestRate), months) - 1);
			monthlyRepaymentInput.Text = monthlyRepayment.ToString("C");

		}
		private void exit_Click(object sender, RoutedEventArgs e)
		{
			this.Frame.Navigate(typeof(Menu));
		}
	}
}

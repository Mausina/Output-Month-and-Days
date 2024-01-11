using System;
using System.Globalization;
using System.Windows.Forms;

namespace calendar
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void СountButton_Click(object sender, EventArgs e)
        {
            if (int.TryParse(GetInputTextBox.Text, out int monthNumber))
            {
                if (monthNumber <= 12 && monthNumber >= 1)
                {
                    string monthName = GetMonthName(monthNumber);
                    int numberOfDays = GetNumberOfDays(monthNumber);
                    // Display the results in a label or another appropriate control
                    OutputTextBox.Text = $"Month: {monthName}, Number of days: {numberOfDays}";
                }
                else
                {
                    // Handle invalid input
                    MessageBox.Show("Invalid input. Please enter a valid month number.");
                    GetInputTextBox.Clear();
                    OutputTextBox.Clear();
                }
            }
            else
            {
                // Handle invalid input
                MessageBox.Show("Invalid input. Please enter a valid month number.");
                GetInputTextBox.Clear();
                OutputTextBox.Clear();
            }
        }

        private string GetMonthName(int monthNumber)
        {
            CultureInfo culture = CultureInfo.InvariantCulture;
            DateTimeFormatInfo dtfi = culture.DateTimeFormat;
            string monthName = dtfi.GetMonthName(monthNumber);
            return monthName;
        }

        private int GetNumberOfDays(int monthNumber)
        {
            int numberOfDays = DateTime.DaysInMonth(DateTime.Now.Year, monthNumber);
            return numberOfDays;
        }

        private void ExitButton_Click(object sender, EventArgs e)
        {
            Application.Exit(); 
        }

        private void ClearButton_Click(object sender, EventArgs e)
        {
            GetInputTextBox.Clear();
            OutputTextBox.Clear();
        }
    }
}


// Author : Andrew, Shuo, Jade, Osaid
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace TravelExpert
{
    /// <summary>
    /// a repository of static methods for validation 
    /// </summary>
    public static class Validator
    {
        /// <summary>
        /// tests if text box contains non-empty string
        /// </summary>
        /// <param name="textBox">text box to validate (with Tag property set)</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsPresent(TextBox textBox)
        {
            bool isValid = true;
            if(textBox.Text == "")
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " is required");
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// checks if user selected combo box
        /// </summary>
        /// <param name="cb">cb to be checked</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsSelected(ComboBox cb)
        {
            bool isValid = true;
            if (cb.SelectedIndex == -1) //no selection
            {
                isValid = false;
                MessageBox.Show(cb.Tag + " is required");
                cb.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if a textbox contains a non-negative integer value
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsNonNegativeInt(TextBox textBox)
        {
            bool isValid = true;
            int result; 
            if(!Int32.TryParse(textBox.Text, out result)) // if cannot parse as int
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a whole number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if(result < 0) // an int but can be negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if a textbox contains a non-negative double value
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsNonNegativeDouble(TextBox textBox)
        {
            bool isValid = true;
            double result;
            if (!Double.TryParse(textBox.Text, out result)) // if cannot parse as double
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (result < 0) // a double number but can be negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }



        /// <summary>
        /// tests if a textbox contains a double value within range
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <param name="minValue">lowest value allowed</param>
        /// <param name="maxValue">highest value allowed</param>
        /// <returns>true if valid and false if not</returns>
        public static bool IsDoubleInRange(TextBox textBox, 
            double minValue, double maxValue)
        {
            bool isValid = true;
            double result;
            if (!Double.TryParse(textBox.Text, out result)) // if cannot parse as double
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (result < minValue || result > maxValue) // a double number, but can be out of range
            {
                isValid = false;
                MessageBox.Show( $"{textBox.Tag} has to be between {minValue} and {maxValue}");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }

        /// <summary>
        /// tests if a textbox contains a non-negative decimal value
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsNonNegativeDecimal(TextBox textBox)
        {
            bool isValid = true;
            decimal result;
            if (!Decimal.TryParse(textBox.Text, out result)) // if cannot parse as int
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be a number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else if (result < 0) // an int but can be negative
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " has to be positive or zero");
                textBox.SelectAll();
                textBox.Focus();
            }
            return isValid;
        }


        /// <summary>
        /// tests if a textbox contains a number with maximum 18 digits and 1 optional decimal place
        /// </summary>
        /// <param name="textBox">text box to test (with Tag property set)</param>
        /// <returns> true if valid and false if not</returns>
        public static bool IsValidDecimalFormat(TextBox textBox)
        {
            bool isValid = true;
            decimal result;

            if (!Decimal.TryParse(textBox.Text, out result)) // if cannot parse as decimal
            {
                isValid = false;
                MessageBox.Show(textBox.Tag + " must be a valid number");
                textBox.SelectAll();
                textBox.Focus();
            }
            else
            {
                string[] parts = textBox.Text.Split('.');
                if (parts.Length == 1 && parts[0].Length <= 18) //valid whole number
                {
                    isValid = true;
                }
                else if (parts.Length == 2 && parts[0].Length <= 18 && parts[1].Length == 1) //valid decimal number
                {
                    isValid = true;
                }
                else
                {
                    isValid = false;
                    MessageBox.Show(textBox.Tag + " must have a maximum of 18 whole numbers and optionally 1 decimal place");
                    textBox.SelectAll();
                    textBox.Focus();
                }
            }

            return isValid;
        }

        // Added by Shuo, method that validate the input when adding package.
        public static bool IsEndDateLaterThanStartDate(DateTimePicker startDate, DateTimePicker endDate)
        {
            bool isValid = true;
            if (endDate.Value <= startDate.Value)
            {
                isValid = false;
                MessageBox.Show("Start Date should be later than End Date.");
                endDate.Focus();
            }
            return isValid;
        }

        public static bool IsCommissionLessThanOrEqualToBasePrice(TextBox basePrice, TextBox agencyCommission)
        {
            bool isValid = true;
            decimal basePriceVal, commissionVal;
            if (Decimal.TryParse(basePrice.Text, out basePriceVal) && Decimal.TryParse(agencyCommission.Text, out commissionVal))
            {
                if (commissionVal > basePriceVal)
                {
                    isValid = false;
                    MessageBox.Show("Agency Commission should be less than or equal to Base Price.");
                    agencyCommission.SelectAll();
                    agencyCommission.Focus();
                }
            }
            else
            {
                isValid = false;
                MessageBox.Show("Both Base Price and Agency Commission should be valid numbers.");
                basePrice.Focus();
            }
            return isValid;
        }




    } // class
} // namespace

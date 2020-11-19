// <copyright file="AddEditFilterDialog.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTracker
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ExpenseTrackerEngine;

    /// <summary>
    /// DialogBox for adding or editing an expense.
    /// </summary>
    public partial class AddEditFilterDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddEditFilterDialog"/> class.
        /// Default constructor. Constructs dialog in AddMode for brand new expense.
        /// </summary>
        public AddEditFilterDialog()
        {
            this.InitializeComponent();
            this.ExpenseFilter = null;

            // Set title to Add
            this.titleTextBox.Text = "Add a New Filter";

            // Set all fields to disabled initially.
            this.InitializeForm();
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddEditFilterDialog"/> class.
        /// Edit constructor. Constructs dialog in EditMode for existing filter.
        /// </summary>
        /// <param name="f">The expense data to edit.</param>
        public AddEditFilterDialog(ExpenseFilter f)
        {
            this.InitializeComponent();
            this.ExpenseFilter = f;

            // Set title to Edit
            this.titleTextBox.Text = "Edit an Existing Filter";

            // first disable everything.
            this.InitializeForm();

            // Assign values to those of passed filter
            this.filterNameInputTextBox.Text = f.Name;
            this.filterNameInputTextBox.ReadOnly = true;    // Cannot change the name, unique identifier.

            if (f.MinDate != DateTime.MinValue)
            {
                this.lowerBoundDateTimePicker.Value = f.MinDate;
                this.lowerBoundDateLabelButton.PerformClick();
            }

            if (f.MaxDate != DateTime.MaxValue)
            {
                this.upperBoundDateTimePicker.Value = f.MaxDate;
                this.upperBoundDateLabelButton.PerformClick();
            }

            if (f.Method != null)
            {
                // Assign purchase method.
                if (f.Method is Cash)
                {
                    Cash c = f.Method as Cash;

                    this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.CASH;

                    this.currencyInputComboBox.Text = c.Currency;
                }
                else if (f.Method is Card)
                {
                    Card c = f.Method as Card;

                    this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.CARD;

                    this.cardTypeInputComboBox.SelectedIndex = c.Debit ? 0 : 1;
                    this.providerInputTextBox.Text = c.Provider;
                    this.cardNumberMaskedTextBox.Text = c.Number.ToString();
                    this.cardNameInputTextBox.Text = c.Name;
                }
                else if (f.Method is DirectDeposit)
                {
                    DirectDeposit d = f.Method as DirectDeposit;

                    this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.DIRECT_DEPOSIT;

                    this.accountTypeInputComboBox.SelectedIndex = d.Savings ? 0 : 1;
                    this.bankNameInputTextBox.Text = d.BankName;
                    this.accountNumberInputMaskedTextBox.Text = d.Number.ToString();
                    this.accountNameInputTextBox.Text = d.Name;
                }
            }

            if (f.MinValue != float.MinValue)
            {
                this.lowerBoundAmountInputTextBox.Text = f.MinValue.ToString();
                this.lowerBoundAmountLabelButton.PerformClick();
            }

            if (f.MaxValue != float.MaxValue)
            {
                this.upperBoundAmountInputTextBox.Text = f.MaxValue.ToString();
                this.upperBoundAmountLabelButton.PerformClick();
            }

            if (f.Place.Count > 0)
            {
                this.placesInputTextBox.Text = string.Join(", ", f.Place);
                this.placesLabelButton.PerformClick();
            }

            if (f.Tag.Count > 0)
            {
                this.tagsInputTextBox.Text = string.Join(", ", f.Tag);
                this.tagsLabelButton.PerformClick();
            }

            if (f.Keywords.Count > 0)
            {
                this.notesInputTextBox.Text = string.Join(", ", f.Keywords);
                this.keywordsLabelButton.PerformClick();
            }
        }

        /// <summary>
        /// Describes the index representations of the <see cref="purchaseMethodSelectComboBox"/>.
        /// </summary>
        private enum EPurchaseMethodIndex
        {
            /// <summary>
            /// Index of Cash in combo box.
            /// </summary>
            CASH = 0,

            /// <summary>
            /// Index of Card in combo box.
            /// </summary>
            CARD,

            /// <summary>
            /// Index of Direct Deposit in combo box.
            /// </summary>
            DIRECT_DEPOSIT,
        }

        /// <summary>
        /// Gets the data of the expense which has been either created or edited by the form.
        /// </summary>
        public ExpenseFilter ExpenseFilter
        {
            get;
            private set;
        }

        /// <summary>
        /// Initializes all form elements to required starting state.
        /// </summary>
        private void InitializeForm()
        {
            this.lowerBoundDateTimePicker.Enabled = false;
            this.upperBoundDateTimePicker.Enabled = false;

            this.purchaseMethodSelectComboBox.Enabled = false;
            this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.CARD;

            this.DisableAndHideControl(this.currencyLabelTextBox);
            this.DisableAndHideControl(this.currencyInputComboBox);

            this.DisableAndHideControl(this.cardTypeLabelTextBox);
            this.DisableAndHideControl(this.cardTypeInputComboBox);

            this.DisableAndHideControl(this.providerLabelTextBox);
            this.DisableAndHideControl(this.providerInputTextBox);

            this.DisableAndHideControl(this.cardNumberLabelTextBox);
            this.DisableAndHideControl(this.cardNumberMaskedTextBox);

            this.DisableAndHideControl(this.cardNameLabelTextBox);
            this.DisableAndHideControl(this.cardNameInputTextBox);

            this.DisableAndHideControl(this.accountTypeLabelTextBox);
            this.DisableAndHideControl(this.accountTypeInputComboBox);

            this.DisableAndHideControl(this.bankNameLabelTextBox);
            this.DisableAndHideControl(this.bankNameInputTextBox);

            this.DisableAndHideControl(this.accountNumberLabelTextBox);
            this.DisableAndHideControl(this.accountNumberInputMaskedTextBox);

            this.DisableAndHideControl(this.accountNameLabelTextBox);
            this.DisableAndHideControl(this.accountNameInputTextBox);

            this.lowerBoundAmountInputTextBox.Enabled = false;
            this.upperBoundAmountInputTextBox.Enabled = false;
            this.placesInputTextBox.Enabled = false;
            this.tagsInputTextBox.Enabled = false;
            this.notesInputTextBox.Enabled = false;
        }

        /// <summary>
        /// Show an error msg.
        /// </summary>
        /// <param name="msg">Message to be shown.</param>
        private void ShowFormError(string msg)
        {
            if (string.IsNullOrEmpty(this.errorMessageTextBox.Text))
            {
                this.errorMessageTextBox.Text = msg;
                this.EnableAndViewControl(this.errorMessageTextBox);
            }
            else
            {
                this.errorMessageTextBox.Text = this.errorMessageTextBox.Text + "\n" + msg;
            }
        }

        /// <summary>
        /// Hide an error msg.
        /// </summary>
        private void HideFormError()
        {
            this.errorMessageTextBox.Text = string.Empty;
            this.DisableAndHideControl(this.errorMessageTextBox);
        }

        /// <summary>
        /// Enables and makes the specified control visible.
        /// </summary>
        /// <param name="c">Control to modify.</param>
        private void EnableAndViewControl(Control c)
        {
            c.Enabled = true;
            c.Visible = true;
        }

        /// <summary>
        /// Disables and makes the specified control invisible.
        /// </summary>
        /// <param name="c">Control to modify.</param>
        private void DisableAndHideControl(Control c)
        {
            c.Enabled = false;
            c.Visible = false;
        }

        /// <summary>
        /// Checks that all inputs are valid. If they are not false is returned and the <see cref="errorMessageTextBox"/> field is populated with the errors and made visible.
        /// </summary>
        /// <returns>True if inputs are valid. false otherwise.</returns>
        private bool InputsAreValid()
        {
            bool isError = false;

            // Name checks
            if (!Regex.IsMatch(this.filterNameInputTextBox.Text, @"^[a-zA-Z\s,\.\-\d]+$"))
            {
                // do error state: must enter a valid name field
                this.ShowFormError(string.Format(
                    "Error in {0}: \"{1}\" is either empty or contains illegal characters. May only contain alphanumeric characters, periods, or hyphens",
                    this.filterNameLabelTextBox.Text,
                    this.filterNameInputTextBox.Text));
                isError = true;
            }

            // Lower Bound Amount field checks
            if (this.lowerBoundAmountInputTextBox.Enabled &&
                !float.TryParse(this.lowerBoundAmountInputTextBox.Text, out _))
            {
                // do error state: amount must be parsable.
                this.ShowFormError(string.Format(
                    "Error in {0}: Must enter a valid decimal number.",
                    this.lowerBoundAmountLabelButton.Text));
                isError = true;
            }

            // Upper Bound Amount field checks
            if (this.upperBoundAmountInputTextBox.Enabled &&
                !float.TryParse(this.upperBoundAmountInputTextBox.Text, out _))
            {
                // do error state: amount must be parsable.
                this.ShowFormError(string.Format(
                    "Error in {0}: Must enter a valid decimal number.",
                    this.upperBoundAmountLabelButton.Text));
                isError = true;
            }

            // Places field checks
            if (this.placesInputTextBox.Enabled &&
                !Regex.IsMatch(this.placesInputTextBox.Text, @"^([a-zA-Z\s]+)(,[a-zA-Z\s]+)*$"))
            {
                // do error state: must enter a valid comma seperated list containing only characters and whitespace
                this.ShowFormError(string.Format(
                    "Error in {0}: \"{1}\" must be presented in the form \"<place>,<place>...\".",
                    this.placesLabelButton.Text,
                    this.placesInputTextBox.Text));
                isError = true;
            }

            // tag field checks
            if (this.tagsInputTextBox.Enabled &&
                !Regex.IsMatch(this.tagsInputTextBox.Text, @"^([a-zA-Z\s]+)(,[a-zA-Z\s]+)*$"))
            {
                // do error state: must enter a valid comma seperated list containing only characters and whitespace
                this.ShowFormError(string.Format(
                    "Error in {0}: \"{1}\" must be presented in the form \"<tag>,<tag>...\".",
                    this.tagsLabelButton.Text,
                    this.tagsInputTextBox.Text));
                isError = true;
            }

            // notes field checks
            if (this.notesInputTextBox.Enabled &&
                !Regex.IsMatch(this.notesInputTextBox.Text, @"^([a-zA-Z\s]+)(,[a-zA-Z\s]+)*$"))
            {
                // do error state: must enter a valid comma seperated list containing only characters and whitespace
                this.ShowFormError(string.Format(
                    "Error in {0}: \"{1}\" must be presented in the form \"<keyword>,<keyword>...\".",
                    this.keywordsLabelButton.Text,
                    this.notesInputTextBox.Text));
                isError = true;
            }

            // purchase method checks
            if (this.purchaseMethodSelectComboBox.Enabled)
            {
                switch ((EPurchaseMethodIndex)this.purchaseMethodSelectComboBox.SelectedIndex)
                {
                    case EPurchaseMethodIndex.CASH:

                        // currency input check.
                        if (!Regex.IsMatch(this.currencyInputComboBox.Text, @"^[a-zA-Z\s,\.\-\d]+$"))
                        {
                            // do error state: must enter a valid notes field
                            this.ShowFormError(string.Format(
                                "Error in {0}: {1} is either empty or contains illegal characters. May only contain alphanumeric characters, periods, or hyphens",
                                this.currencyLabelTextBox.Text,
                                this.currencyInputComboBox.Text));
                            isError = true;
                        }

                        break;

                    case EPurchaseMethodIndex.CARD:

                        // provider check
                        if (!Regex.IsMatch(this.providerInputTextBox.Text, @"^[a-zA-Z\s,\.\-\d]+$"))
                        {
                            // do error state: must enter a valid notes field
                            this.ShowFormError(string.Format(
                                "Error in {0}: {1} is either empty or contains illegal characters. May only contain alphanumeric characters, periods, or hyphens",
                                this.providerLabelTextBox.Text,
                                this.providerInputTextBox.Text));
                            isError = true;
                        }

                        // card number check
                        if (string.IsNullOrEmpty(this.cardNumberMaskedTextBox.Text))
                        {
                            // do error state: must enter a value for card number
                            this.ShowFormError(string.Format(
                                "Error in {0}: Must enter a value.",
                                this.cardNumberLabelTextBox.Text));
                            isError = true;
                        }

                        // cardholder check
                        if (!Regex.IsMatch(this.cardNameInputTextBox.Text, @"^[a-zA-Z,\.'\-\s]+$"))
                        {
                            // do error state: must enter a valid notes field
                            this.ShowFormError(string.Format(
                                "Error in {0}: {1} is either empty or contains illegal characters. May only contain alphanumeric characters, periods, commas, apostraphes, or hyphens",
                                this.cardNameLabelTextBox.Text,
                                this.cardNameInputTextBox.Text));
                            isError = true;
                        }

                        break;

                    case EPurchaseMethodIndex.DIRECT_DEPOSIT:

                        // bankname check
                        if (!Regex.IsMatch(this.bankNameInputTextBox.Text, @"^[a-zA-Z\s,\.\-\d]+$"))
                        {
                            // do error state: must enter a valid notes field
                            this.ShowFormError(string.Format(
                                "Error in {0}: {1} is either empty or contains illegal characters. May only contain alphanumeric characters, periods, or hyphens",
                                this.bankNameLabelTextBox.Text,
                                this.bankNameInputTextBox.Text));
                            isError = true;
                        }

                        // account name check
                        if (!Regex.IsMatch(this.accountNameInputTextBox.Text, @"^[a-zA-Z,\.'\-\s]+$"))
                        {
                            // do error state: must enter a valid notes field
                            this.ShowFormError(string.Format(
                                "Error in {0}: {1} is either empty or contains illegal characters. May only contain alphanumeric characters, periods, commas, apostraphes, or hyphens",
                                this.accountNameLabelTextBox.Text,
                                this.accountNameInputTextBox.Text));
                            isError = true;
                        }

                        break;

                    default:
                        Console.WriteLine("Error: unhandled purchase method passed");
                        throw new InvalidEnumArgumentException("Error: unhandled purchase method passed");
                }
            }

            return !isError;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            // wipe last attempt
            this.HideFormError();

            // do data checks here.
            if (!this.InputsAreValid())
            {
                return;
            }

            // if data checks pass assign all values to expense and pass back dialog ok result.
            string name;
            HashSet<string> places = new HashSet<string>(), tags = new HashSet<string>(), keywords = new HashSet<string>();
            DateTime maxDate = DateTime.MaxValue, minDate = DateTime.MinValue;
            float maxValue = float.MaxValue, minValue = float.MinValue;
            PurchaseMethod p = null;

            name = this.filterNameInputTextBox.Text;

            if (this.lowerBoundDateTimePicker.Enabled)
            {
                minDate = this.lowerBoundDateTimePicker.Value;
            }

            if (this.upperBoundDateTimePicker.Enabled)
            {
                maxDate = this.upperBoundDateTimePicker.Value;
            }

            if (this.lowerBoundAmountInputTextBox.Enabled)
            {
                minValue = float.Parse(this.lowerBoundAmountInputTextBox.Text);
            }

            if (this.upperBoundAmountInputTextBox.Enabled)
            {
                maxValue = float.Parse(this.upperBoundAmountInputTextBox.Text);
            }

            if (this.placesInputTextBox.Enabled)
            {
                places = new HashSet<string>(from string place in this.placesInputTextBox.Text.Split(',') select place.Trim());
            }

            if (this.tagsInputTextBox.Enabled)
            {
                tags = new HashSet<string>(from string tag in this.tagsInputTextBox.Text.Split(',') select tag.Trim());
            }

            if (this.notesInputTextBox.Enabled)
            {
                keywords = new HashSet<string>(from string keyword in this.notesInputTextBox.Text.Split(',') select keyword.Trim());
            }

            if (this.purchaseMethodSelectComboBox.Enabled)
            {
                switch ((EPurchaseMethodIndex)this.purchaseMethodSelectComboBox.SelectedIndex)
                {
                    case EPurchaseMethodIndex.CASH:
                        p = new Cash(
                            this.currencyInputComboBox.Text);
                        break;

                    case EPurchaseMethodIndex.CARD:
                        p = new Card(
                            this.cardTypeInputComboBox.SelectedIndex == 0 ? true : false,
                            this.providerInputTextBox.Text.Trim(),
                            int.Parse(this.cardNumberMaskedTextBox.Text),
                            this.cardNameInputTextBox.Text.Trim());
                        break;

                    case EPurchaseMethodIndex.DIRECT_DEPOSIT:
                        p = new DirectDeposit(
                            this.accountTypeInputComboBox.SelectedIndex == 0 ? true : false,
                            this.bankNameInputTextBox.Text.Trim(),
                            int.Parse(this.accountNumberInputMaskedTextBox.Text),
                            this.accountNameInputTextBox.Text.Trim());
                        break;

                    default:
                        Console.WriteLine("Error: unhandled purchase method passed");
                        throw new InvalidEnumArgumentException("Error: unhandled purchase method passed");
                }
            }
            else
            {
                p = null;
            }

            if (this.ExpenseFilter == null)
            {
                this.ExpenseFilter = new ExpenseFilter(
                    name,
                    maxValue,
                    minValue,
                    maxDate,
                    minDate,
                    places,
                    tags,
                    keywords,
                    p);
            }
            else
            {
                this.ExpenseFilter.MinValue = minValue;
                this.ExpenseFilter.MaxValue = maxValue;
                this.ExpenseFilter.MinDate = minDate;
                this.ExpenseFilter.MaxDate = maxDate;
                this.ExpenseFilter.Place = places;
                this.ExpenseFilter.Tag = tags;
                this.ExpenseFilter.Keywords = keywords;
                this.ExpenseFilter.Method = p;
            }

            // Set the ok result and close the form.
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        /// <summary>
        /// Fires when the cancel button is clicked. Abandons all work and sets the dialog result cancel.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void CancelButton_Click(object sender, EventArgs e)
        {
            // Set the cancel result and close the form.
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        /// <summary>
        /// Fires when the selected index is changed. Updates the form accordingly.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void purchaseMethodSelectComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.purchaseMethodSelectComboBox.SelectedIndex == (int)EPurchaseMethodIndex.CASH)
            {
                this.EnableAndViewControl(this.currencyLabelTextBox);
                this.EnableAndViewControl(this.currencyInputComboBox);

                this.DisableAndHideControl(this.cardTypeLabelTextBox);
                this.DisableAndHideControl(this.cardTypeInputComboBox);

                this.DisableAndHideControl(this.providerLabelTextBox);
                this.DisableAndHideControl(this.providerInputTextBox);

                this.DisableAndHideControl(this.cardNumberLabelTextBox);
                this.DisableAndHideControl(this.cardNumberMaskedTextBox);

                this.DisableAndHideControl(this.cardNameLabelTextBox);
                this.DisableAndHideControl(this.cardNameInputTextBox);

                this.DisableAndHideControl(this.accountTypeLabelTextBox);
                this.DisableAndHideControl(this.accountTypeInputComboBox);

                this.DisableAndHideControl(this.bankNameLabelTextBox);
                this.DisableAndHideControl(this.bankNameInputTextBox);

                this.DisableAndHideControl(this.accountNumberLabelTextBox);
                this.DisableAndHideControl(this.accountNumberInputMaskedTextBox);

                this.DisableAndHideControl(this.accountNameLabelTextBox);
                this.DisableAndHideControl(this.accountNameInputTextBox);
            }
            else if (this.purchaseMethodSelectComboBox.SelectedIndex == (int)EPurchaseMethodIndex.CARD)
            {
                this.DisableAndHideControl(this.currencyLabelTextBox);
                this.DisableAndHideControl(this.currencyInputComboBox);

                this.EnableAndViewControl(this.cardTypeLabelTextBox);
                this.EnableAndViewControl(this.cardTypeInputComboBox);

                this.EnableAndViewControl(this.providerLabelTextBox);
                this.EnableAndViewControl(this.providerInputTextBox);

                this.EnableAndViewControl(this.cardNumberLabelTextBox);
                this.EnableAndViewControl(this.cardNumberMaskedTextBox);

                this.EnableAndViewControl(this.cardNameLabelTextBox);
                this.EnableAndViewControl(this.cardNameInputTextBox);

                this.DisableAndHideControl(this.accountTypeLabelTextBox);
                this.DisableAndHideControl(this.accountTypeInputComboBox);

                this.DisableAndHideControl(this.bankNameLabelTextBox);
                this.DisableAndHideControl(this.bankNameInputTextBox);

                this.DisableAndHideControl(this.accountNumberLabelTextBox);
                this.DisableAndHideControl(this.accountNumberInputMaskedTextBox);

                this.DisableAndHideControl(this.accountNameLabelTextBox);
                this.DisableAndHideControl(this.accountNameInputTextBox);
            }
            else if (this.purchaseMethodSelectComboBox.SelectedIndex == (int)EPurchaseMethodIndex.DIRECT_DEPOSIT)
            {
                this.DisableAndHideControl(this.currencyLabelTextBox);
                this.DisableAndHideControl(this.currencyInputComboBox);

                this.DisableAndHideControl(this.cardTypeLabelTextBox);
                this.DisableAndHideControl(this.cardTypeInputComboBox);

                this.DisableAndHideControl(this.providerLabelTextBox);
                this.DisableAndHideControl(this.providerInputTextBox);

                this.DisableAndHideControl(this.cardNumberLabelTextBox);
                this.DisableAndHideControl(this.cardNumberMaskedTextBox);

                this.DisableAndHideControl(this.cardNameLabelTextBox);
                this.DisableAndHideControl(this.cardNameInputTextBox);

                this.EnableAndViewControl(this.accountTypeLabelTextBox);
                this.EnableAndViewControl(this.accountTypeInputComboBox);

                this.EnableAndViewControl(this.bankNameLabelTextBox);
                this.EnableAndViewControl(this.bankNameInputTextBox);

                this.EnableAndViewControl(this.accountNumberLabelTextBox);
                this.EnableAndViewControl(this.accountNumberInputMaskedTextBox);

                this.EnableAndViewControl(this.accountNameLabelTextBox);
                this.EnableAndViewControl(this.accountNameInputTextBox);
            }
        }

        private void lowerBoundDateLabelButton_Click(object sender, EventArgs e)
        {
            this.lowerBoundDateTimePicker.Enabled = !this.lowerBoundDateTimePicker.Enabled;
        }

        private void upperBoundDateLabelButton_Click(object sender, EventArgs e)
        {
            this.upperBoundDateTimePicker.Enabled = !this.upperBoundDateTimePicker.Enabled;
        }

        private void purchaseMethodLabelButton_Click(object sender, EventArgs e)
        {
            this.purchaseMethodSelectComboBox.Enabled = !this.purchaseMethodSelectComboBox.Enabled;
            if (this.purchaseMethodSelectComboBox.Enabled)
            {
                // trigger event to show relevant fields.
                this.purchaseMethodSelectComboBox.SelectedIndex = this.purchaseMethodSelectComboBox.SelectedIndex;
            }
            else
            {
                // hide and disable everything.
                this.DisableAndHideControl(this.currencyLabelTextBox);
                this.DisableAndHideControl(this.currencyInputComboBox);

                this.DisableAndHideControl(this.cardTypeLabelTextBox);
                this.DisableAndHideControl(this.cardTypeInputComboBox);

                this.DisableAndHideControl(this.providerLabelTextBox);
                this.DisableAndHideControl(this.providerInputTextBox);

                this.DisableAndHideControl(this.cardNumberLabelTextBox);
                this.DisableAndHideControl(this.cardNumberMaskedTextBox);

                this.DisableAndHideControl(this.cardNameLabelTextBox);
                this.DisableAndHideControl(this.cardNameInputTextBox);

                this.DisableAndHideControl(this.accountTypeLabelTextBox);
                this.DisableAndHideControl(this.accountTypeInputComboBox);

                this.DisableAndHideControl(this.bankNameLabelTextBox);
                this.DisableAndHideControl(this.bankNameInputTextBox);

                this.DisableAndHideControl(this.accountNumberLabelTextBox);
                this.DisableAndHideControl(this.accountNumberInputMaskedTextBox);

                this.DisableAndHideControl(this.accountNameLabelTextBox);
                this.DisableAndHideControl(this.accountNameInputTextBox);
            }
        }

        private void lowerBoundAmountLabelButton_Click(object sender, EventArgs e)
        {
            this.lowerBoundAmountInputTextBox.Enabled = !this.lowerBoundAmountInputTextBox.Enabled;
        }

        private void upperBoundAmountLabelButton_Click(object sender, EventArgs e)
        {
            this.upperBoundAmountInputTextBox.Enabled = !this.upperBoundAmountInputTextBox.Enabled;
        }

        private void placesLabelButton_Click(object sender, EventArgs e)
        {
            this.placesInputTextBox.Enabled = !this.placesInputTextBox.Enabled;
        }

        private void tagsLabelButton_Click(object sender, EventArgs e)
        {
            this.tagsInputTextBox.Enabled = !this.tagsInputTextBox.Enabled;
        }

        private void keywordsLabelButton_Click(object sender, EventArgs e)
        {
            this.notesInputTextBox.Enabled = !this.notesInputTextBox.Enabled;
        }
    }
}

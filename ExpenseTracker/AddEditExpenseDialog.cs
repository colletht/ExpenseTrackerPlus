// <copyright file="AddEditExpenseDialog.cs" company="Harrison Collet">
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
    public partial class AddEditExpenseDialog : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AddEditExpenseDialog"/> class.
        /// Default constructor. Constructs dialog in AddMode for brand new expense.
        /// </summary>
        public AddEditExpenseDialog()
        {
            this.InitializeComponent();

            // Set title to Add
            this.titleTextBox.Text = "Add a New Expense";

            this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.CARD;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="AddEditExpenseDialog"/> class.
        /// Edit constructor. Constructs dialog in EditMode for existing expense.
        /// </summary>
        /// <param name="e">The expense data to edit.</param>
        public AddEditExpenseDialog(Expense e)
        {
            this.InitializeComponent();

            // Set title to Edit
            this.titleTextBox.Text = "Edit an Existing Expense";

            // Assign values to those of passed expense
            this.dateTimePicker.Value = e.Date;

            // Assign purchase method.
            if (e.Method is Cash)
            {
                Cash c = e.Method as Cash;

                this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.CASH;

                this.currencyInputComboBox.Text = c.Currency;
            }
            else if (e.Method is Card)
            {
                Card c = e.Method as Card;

                this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.CARD;

                this.cardTypeInputComboBox.SelectedIndex = c.Debit ? 0 : 1;
                this.providerInputTextBox.Text = c.Provider;
                this.cardNumberMaskedTextBox.Text = c.Number.ToString();
                this.cardNameInputTextBox.Text = c.Name;
            }
            else if (e.Method is DirectDeposit)
            {
                DirectDeposit d = e.Method as DirectDeposit;

                this.purchaseMethodSelectComboBox.SelectedIndex = (int)EPurchaseMethodIndex.DIRECT_DEPOSIT;

                this.accountTypeInputComboBox.SelectedIndex = d.Savings ? 0 : 1;
                this.bankNameInputTextBox.Text = d.BankName;
                this.accountNumberInputMaskedTextBox.Text = d.Number.ToString();
                this.accountNameInputTextBox.Text = d.Name;
            }

            this.amountInputTextBox.Text = e.Value.ToString();
            this.placeInputTextBox.Text = e.Place;
            this.tagInputTextBox.Text = string.Join(", ", e.Tag);
            this.notesInputTextBox.Text = e.Notes;
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
        public Expense Expense
        {
            get;
            private set;
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

        private void EnableAndViewControl(Control c)
        {
            c.Enabled = true;
            c.Visible = true;
        }

        private void DisableAndHideControl(Control c)
        {
            c.Enabled = false;
            c.Visible = false;
        }

        /// <summary>
        /// Checks that all inputs are valid. If they are not false is returned and the <see cref="errorMessageTextBox.Text"/> field is populated with the errors and made visible.
        /// </summary>
        /// <returns>True if inputs are valid. false otherwise.</returns>
        private bool InputsAreValid()
        {
            bool isError = false;

            // Amount field checks
            if (string.IsNullOrWhiteSpace(this.amountLabelTextBox.Text))
            {
                // do error state: a value must be entered for amount.
                this.ShowFormError(string.Format(
                    "Error in {0}: Must enter a value.",
                    this.amountLabelTextBox.Text));
                isError = true;
            }

            if (!float.TryParse(this.amountInputTextBox.Text, out _))
            {
                // do error state: amount must be parsable.
                this.ShowFormError(string.Format(
                    "Error in {0}: Must enter a valid decimal number.",
                    this.amountLabelTextBox.Text));
                isError = true;
            }

            // Place field checks
            if (string.IsNullOrWhiteSpace(this.placeInputTextBox.Text))
            {
                // do error state: place must be entered.
                this.ShowFormError(string.Format(
                    "Error in {0}: Must enter a value.",
                    this.placeLabelTextBox.Text));
                isError = true;
            }

            // tag field checks
            if (string.IsNullOrWhiteSpace(this.tagInputTextBox.Text))
            {
                // do error state: must enter a value for tag
                this.ShowFormError(string.Format(
                    "Error in {0}: Must enter a value(s).",
                    this.tagLabelTextBox.Text));
                isError = true;
            }

            if (!Regex.IsMatch(this.tagInputTextBox.Text, @"^([a-zA-Z\s]+)(,[a-zA-Z\s]+)*$"))
            {
                // do error state: must enter a valid comma seperated list containing only characters and whitespace
                this.ShowFormError(string.Format(
                    "Error in {0}: {1} must be presented in the form \"<tag>,<tag>...\".",
                    this.tagLabelTextBox.Text,
                    this.tagInputTextBox.Text));
                isError = true;
            }

            // notes field checks
            if (!Regex.IsMatch(this.notesInputTextBox.Text, @"^[a-zA-Z\s,\.\-\d]+$"))
            {
                // do error state: must enter a valid notes field
                this.ShowFormError(string.Format(
                    "Error in {0}: {1} is either empty or contains illegal characters. May only contain alphanumeric characters, periods, or hyphens",
                    this.notesLabelTextBox.Text,
                    this.notesInputTextBox.Text));
                isError = true;
            }

            // purchase method checks
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
            PurchaseMethod p;

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

            this.Expense = new Expense(
                float.Parse(this.amountInputTextBox.Text),
                this.dateTimePicker.Value,
                this.placeInputTextBox.Text.Trim(),
                p,
                new HashSet<string>(from string tag in this.tagInputTextBox.Text.Split(',') select tag.Trim()),
                this.notesInputTextBox.Text.Trim());

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
    }
}

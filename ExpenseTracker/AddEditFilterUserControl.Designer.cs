namespace ExpenseTracker
{
    /// <summary>
    /// Partial definition of AddEditFilterUserControl.
    /// </summary>
    partial class AddEditFilterUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.accountTypeInputComboBox = new System.Windows.Forms.ComboBox();
            this.cardTypeInputComboBox = new System.Windows.Forms.ComboBox();
            this.currencyInputComboBox = new System.Windows.Forms.ComboBox();
            this.providerInputTextBox = new System.Windows.Forms.TextBox();
            this.cardNumberInputTextBox = new System.Windows.Forms.TextBox();
            this.cardNameInputTextBox = new System.Windows.Forms.TextBox();
            this.bankNameInputTextBox = new System.Windows.Forms.TextBox();
            this.accountNumberInputTextBox = new System.Windows.Forms.TextBox();
            this.accountNameInputTextBox = new System.Windows.Forms.TextBox();
            this.accountNameLabelTextBox = new System.Windows.Forms.TextBox();
            this.accountNumberLabelTextBox = new System.Windows.Forms.TextBox();
            this.bankNameLabelTextBox = new System.Windows.Forms.TextBox();
            this.accountTypeLabelTextBox = new System.Windows.Forms.TextBox();
            this.cardNameLabelTextBox = new System.Windows.Forms.TextBox();
            this.cardNumberLabelTextBox = new System.Windows.Forms.TextBox();
            this.providerLabelTextBox = new System.Windows.Forms.TextBox();
            this.cardTypeLabelTextBox = new System.Windows.Forms.TextBox();
            this.currencyLabelTextBox = new System.Windows.Forms.TextBox();
            this.purchaseMethodSelectComboBox = new System.Windows.Forms.ComboBox();
            this.notesInputTextBox = new System.Windows.Forms.TextBox();
            this.tagsInputTextBox = new System.Windows.Forms.TextBox();
            this.placesInputTextBox = new System.Windows.Forms.TextBox();
            this.upperBoundAmountInputTextBox = new System.Windows.Forms.TextBox();
            this.notesLabelTextBox = new System.Windows.Forms.TextBox();
            this.tagsLabelTextBox = new System.Windows.Forms.TextBox();
            this.purchaseMethodLabelTextBox = new System.Windows.Forms.TextBox();
            this.placesLabelTextBox = new System.Windows.Forms.TextBox();
            this.upperBoundAmountLabelTextBox = new System.Windows.Forms.TextBox();
            this.lowerBoundDateLabelTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.filterNameInputTextBox = new System.Windows.Forms.TextBox();
            this.filterNameLabelTextBox = new System.Windows.Forms.TextBox();
            this.lowerBoundDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.upperBoundDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.upperBoundDateLabelTextBox = new System.Windows.Forms.TextBox();
            this.lowerBoundAmountLabelTextBox = new System.Windows.Forms.TextBox();
            this.lowerBoundAmountInputTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // accountTypeInputComboBox
            // 
            this.accountTypeInputComboBox.DisplayMember = "Text";
            this.accountTypeInputComboBox.FormattingEnabled = true;
            this.accountTypeInputComboBox.Items.AddRange(new object[] {
            "Savings",
            "Checking"});
            this.accountTypeInputComboBox.Location = new System.Drawing.Point(248, 308);
            this.accountTypeInputComboBox.Name = "accountTypeInputComboBox";
            this.accountTypeInputComboBox.Size = new System.Drawing.Size(239, 21);
            this.accountTypeInputComboBox.TabIndex = 66;
            this.accountTypeInputComboBox.ValueMember = "Text";
            // 
            // cardTypeInputComboBox
            // 
            this.cardTypeInputComboBox.DisplayMember = "Text";
            this.cardTypeInputComboBox.FormattingEnabled = true;
            this.cardTypeInputComboBox.Items.AddRange(new object[] {
            "Debit",
            "Credit"});
            this.cardTypeInputComboBox.Location = new System.Drawing.Point(248, 205);
            this.cardTypeInputComboBox.Name = "cardTypeInputComboBox";
            this.cardTypeInputComboBox.Size = new System.Drawing.Size(239, 21);
            this.cardTypeInputComboBox.TabIndex = 65;
            this.cardTypeInputComboBox.ValueMember = "Text";
            // 
            // currencyInputComboBox
            // 
            this.currencyInputComboBox.DisplayMember = "Text";
            this.currencyInputComboBox.FormattingEnabled = true;
            this.currencyInputComboBox.Items.AddRange(new object[] {
            "USD - Dollars",
            "CAD - Canadian Dollars",
            "EUR - Euros"});
            this.currencyInputComboBox.Location = new System.Drawing.Point(248, 179);
            this.currencyInputComboBox.Name = "currencyInputComboBox";
            this.currencyInputComboBox.Size = new System.Drawing.Size(239, 21);
            this.currencyInputComboBox.TabIndex = 64;
            this.currencyInputComboBox.ValueMember = "Text";
            // 
            // providerInputTextBox
            // 
            this.providerInputTextBox.Location = new System.Drawing.Point(248, 231);
            this.providerInputTextBox.Name = "providerInputTextBox";
            this.providerInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.providerInputTextBox.TabIndex = 63;
            // 
            // cardNumberInputTextBox
            // 
            this.cardNumberInputTextBox.Location = new System.Drawing.Point(248, 257);
            this.cardNumberInputTextBox.Name = "cardNumberInputTextBox";
            this.cardNumberInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNumberInputTextBox.TabIndex = 62;
            // 
            // cardNameInputTextBox
            // 
            this.cardNameInputTextBox.Location = new System.Drawing.Point(248, 283);
            this.cardNameInputTextBox.Name = "cardNameInputTextBox";
            this.cardNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNameInputTextBox.TabIndex = 61;
            // 
            // bankNameInputTextBox
            // 
            this.bankNameInputTextBox.Location = new System.Drawing.Point(248, 335);
            this.bankNameInputTextBox.Name = "bankNameInputTextBox";
            this.bankNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.bankNameInputTextBox.TabIndex = 60;
            // 
            // accountNumberInputTextBox
            // 
            this.accountNumberInputTextBox.Location = new System.Drawing.Point(248, 361);
            this.accountNumberInputTextBox.Name = "accountNumberInputTextBox";
            this.accountNumberInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNumberInputTextBox.TabIndex = 59;
            // 
            // accountNameInputTextBox
            // 
            this.accountNameInputTextBox.Location = new System.Drawing.Point(248, 387);
            this.accountNameInputTextBox.Name = "accountNameInputTextBox";
            this.accountNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNameInputTextBox.TabIndex = 58;
            // 
            // accountNameLabelTextBox
            // 
            this.accountNameLabelTextBox.Location = new System.Drawing.Point(3, 387);
            this.accountNameLabelTextBox.Name = "accountNameLabelTextBox";
            this.accountNameLabelTextBox.ReadOnly = true;
            this.accountNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNameLabelTextBox.TabIndex = 57;
            this.accountNameLabelTextBox.Text = "Account Holder Name:";
            // 
            // accountNumberLabelTextBox
            // 
            this.accountNumberLabelTextBox.Location = new System.Drawing.Point(3, 361);
            this.accountNumberLabelTextBox.Name = "accountNumberLabelTextBox";
            this.accountNumberLabelTextBox.ReadOnly = true;
            this.accountNumberLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNumberLabelTextBox.TabIndex = 56;
            this.accountNumberLabelTextBox.Text = "Last Six Digits of Account Number:";
            // 
            // bankNameLabelTextBox
            // 
            this.bankNameLabelTextBox.Location = new System.Drawing.Point(3, 335);
            this.bankNameLabelTextBox.Name = "bankNameLabelTextBox";
            this.bankNameLabelTextBox.ReadOnly = true;
            this.bankNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.bankNameLabelTextBox.TabIndex = 55;
            this.bankNameLabelTextBox.Text = "Bank Name:";
            // 
            // accountTypeLabelTextBox
            // 
            this.accountTypeLabelTextBox.Location = new System.Drawing.Point(3, 309);
            this.accountTypeLabelTextBox.Name = "accountTypeLabelTextBox";
            this.accountTypeLabelTextBox.ReadOnly = true;
            this.accountTypeLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountTypeLabelTextBox.TabIndex = 54;
            this.accountTypeLabelTextBox.Text = "Account Type:";
            // 
            // cardNameLabelTextBox
            // 
            this.cardNameLabelTextBox.Location = new System.Drawing.Point(3, 283);
            this.cardNameLabelTextBox.Name = "cardNameLabelTextBox";
            this.cardNameLabelTextBox.ReadOnly = true;
            this.cardNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNameLabelTextBox.TabIndex = 53;
            this.cardNameLabelTextBox.Text = "Cardholder Name:";
            // 
            // cardNumberLabelTextBox
            // 
            this.cardNumberLabelTextBox.Location = new System.Drawing.Point(3, 257);
            this.cardNumberLabelTextBox.Name = "cardNumberLabelTextBox";
            this.cardNumberLabelTextBox.ReadOnly = true;
            this.cardNumberLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNumberLabelTextBox.TabIndex = 52;
            this.cardNumberLabelTextBox.Text = "Last Four Digits of Card Number:";
            // 
            // providerLabelTextBox
            // 
            this.providerLabelTextBox.Location = new System.Drawing.Point(3, 231);
            this.providerLabelTextBox.Name = "providerLabelTextBox";
            this.providerLabelTextBox.ReadOnly = true;
            this.providerLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.providerLabelTextBox.TabIndex = 51;
            this.providerLabelTextBox.Text = "Provider:";
            // 
            // cardTypeLabelTextBox
            // 
            this.cardTypeLabelTextBox.Location = new System.Drawing.Point(3, 205);
            this.cardTypeLabelTextBox.Name = "cardTypeLabelTextBox";
            this.cardTypeLabelTextBox.ReadOnly = true;
            this.cardTypeLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardTypeLabelTextBox.TabIndex = 50;
            this.cardTypeLabelTextBox.Text = "Card Type:";
            // 
            // currencyLabelTextBox
            // 
            this.currencyLabelTextBox.Location = new System.Drawing.Point(3, 179);
            this.currencyLabelTextBox.Name = "currencyLabelTextBox";
            this.currencyLabelTextBox.ReadOnly = true;
            this.currencyLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.currencyLabelTextBox.TabIndex = 49;
            this.currencyLabelTextBox.Text = "Currency";
            // 
            // purchaseMethodSelectComboBox
            // 
            this.purchaseMethodSelectComboBox.DisplayMember = "Text";
            this.purchaseMethodSelectComboBox.FormattingEnabled = true;
            this.purchaseMethodSelectComboBox.Items.AddRange(new object[] {
            "Cash",
            "Debit/Credit",
            "Direct Deposit"});
            this.purchaseMethodSelectComboBox.Location = new System.Drawing.Point(3, 152);
            this.purchaseMethodSelectComboBox.Name = "purchaseMethodSelectComboBox";
            this.purchaseMethodSelectComboBox.Size = new System.Drawing.Size(239, 21);
            this.purchaseMethodSelectComboBox.TabIndex = 48;
            this.purchaseMethodSelectComboBox.ValueMember = "Text";
            // 
            // notesInputTextBox
            // 
            this.notesInputTextBox.Location = new System.Drawing.Point(248, 519);
            this.notesInputTextBox.Multiline = true;
            this.notesInputTextBox.Name = "notesInputTextBox";
            this.notesInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.notesInputTextBox.TabIndex = 47;
            // 
            // tagsInputTextBox
            // 
            this.tagsInputTextBox.Location = new System.Drawing.Point(248, 493);
            this.tagsInputTextBox.Name = "tagsInputTextBox";
            this.tagsInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.tagsInputTextBox.TabIndex = 46;
            // 
            // placesInputTextBox
            // 
            this.placesInputTextBox.Location = new System.Drawing.Point(248, 467);
            this.placesInputTextBox.Name = "placesInputTextBox";
            this.placesInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.placesInputTextBox.TabIndex = 45;
            // 
            // upperBoundAmountInputTextBox
            // 
            this.upperBoundAmountInputTextBox.Location = new System.Drawing.Point(248, 441);
            this.upperBoundAmountInputTextBox.Name = "upperBoundAmountInputTextBox";
            this.upperBoundAmountInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.upperBoundAmountInputTextBox.TabIndex = 44;
            // 
            // notesLabelTextBox
            // 
            this.notesLabelTextBox.Location = new System.Drawing.Point(3, 519);
            this.notesLabelTextBox.Name = "notesLabelTextBox";
            this.notesLabelTextBox.ReadOnly = true;
            this.notesLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.notesLabelTextBox.TabIndex = 42;
            this.notesLabelTextBox.Text = "Notes Keywords:";
            // 
            // tagsLabelTextBox
            // 
            this.tagsLabelTextBox.Location = new System.Drawing.Point(3, 493);
            this.tagsLabelTextBox.Name = "tagsLabelTextBox";
            this.tagsLabelTextBox.ReadOnly = true;
            this.tagsLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.tagsLabelTextBox.TabIndex = 41;
            this.tagsLabelTextBox.Text = "Possible Tags:";
            // 
            // purchaseMethodLabelTextBox
            // 
            this.purchaseMethodLabelTextBox.Location = new System.Drawing.Point(3, 125);
            this.purchaseMethodLabelTextBox.Name = "purchaseMethodLabelTextBox";
            this.purchaseMethodLabelTextBox.ReadOnly = true;
            this.purchaseMethodLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.purchaseMethodLabelTextBox.TabIndex = 40;
            this.purchaseMethodLabelTextBox.Text = "Purchase Method:";
            // 
            // placesLabelTextBox
            // 
            this.placesLabelTextBox.Location = new System.Drawing.Point(3, 467);
            this.placesLabelTextBox.Name = "placesLabelTextBox";
            this.placesLabelTextBox.ReadOnly = true;
            this.placesLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.placesLabelTextBox.TabIndex = 39;
            this.placesLabelTextBox.Text = "Possible Places:";
            // 
            // upperBoundAmountLabelTextBox
            // 
            this.upperBoundAmountLabelTextBox.Location = new System.Drawing.Point(3, 441);
            this.upperBoundAmountLabelTextBox.Name = "upperBoundAmountLabelTextBox";
            this.upperBoundAmountLabelTextBox.ReadOnly = true;
            this.upperBoundAmountLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.upperBoundAmountLabelTextBox.TabIndex = 38;
            this.upperBoundAmountLabelTextBox.Text = "Upper Bound Amount:";
            // 
            // lowerBoundDateLabelTextBox
            // 
            this.lowerBoundDateLabelTextBox.Location = new System.Drawing.Point(3, 73);
            this.lowerBoundDateLabelTextBox.Name = "lowerBoundDateLabelTextBox";
            this.lowerBoundDateLabelTextBox.ReadOnly = true;
            this.lowerBoundDateLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.lowerBoundDateLabelTextBox.TabIndex = 37;
            this.lowerBoundDateLabelTextBox.Text = "Lower Bound Date:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(3, 3);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(498, 38);
            this.titleTextBox.TabIndex = 36;
            this.titleTextBox.Text = "Add/Edit a Filter";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(248, 546);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 35;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(167, 546);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 34;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            // 
            // filterNameInputTextBox
            // 
            this.filterNameInputTextBox.Location = new System.Drawing.Point(248, 47);
            this.filterNameInputTextBox.Name = "filterNameInputTextBox";
            this.filterNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.filterNameInputTextBox.TabIndex = 68;
            // 
            // filterNameLabelTextBox
            // 
            this.filterNameLabelTextBox.Location = new System.Drawing.Point(3, 47);
            this.filterNameLabelTextBox.Name = "filterNameLabelTextBox";
            this.filterNameLabelTextBox.ReadOnly = true;
            this.filterNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.filterNameLabelTextBox.TabIndex = 67;
            this.filterNameLabelTextBox.Text = "Filter Name:";
            // 
            // lowerBoundDateTimePicker
            // 
            this.lowerBoundDateTimePicker.Location = new System.Drawing.Point(248, 73);
            this.lowerBoundDateTimePicker.Name = "lowerBoundDateTimePicker";
            this.lowerBoundDateTimePicker.Size = new System.Drawing.Size(239, 20);
            this.lowerBoundDateTimePicker.TabIndex = 69;
            // 
            // upperBoundDateTimePicker
            // 
            this.upperBoundDateTimePicker.Location = new System.Drawing.Point(248, 99);
            this.upperBoundDateTimePicker.Name = "upperBoundDateTimePicker";
            this.upperBoundDateTimePicker.Size = new System.Drawing.Size(239, 20);
            this.upperBoundDateTimePicker.TabIndex = 71;
            // 
            // upperBoundDateLabelTextBox
            // 
            this.upperBoundDateLabelTextBox.Location = new System.Drawing.Point(3, 99);
            this.upperBoundDateLabelTextBox.Name = "upperBoundDateLabelTextBox";
            this.upperBoundDateLabelTextBox.ReadOnly = true;
            this.upperBoundDateLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.upperBoundDateLabelTextBox.TabIndex = 70;
            this.upperBoundDateLabelTextBox.Text = "Upper Bound Date:";
            // 
            // lowerBoundAmountLabelTextBox
            // 
            this.lowerBoundAmountLabelTextBox.Location = new System.Drawing.Point(3, 415);
            this.lowerBoundAmountLabelTextBox.Name = "lowerBoundAmountLabelTextBox";
            this.lowerBoundAmountLabelTextBox.ReadOnly = true;
            this.lowerBoundAmountLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.lowerBoundAmountLabelTextBox.TabIndex = 38;
            this.lowerBoundAmountLabelTextBox.Text = "Lower Bound Amount:";
            // 
            // lowerBoundAmountInputTextBox
            // 
            this.lowerBoundAmountInputTextBox.Location = new System.Drawing.Point(248, 415);
            this.lowerBoundAmountInputTextBox.Name = "lowerBoundAmountInputTextBox";
            this.lowerBoundAmountInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.lowerBoundAmountInputTextBox.TabIndex = 44;
            // 
            // AddEditFilterUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.upperBoundDateTimePicker);
            this.Controls.Add(this.upperBoundDateLabelTextBox);
            this.Controls.Add(this.lowerBoundDateTimePicker);
            this.Controls.Add(this.filterNameInputTextBox);
            this.Controls.Add(this.filterNameLabelTextBox);
            this.Controls.Add(this.accountTypeInputComboBox);
            this.Controls.Add(this.cardTypeInputComboBox);
            this.Controls.Add(this.currencyInputComboBox);
            this.Controls.Add(this.providerInputTextBox);
            this.Controls.Add(this.cardNumberInputTextBox);
            this.Controls.Add(this.cardNameInputTextBox);
            this.Controls.Add(this.bankNameInputTextBox);
            this.Controls.Add(this.accountNumberInputTextBox);
            this.Controls.Add(this.accountNameInputTextBox);
            this.Controls.Add(this.accountNameLabelTextBox);
            this.Controls.Add(this.accountNumberLabelTextBox);
            this.Controls.Add(this.bankNameLabelTextBox);
            this.Controls.Add(this.accountTypeLabelTextBox);
            this.Controls.Add(this.cardNameLabelTextBox);
            this.Controls.Add(this.cardNumberLabelTextBox);
            this.Controls.Add(this.providerLabelTextBox);
            this.Controls.Add(this.cardTypeLabelTextBox);
            this.Controls.Add(this.currencyLabelTextBox);
            this.Controls.Add(this.purchaseMethodSelectComboBox);
            this.Controls.Add(this.notesInputTextBox);
            this.Controls.Add(this.tagsInputTextBox);
            this.Controls.Add(this.placesInputTextBox);
            this.Controls.Add(this.lowerBoundAmountInputTextBox);
            this.Controls.Add(this.upperBoundAmountInputTextBox);
            this.Controls.Add(this.notesLabelTextBox);
            this.Controls.Add(this.tagsLabelTextBox);
            this.Controls.Add(this.purchaseMethodLabelTextBox);
            this.Controls.Add(this.placesLabelTextBox);
            this.Controls.Add(this.lowerBoundAmountLabelTextBox);
            this.Controls.Add(this.upperBoundAmountLabelTextBox);
            this.Controls.Add(this.lowerBoundDateLabelTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Name = "AddEditFilterUserControl";
            this.Size = new System.Drawing.Size(506, 575);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox accountTypeInputComboBox;
        private System.Windows.Forms.ComboBox cardTypeInputComboBox;
        private System.Windows.Forms.ComboBox currencyInputComboBox;
        private System.Windows.Forms.TextBox providerInputTextBox;
        private System.Windows.Forms.TextBox cardNumberInputTextBox;
        private System.Windows.Forms.TextBox cardNameInputTextBox;
        private System.Windows.Forms.TextBox bankNameInputTextBox;
        private System.Windows.Forms.TextBox accountNumberInputTextBox;
        private System.Windows.Forms.TextBox accountNameInputTextBox;
        private System.Windows.Forms.TextBox accountNameLabelTextBox;
        private System.Windows.Forms.TextBox accountNumberLabelTextBox;
        private System.Windows.Forms.TextBox bankNameLabelTextBox;
        private System.Windows.Forms.TextBox accountTypeLabelTextBox;
        private System.Windows.Forms.TextBox cardNameLabelTextBox;
        private System.Windows.Forms.TextBox cardNumberLabelTextBox;
        private System.Windows.Forms.TextBox providerLabelTextBox;
        private System.Windows.Forms.TextBox cardTypeLabelTextBox;
        private System.Windows.Forms.TextBox currencyLabelTextBox;
        private System.Windows.Forms.ComboBox purchaseMethodSelectComboBox;
        private System.Windows.Forms.TextBox notesInputTextBox;
        private System.Windows.Forms.TextBox tagsInputTextBox;
        private System.Windows.Forms.TextBox placesInputTextBox;
        private System.Windows.Forms.TextBox upperBoundAmountInputTextBox;
        private System.Windows.Forms.TextBox notesLabelTextBox;
        private System.Windows.Forms.TextBox tagsLabelTextBox;
        private System.Windows.Forms.TextBox purchaseMethodLabelTextBox;
        private System.Windows.Forms.TextBox placesLabelTextBox;
        private System.Windows.Forms.TextBox upperBoundAmountLabelTextBox;
        private System.Windows.Forms.TextBox lowerBoundDateLabelTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TextBox filterNameInputTextBox;
        private System.Windows.Forms.TextBox filterNameLabelTextBox;
        private System.Windows.Forms.DateTimePicker lowerBoundDateTimePicker;
        private System.Windows.Forms.DateTimePicker upperBoundDateTimePicker;
        private System.Windows.Forms.TextBox upperBoundDateLabelTextBox;
        private System.Windows.Forms.TextBox lowerBoundAmountLabelTextBox;
        private System.Windows.Forms.TextBox lowerBoundAmountInputTextBox;
    }
}

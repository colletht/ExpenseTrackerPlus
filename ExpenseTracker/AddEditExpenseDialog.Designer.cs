namespace ExpenseTracker
{
    partial class AddEditExpenseDialog
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.dateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.accountTypeInputComboBox = new System.Windows.Forms.ComboBox();
            this.cardTypeInputComboBox = new System.Windows.Forms.ComboBox();
            this.currencyInputComboBox = new System.Windows.Forms.ComboBox();
            this.providerInputTextBox = new System.Windows.Forms.TextBox();
            this.cardNameInputTextBox = new System.Windows.Forms.TextBox();
            this.bankNameInputTextBox = new System.Windows.Forms.TextBox();
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
            this.tagInputTextBox = new System.Windows.Forms.TextBox();
            this.placeInputTextBox = new System.Windows.Forms.TextBox();
            this.amountInputTextBox = new System.Windows.Forms.TextBox();
            this.notesLabelTextBox = new System.Windows.Forms.TextBox();
            this.tagLabelTextBox = new System.Windows.Forms.TextBox();
            this.purchaseMethodLabelTextBox = new System.Windows.Forms.TextBox();
            this.placeLabelTextBox = new System.Windows.Forms.TextBox();
            this.amountLabelTextBox = new System.Windows.Forms.TextBox();
            this.dateLabelTextBox = new System.Windows.Forms.TextBox();
            this.titleTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.ConfirmButton = new System.Windows.Forms.Button();
            this.errorMessageTextBox = new System.Windows.Forms.TextBox();
            this.cardNumberMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.accountNumberInputMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // dateTimePicker
            // 
            this.dateTimePicker.Location = new System.Drawing.Point(258, 59);
            this.dateTimePicker.Name = "dateTimePicker";
            this.dateTimePicker.Size = new System.Drawing.Size(238, 20);
            this.dateTimePicker.TabIndex = 67;
            // 
            // accountTypeInputComboBox
            // 
            this.accountTypeInputComboBox.DisplayMember = "Text";
            this.accountTypeInputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.accountTypeInputComboBox.FormattingEnabled = true;
            this.accountTypeInputComboBox.Items.AddRange(new object[] {
            "Savings",
            "Checking"});
            this.accountTypeInputComboBox.Location = new System.Drawing.Point(257, 139);
            this.accountTypeInputComboBox.Name = "accountTypeInputComboBox";
            this.accountTypeInputComboBox.Size = new System.Drawing.Size(239, 21);
            this.accountTypeInputComboBox.TabIndex = 66;
            this.accountTypeInputComboBox.ValueMember = "Text";
            // 
            // cardTypeInputComboBox
            // 
            this.cardTypeInputComboBox.DisplayMember = "Text";
            this.cardTypeInputComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cardTypeInputComboBox.FormattingEnabled = true;
            this.cardTypeInputComboBox.Items.AddRange(new object[] {
            "Debit",
            "Credit"});
            this.cardTypeInputComboBox.Location = new System.Drawing.Point(257, 139);
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
            this.currencyInputComboBox.Location = new System.Drawing.Point(257, 139);
            this.currencyInputComboBox.Name = "currencyInputComboBox";
            this.currencyInputComboBox.Size = new System.Drawing.Size(239, 21);
            this.currencyInputComboBox.TabIndex = 64;
            this.currencyInputComboBox.ValueMember = "Text";
            // 
            // providerInputTextBox
            // 
            this.providerInputTextBox.Location = new System.Drawing.Point(257, 165);
            this.providerInputTextBox.Name = "providerInputTextBox";
            this.providerInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.providerInputTextBox.TabIndex = 63;
            // 
            // cardNameInputTextBox
            // 
            this.cardNameInputTextBox.Location = new System.Drawing.Point(257, 217);
            this.cardNameInputTextBox.Name = "cardNameInputTextBox";
            this.cardNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNameInputTextBox.TabIndex = 61;
            // 
            // bankNameInputTextBox
            // 
            this.bankNameInputTextBox.Location = new System.Drawing.Point(257, 166);
            this.bankNameInputTextBox.Name = "bankNameInputTextBox";
            this.bankNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.bankNameInputTextBox.TabIndex = 60;
            // 
            // accountNameInputTextBox
            // 
            this.accountNameInputTextBox.Location = new System.Drawing.Point(257, 218);
            this.accountNameInputTextBox.Name = "accountNameInputTextBox";
            this.accountNameInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNameInputTextBox.TabIndex = 58;
            // 
            // accountNameLabelTextBox
            // 
            this.accountNameLabelTextBox.Location = new System.Drawing.Point(12, 218);
            this.accountNameLabelTextBox.Name = "accountNameLabelTextBox";
            this.accountNameLabelTextBox.ReadOnly = true;
            this.accountNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNameLabelTextBox.TabIndex = 57;
            this.accountNameLabelTextBox.Text = "Account Holder Name:";
            // 
            // accountNumberLabelTextBox
            // 
            this.accountNumberLabelTextBox.Location = new System.Drawing.Point(12, 192);
            this.accountNumberLabelTextBox.Name = "accountNumberLabelTextBox";
            this.accountNumberLabelTextBox.ReadOnly = true;
            this.accountNumberLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountNumberLabelTextBox.TabIndex = 56;
            this.accountNumberLabelTextBox.Text = "Last Six Digits of Account Number:";
            // 
            // bankNameLabelTextBox
            // 
            this.bankNameLabelTextBox.Location = new System.Drawing.Point(12, 166);
            this.bankNameLabelTextBox.Name = "bankNameLabelTextBox";
            this.bankNameLabelTextBox.ReadOnly = true;
            this.bankNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.bankNameLabelTextBox.TabIndex = 55;
            this.bankNameLabelTextBox.Text = "Bank Name:";
            // 
            // accountTypeLabelTextBox
            // 
            this.accountTypeLabelTextBox.Location = new System.Drawing.Point(12, 140);
            this.accountTypeLabelTextBox.Name = "accountTypeLabelTextBox";
            this.accountTypeLabelTextBox.ReadOnly = true;
            this.accountTypeLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.accountTypeLabelTextBox.TabIndex = 54;
            this.accountTypeLabelTextBox.Text = "Account Type:";
            // 
            // cardNameLabelTextBox
            // 
            this.cardNameLabelTextBox.Location = new System.Drawing.Point(12, 217);
            this.cardNameLabelTextBox.Name = "cardNameLabelTextBox";
            this.cardNameLabelTextBox.ReadOnly = true;
            this.cardNameLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNameLabelTextBox.TabIndex = 53;
            this.cardNameLabelTextBox.Text = "Cardholder Name:";
            // 
            // cardNumberLabelTextBox
            // 
            this.cardNumberLabelTextBox.Location = new System.Drawing.Point(12, 191);
            this.cardNumberLabelTextBox.Name = "cardNumberLabelTextBox";
            this.cardNumberLabelTextBox.ReadOnly = true;
            this.cardNumberLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardNumberLabelTextBox.TabIndex = 52;
            this.cardNumberLabelTextBox.Text = "Last Four Digits of Card Number:";
            // 
            // providerLabelTextBox
            // 
            this.providerLabelTextBox.Location = new System.Drawing.Point(12, 165);
            this.providerLabelTextBox.Name = "providerLabelTextBox";
            this.providerLabelTextBox.ReadOnly = true;
            this.providerLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.providerLabelTextBox.TabIndex = 51;
            this.providerLabelTextBox.Text = "Provider:";
            // 
            // cardTypeLabelTextBox
            // 
            this.cardTypeLabelTextBox.Location = new System.Drawing.Point(12, 139);
            this.cardTypeLabelTextBox.Name = "cardTypeLabelTextBox";
            this.cardTypeLabelTextBox.ReadOnly = true;
            this.cardTypeLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.cardTypeLabelTextBox.TabIndex = 50;
            this.cardTypeLabelTextBox.Text = "Card Type:";
            // 
            // currencyLabelTextBox
            // 
            this.currencyLabelTextBox.Location = new System.Drawing.Point(12, 139);
            this.currencyLabelTextBox.Name = "currencyLabelTextBox";
            this.currencyLabelTextBox.ReadOnly = true;
            this.currencyLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.currencyLabelTextBox.TabIndex = 49;
            this.currencyLabelTextBox.Text = "Currency";
            // 
            // purchaseMethodSelectComboBox
            // 
            this.purchaseMethodSelectComboBox.DisplayMember = "Text";
            this.purchaseMethodSelectComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.purchaseMethodSelectComboBox.FormattingEnabled = true;
            this.purchaseMethodSelectComboBox.Items.AddRange(new object[] {
            "Cash",
            "Debit/Credit",
            "Direct Deposit"});
            this.purchaseMethodSelectComboBox.Location = new System.Drawing.Point(12, 112);
            this.purchaseMethodSelectComboBox.Name = "purchaseMethodSelectComboBox";
            this.purchaseMethodSelectComboBox.Size = new System.Drawing.Size(239, 21);
            this.purchaseMethodSelectComboBox.TabIndex = 48;
            this.purchaseMethodSelectComboBox.ValueMember = "Text";
            this.purchaseMethodSelectComboBox.SelectedIndexChanged += new System.EventHandler(this.purchaseMethodSelectComboBox_SelectedIndexChanged);
            // 
            // notesInputTextBox
            // 
            this.notesInputTextBox.Location = new System.Drawing.Point(257, 321);
            this.notesInputTextBox.Multiline = true;
            this.notesInputTextBox.Name = "notesInputTextBox";
            this.notesInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.notesInputTextBox.TabIndex = 47;
            // 
            // tagInputTextBox
            // 
            this.tagInputTextBox.Location = new System.Drawing.Point(257, 295);
            this.tagInputTextBox.Name = "tagInputTextBox";
            this.tagInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.tagInputTextBox.TabIndex = 46;
            // 
            // placeInputTextBox
            // 
            this.placeInputTextBox.Location = new System.Drawing.Point(257, 269);
            this.placeInputTextBox.Name = "placeInputTextBox";
            this.placeInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.placeInputTextBox.TabIndex = 45;
            // 
            // amountInputTextBox
            // 
            this.amountInputTextBox.Location = new System.Drawing.Point(257, 243);
            this.amountInputTextBox.Name = "amountInputTextBox";
            this.amountInputTextBox.Size = new System.Drawing.Size(239, 20);
            this.amountInputTextBox.TabIndex = 44;
            // 
            // notesLabelTextBox
            // 
            this.notesLabelTextBox.Location = new System.Drawing.Point(12, 321);
            this.notesLabelTextBox.Name = "notesLabelTextBox";
            this.notesLabelTextBox.ReadOnly = true;
            this.notesLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.notesLabelTextBox.TabIndex = 43;
            this.notesLabelTextBox.Text = "Notes:";
            // 
            // tagLabelTextBox
            // 
            this.tagLabelTextBox.Location = new System.Drawing.Point(12, 295);
            this.tagLabelTextBox.Name = "tagLabelTextBox";
            this.tagLabelTextBox.ReadOnly = true;
            this.tagLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.tagLabelTextBox.TabIndex = 42;
            this.tagLabelTextBox.Text = "Tag:";
            // 
            // purchaseMethodLabelTextBox
            // 
            this.purchaseMethodLabelTextBox.Location = new System.Drawing.Point(12, 85);
            this.purchaseMethodLabelTextBox.Name = "purchaseMethodLabelTextBox";
            this.purchaseMethodLabelTextBox.ReadOnly = true;
            this.purchaseMethodLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.purchaseMethodLabelTextBox.TabIndex = 41;
            this.purchaseMethodLabelTextBox.Text = "Purchase Method:";
            // 
            // placeLabelTextBox
            // 
            this.placeLabelTextBox.Location = new System.Drawing.Point(12, 269);
            this.placeLabelTextBox.Name = "placeLabelTextBox";
            this.placeLabelTextBox.ReadOnly = true;
            this.placeLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.placeLabelTextBox.TabIndex = 40;
            this.placeLabelTextBox.Text = "Place:";
            // 
            // amountLabelTextBox
            // 
            this.amountLabelTextBox.Location = new System.Drawing.Point(12, 243);
            this.amountLabelTextBox.Name = "amountLabelTextBox";
            this.amountLabelTextBox.ReadOnly = true;
            this.amountLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.amountLabelTextBox.TabIndex = 39;
            this.amountLabelTextBox.Text = "Amount:";
            // 
            // dateLabelTextBox
            // 
            this.dateLabelTextBox.Location = new System.Drawing.Point(12, 59);
            this.dateLabelTextBox.Name = "dateLabelTextBox";
            this.dateLabelTextBox.ReadOnly = true;
            this.dateLabelTextBox.Size = new System.Drawing.Size(239, 20);
            this.dateLabelTextBox.TabIndex = 38;
            this.dateLabelTextBox.Text = "Date:";
            // 
            // titleTextBox
            // 
            this.titleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleTextBox.Location = new System.Drawing.Point(12, 14);
            this.titleTextBox.Name = "titleTextBox";
            this.titleTextBox.Size = new System.Drawing.Size(498, 38);
            this.titleTextBox.TabIndex = 37;
            this.titleTextBox.Text = "Add/Edit an Expense";
            this.titleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CancelButton
            // 
            this.CancelButton.Location = new System.Drawing.Point(257, 348);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(75, 23);
            this.CancelButton.TabIndex = 36;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = true;
            this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // ConfirmButton
            // 
            this.ConfirmButton.Location = new System.Drawing.Point(176, 348);
            this.ConfirmButton.Name = "ConfirmButton";
            this.ConfirmButton.Size = new System.Drawing.Size(75, 23);
            this.ConfirmButton.TabIndex = 35;
            this.ConfirmButton.Text = "Confirm";
            this.ConfirmButton.UseVisualStyleBackColor = true;
            this.ConfirmButton.Click += new System.EventHandler(this.ConfirmButton_Click);
            // 
            // errorMessageTextBox
            // 
            this.errorMessageTextBox.Enabled = false;
            this.errorMessageTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorMessageTextBox.Location = new System.Drawing.Point(12, 377);
            this.errorMessageTextBox.Multiline = true;
            this.errorMessageTextBox.Name = "errorMessageTextBox";
            this.errorMessageTextBox.ReadOnly = true;
            this.errorMessageTextBox.Size = new System.Drawing.Size(484, 61);
            this.errorMessageTextBox.TabIndex = 68;
            this.errorMessageTextBox.Visible = false;
            // 
            // cardNumberMaskedTextBox
            // 
            this.cardNumberMaskedTextBox.AllowPromptAsInput = false;
            this.cardNumberMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.cardNumberMaskedTextBox.Location = new System.Drawing.Point(258, 192);
            this.cardNumberMaskedTextBox.Mask = "0-0-0-0";
            this.cardNumberMaskedTextBox.Name = "cardNumberMaskedTextBox";
            this.cardNumberMaskedTextBox.Size = new System.Drawing.Size(238, 20);
            this.cardNumberMaskedTextBox.TabIndex = 69;
            this.cardNumberMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.cardNumberMaskedTextBox.ValidatingType = typeof(int);
            // 
            // accountNumberInputMaskedTextBox
            // 
            this.accountNumberInputMaskedTextBox.AllowPromptAsInput = false;
            this.accountNumberInputMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.accountNumberInputMaskedTextBox.Location = new System.Drawing.Point(258, 192);
            this.accountNumberInputMaskedTextBox.Mask = "0-0-0-0-0-0";
            this.accountNumberInputMaskedTextBox.Name = "accountNumberInputMaskedTextBox";
            this.accountNumberInputMaskedTextBox.Size = new System.Drawing.Size(238, 20);
            this.accountNumberInputMaskedTextBox.TabIndex = 70;
            this.accountNumberInputMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.accountNumberInputMaskedTextBox.ValidatingType = typeof(int);
            // 
            // AddEditExpenseDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(522, 448);
            this.Controls.Add(this.accountNumberInputMaskedTextBox);
            this.Controls.Add(this.cardNumberMaskedTextBox);
            this.Controls.Add(this.errorMessageTextBox);
            this.Controls.Add(this.dateTimePicker);
            this.Controls.Add(this.accountTypeInputComboBox);
            this.Controls.Add(this.cardTypeInputComboBox);
            this.Controls.Add(this.currencyInputComboBox);
            this.Controls.Add(this.providerInputTextBox);
            this.Controls.Add(this.cardNameInputTextBox);
            this.Controls.Add(this.bankNameInputTextBox);
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
            this.Controls.Add(this.tagInputTextBox);
            this.Controls.Add(this.placeInputTextBox);
            this.Controls.Add(this.amountInputTextBox);
            this.Controls.Add(this.notesLabelTextBox);
            this.Controls.Add(this.tagLabelTextBox);
            this.Controls.Add(this.purchaseMethodLabelTextBox);
            this.Controls.Add(this.placeLabelTextBox);
            this.Controls.Add(this.amountLabelTextBox);
            this.Controls.Add(this.dateLabelTextBox);
            this.Controls.Add(this.titleTextBox);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.ConfirmButton);
            this.Name = "AddEditExpenseDialog";
            this.Text = "Form2";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker dateTimePicker;
        private System.Windows.Forms.ComboBox accountTypeInputComboBox;
        private System.Windows.Forms.ComboBox cardTypeInputComboBox;
        private System.Windows.Forms.ComboBox currencyInputComboBox;
        private System.Windows.Forms.TextBox providerInputTextBox;
        private System.Windows.Forms.TextBox cardNameInputTextBox;
        private System.Windows.Forms.TextBox bankNameInputTextBox;
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
        private System.Windows.Forms.TextBox tagInputTextBox;
        private System.Windows.Forms.TextBox placeInputTextBox;
        private System.Windows.Forms.TextBox amountInputTextBox;
        private System.Windows.Forms.TextBox notesLabelTextBox;
        private System.Windows.Forms.TextBox tagLabelTextBox;
        private System.Windows.Forms.TextBox purchaseMethodLabelTextBox;
        private System.Windows.Forms.TextBox placeLabelTextBox;
        private System.Windows.Forms.TextBox amountLabelTextBox;
        private System.Windows.Forms.TextBox dateLabelTextBox;
        private System.Windows.Forms.TextBox titleTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button ConfirmButton;
        private System.Windows.Forms.TextBox errorMessageTextBox;
        private System.Windows.Forms.MaskedTextBox cardNumberMaskedTextBox;
        private System.Windows.Forms.MaskedTextBox accountNumberInputMaskedTextBox;
    }
}
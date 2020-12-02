namespace ExpenseTracker
{
    partial class GoogleAuthenticatorUserControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GoogleAuthenticatorUserControl));
            this.authenticatorLabelTextBox = new System.Windows.Forms.TextBox();
            this.authenticatorCodeInputMaskedTextBox = new System.Windows.Forms.MaskedTextBox();
            this.authenticatorLogoPictureBox = new System.Windows.Forms.PictureBox();
            this.confirmCodeButton = new System.Windows.Forms.Button();
            this.authenticatorInstructionTextBox = new System.Windows.Forms.TextBox();
            this.qrCodePictureBox = new System.Windows.Forms.PictureBox();
            this.errorMessageTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.authenticatorLogoPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // authenticatorLabelTextBox
            // 
            this.authenticatorLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatorLabelTextBox.Location = new System.Drawing.Point(208, 40);
            this.authenticatorLabelTextBox.Name = "authenticatorLabelTextBox";
            this.authenticatorLabelTextBox.ReadOnly = true;
            this.authenticatorLabelTextBox.Size = new System.Drawing.Size(201, 23);
            this.authenticatorLabelTextBox.TabIndex = 0;
            this.authenticatorLabelTextBox.Text = "Enter Authenticator Code";
            // 
            // authenticatorCodeInputMaskedTextBox
            // 
            this.authenticatorCodeInputMaskedTextBox.AllowPromptAsInput = false;
            this.authenticatorCodeInputMaskedTextBox.CutCopyMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.authenticatorCodeInputMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatorCodeInputMaskedTextBox.Location = new System.Drawing.Point(208, 139);
            this.authenticatorCodeInputMaskedTextBox.Mask = "0-0-0-0-0-0";
            this.authenticatorCodeInputMaskedTextBox.Name = "authenticatorCodeInputMaskedTextBox";
            this.authenticatorCodeInputMaskedTextBox.Size = new System.Drawing.Size(201, 53);
            this.authenticatorCodeInputMaskedTextBox.TabIndex = 1;
            this.authenticatorCodeInputMaskedTextBox.TextMaskFormat = System.Windows.Forms.MaskFormat.ExcludePromptAndLiterals;
            this.authenticatorCodeInputMaskedTextBox.ValidatingType = typeof(int);
            // 
            // authenticatorLogoPictureBox
            // 
            this.authenticatorLogoPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.authenticatorLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("authenticatorLogoPictureBox.Image")));
            this.authenticatorLogoPictureBox.Location = new System.Drawing.Point(277, 69);
            this.authenticatorLogoPictureBox.Name = "authenticatorLogoPictureBox";
            this.authenticatorLogoPictureBox.Size = new System.Drawing.Size(64, 64);
            this.authenticatorLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.authenticatorLogoPictureBox.TabIndex = 3;
            this.authenticatorLogoPictureBox.TabStop = false;
            // 
            // confirmCodeButton
            // 
            this.confirmCodeButton.Location = new System.Drawing.Point(208, 198);
            this.confirmCodeButton.Name = "confirmCodeButton";
            this.confirmCodeButton.Size = new System.Drawing.Size(201, 23);
            this.confirmCodeButton.TabIndex = 5;
            this.confirmCodeButton.Text = "Confirm";
            this.confirmCodeButton.UseVisualStyleBackColor = true;
            this.confirmCodeButton.Click += new System.EventHandler(this.confirmCodeButton_Click);
            // 
            // authenticatorInstructionTextBox
            // 
            this.authenticatorInstructionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatorInstructionTextBox.Location = new System.Drawing.Point(3, 209);
            this.authenticatorInstructionTextBox.Multiline = true;
            this.authenticatorInstructionTextBox.Name = "authenticatorInstructionTextBox";
            this.authenticatorInstructionTextBox.ReadOnly = true;
            this.authenticatorInstructionTextBox.Size = new System.Drawing.Size(200, 169);
            this.authenticatorInstructionTextBox.TabIndex = 19;
            this.authenticatorInstructionTextBox.Text = resources.GetString("authenticatorInstructionTextBox.Text");
            this.authenticatorInstructionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // qrCodePictureBox
            // 
            this.qrCodePictureBox.Location = new System.Drawing.Point(3, 3);
            this.qrCodePictureBox.Name = "qrCodePictureBox";
            this.qrCodePictureBox.Size = new System.Drawing.Size(200, 200);
            this.qrCodePictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.qrCodePictureBox.TabIndex = 18;
            this.qrCodePictureBox.TabStop = false;
            // 
            // errorMessageTextBox
            // 
            this.errorMessageTextBox.Enabled = false;
            this.errorMessageTextBox.ForeColor = System.Drawing.Color.Red;
            this.errorMessageTextBox.Location = new System.Drawing.Point(209, 228);
            this.errorMessageTextBox.Multiline = true;
            this.errorMessageTextBox.Name = "errorMessageTextBox";
            this.errorMessageTextBox.ReadOnly = true;
            this.errorMessageTextBox.Size = new System.Drawing.Size(200, 104);
            this.errorMessageTextBox.TabIndex = 20;
            // 
            // GoogleAuthenticatorUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorMessageTextBox);
            this.Controls.Add(this.authenticatorInstructionTextBox);
            this.Controls.Add(this.qrCodePictureBox);
            this.Controls.Add(this.confirmCodeButton);
            this.Controls.Add(this.authenticatorLogoPictureBox);
            this.Controls.Add(this.authenticatorCodeInputMaskedTextBox);
            this.Controls.Add(this.authenticatorLabelTextBox);
            this.Name = "GoogleAuthenticatorUserControl";
            this.Size = new System.Drawing.Size(416, 384);
            ((System.ComponentModel.ISupportInitialize)(this.authenticatorLogoPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox authenticatorLabelTextBox;
        private System.Windows.Forms.MaskedTextBox authenticatorCodeInputMaskedTextBox;
        private System.Windows.Forms.PictureBox authenticatorLogoPictureBox;
        private System.Windows.Forms.Button confirmCodeButton;
        private System.Windows.Forms.TextBox authenticatorInstructionTextBox;
        private System.Windows.Forms.PictureBox qrCodePictureBox;
        private System.Windows.Forms.TextBox errorMessageTextBox;
    }
}

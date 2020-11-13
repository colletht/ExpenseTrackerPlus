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
            ((System.ComponentModel.ISupportInitialize)(this.authenticatorLogoPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // authenticatorLabelTextBox
            // 
            this.authenticatorLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatorLabelTextBox.Location = new System.Drawing.Point(3, 3);
            this.authenticatorLabelTextBox.Name = "authenticatorLabelTextBox";
            this.authenticatorLabelTextBox.ReadOnly = true;
            this.authenticatorLabelTextBox.Size = new System.Drawing.Size(201, 23);
            this.authenticatorLabelTextBox.TabIndex = 0;
            this.authenticatorLabelTextBox.Text = "Enter Authenticator Code";
            // 
            // authenticatorCodeInputMaskedTextBox
            // 
            this.authenticatorCodeInputMaskedTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatorCodeInputMaskedTextBox.Location = new System.Drawing.Point(3, 102);
            this.authenticatorCodeInputMaskedTextBox.Mask = "0-0-0-0-0-0";
            this.authenticatorCodeInputMaskedTextBox.Name = "authenticatorCodeInputMaskedTextBox";
            this.authenticatorCodeInputMaskedTextBox.Size = new System.Drawing.Size(201, 53);
            this.authenticatorCodeInputMaskedTextBox.TabIndex = 1;
            this.authenticatorCodeInputMaskedTextBox.ValidatingType = typeof(int);
            // 
            // authenticatorLogoPictureBox
            // 
            this.authenticatorLogoPictureBox.BackColor = System.Drawing.SystemColors.Control;
            this.authenticatorLogoPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("authenticatorLogoPictureBox.Image")));
            this.authenticatorLogoPictureBox.Location = new System.Drawing.Point(72, 32);
            this.authenticatorLogoPictureBox.Name = "authenticatorLogoPictureBox";
            this.authenticatorLogoPictureBox.Size = new System.Drawing.Size(64, 64);
            this.authenticatorLogoPictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.authenticatorLogoPictureBox.TabIndex = 3;
            this.authenticatorLogoPictureBox.TabStop = false;
            // 
            // confirmCodeButton
            // 
            this.confirmCodeButton.Location = new System.Drawing.Point(3, 161);
            this.confirmCodeButton.Name = "confirmCodeButton";
            this.confirmCodeButton.Size = new System.Drawing.Size(201, 23);
            this.confirmCodeButton.TabIndex = 5;
            this.confirmCodeButton.Text = "Confirm";
            this.confirmCodeButton.UseVisualStyleBackColor = true;
            // 
            // UserControl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.confirmCodeButton);
            this.Controls.Add(this.authenticatorLogoPictureBox);
            this.Controls.Add(this.authenticatorCodeInputMaskedTextBox);
            this.Controls.Add(this.authenticatorLabelTextBox);
            this.Name = "UserControl1";
            this.Size = new System.Drawing.Size(209, 190);
            ((System.ComponentModel.ISupportInitialize)(this.authenticatorLogoPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox authenticatorLabelTextBox;
        private System.Windows.Forms.MaskedTextBox authenticatorCodeInputMaskedTextBox;
        private System.Windows.Forms.PictureBox authenticatorLogoPictureBox;
        private System.Windows.Forms.Button confirmCodeButton;
    }
}

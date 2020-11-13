namespace ExpenseTracker
{
    partial class UserLoginForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserLoginForm));
            this.qrCodePictureBox = new System.Windows.Forms.PictureBox();
            this.titleBarTextBox = new System.Windows.Forms.TextBox();
            this.newProfileTitleTextBox = new System.Windows.Forms.TextBox();
            this.loginTitleTextBox = new System.Windows.Forms.TextBox();
            this.emailLabelTextBox = new System.Windows.Forms.TextBox();
            this.passwordLabelTextBox = new System.Windows.Forms.TextBox();
            this.emailInputTextBox = new System.Windows.Forms.TextBox();
            this.passwordInputTextBox = new System.Windows.Forms.TextBox();
            this.newEmailLabelTextBox = new System.Windows.Forms.TextBox();
            this.newEmailInputTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordLabelTextBox = new System.Windows.Forms.TextBox();
            this.newPasswordInputTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordLabelTextBox = new System.Windows.Forms.TextBox();
            this.confirmPasswordInputTextBox = new System.Windows.Forms.TextBox();
            this.instructionReferalTextBox = new System.Windows.Forms.TextBox();
            this.confirmNewAccountTextBox = new System.Windows.Forms.Button();
            this.loginButton = new System.Windows.Forms.Button();
            this.authenticatorInstructionTextBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // qrCodePictureBox
            // 
            this.qrCodePictureBox.Location = new System.Drawing.Point(12, 12);
            this.qrCodePictureBox.Name = "qrCodePictureBox";
            this.qrCodePictureBox.Size = new System.Drawing.Size(200, 200);
            this.qrCodePictureBox.TabIndex = 0;
            this.qrCodePictureBox.TabStop = false;
            // 
            // titleBarTextBox
            // 
            this.titleBarTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleBarTextBox.Location = new System.Drawing.Point(219, 13);
            this.titleBarTextBox.Name = "titleBarTextBox";
            this.titleBarTextBox.ReadOnly = true;
            this.titleBarTextBox.Size = new System.Drawing.Size(569, 38);
            this.titleBarTextBox.TabIndex = 1;
            this.titleBarTextBox.Text = "Welcome to Your Expense Tracker!";
            this.titleBarTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // newProfileTitleTextBox
            // 
            this.newProfileTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newProfileTitleTextBox.Location = new System.Drawing.Point(219, 58);
            this.newProfileTitleTextBox.Name = "newProfileTitleTextBox";
            this.newProfileTitleTextBox.ReadOnly = true;
            this.newProfileTitleTextBox.Size = new System.Drawing.Size(287, 30);
            this.newProfileTitleTextBox.TabIndex = 2;
            this.newProfileTitleTextBox.Text = "New Profile Creation";
            this.newProfileTitleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loginTitleTextBox
            // 
            this.loginTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loginTitleTextBox.Location = new System.Drawing.Point(512, 58);
            this.loginTitleTextBox.Name = "loginTitleTextBox";
            this.loginTitleTextBox.ReadOnly = true;
            this.loginTitleTextBox.Size = new System.Drawing.Size(276, 30);
            this.loginTitleTextBox.TabIndex = 3;
            this.loginTitleTextBox.Text = "Login";
            this.loginTitleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // emailLabelTextBox
            // 
            this.emailLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailLabelTextBox.Location = new System.Drawing.Point(512, 95);
            this.emailLabelTextBox.Name = "emailLabelTextBox";
            this.emailLabelTextBox.ReadOnly = true;
            this.emailLabelTextBox.Size = new System.Drawing.Size(276, 23);
            this.emailLabelTextBox.TabIndex = 4;
            this.emailLabelTextBox.Text = "Email:";
            // 
            // passwordLabelTextBox
            // 
            this.passwordLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordLabelTextBox.Location = new System.Drawing.Point(512, 152);
            this.passwordLabelTextBox.Name = "passwordLabelTextBox";
            this.passwordLabelTextBox.ReadOnly = true;
            this.passwordLabelTextBox.Size = new System.Drawing.Size(276, 23);
            this.passwordLabelTextBox.TabIndex = 5;
            this.passwordLabelTextBox.Text = "Password:";
            // 
            // emailInputTextBox
            // 
            this.emailInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emailInputTextBox.Location = new System.Drawing.Point(512, 123);
            this.emailInputTextBox.Name = "emailInputTextBox";
            this.emailInputTextBox.Size = new System.Drawing.Size(276, 23);
            this.emailInputTextBox.TabIndex = 6;
            this.emailInputTextBox.Text = "john.doe@gmail.com";
            // 
            // passwordInputTextBox
            // 
            this.passwordInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.passwordInputTextBox.Location = new System.Drawing.Point(512, 181);
            this.passwordInputTextBox.Name = "passwordInputTextBox";
            this.passwordInputTextBox.PasswordChar = '.';
            this.passwordInputTextBox.Size = new System.Drawing.Size(276, 23);
            this.passwordInputTextBox.TabIndex = 7;
            this.passwordInputTextBox.Text = "supersecretpassword...";
            // 
            // newEmailLabelTextBox
            // 
            this.newEmailLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEmailLabelTextBox.Location = new System.Drawing.Point(219, 95);
            this.newEmailLabelTextBox.Name = "newEmailLabelTextBox";
            this.newEmailLabelTextBox.ReadOnly = true;
            this.newEmailLabelTextBox.Size = new System.Drawing.Size(287, 23);
            this.newEmailLabelTextBox.TabIndex = 8;
            this.newEmailLabelTextBox.Text = "Email:";
            // 
            // newEmailInputTextBox
            // 
            this.newEmailInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newEmailInputTextBox.Location = new System.Drawing.Point(219, 124);
            this.newEmailInputTextBox.Name = "newEmailInputTextBox";
            this.newEmailInputTextBox.Size = new System.Drawing.Size(287, 23);
            this.newEmailInputTextBox.TabIndex = 9;
            this.newEmailInputTextBox.Text = "john.doe@gmail.com";
            // 
            // newPasswordLabelTextBox
            // 
            this.newPasswordLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordLabelTextBox.Location = new System.Drawing.Point(219, 153);
            this.newPasswordLabelTextBox.Name = "newPasswordLabelTextBox";
            this.newPasswordLabelTextBox.ReadOnly = true;
            this.newPasswordLabelTextBox.Size = new System.Drawing.Size(287, 23);
            this.newPasswordLabelTextBox.TabIndex = 10;
            this.newPasswordLabelTextBox.Text = "Password:";
            // 
            // newPasswordInputTextBox
            // 
            this.newPasswordInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.newPasswordInputTextBox.Location = new System.Drawing.Point(219, 181);
            this.newPasswordInputTextBox.Name = "newPasswordInputTextBox";
            this.newPasswordInputTextBox.PasswordChar = '.';
            this.newPasswordInputTextBox.Size = new System.Drawing.Size(287, 23);
            this.newPasswordInputTextBox.TabIndex = 11;
            this.newPasswordInputTextBox.Text = "supersecretpassword...";
            // 
            // confirmPasswordLabelTextBox
            // 
            this.confirmPasswordLabelTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordLabelTextBox.Location = new System.Drawing.Point(219, 210);
            this.confirmPasswordLabelTextBox.Name = "confirmPasswordLabelTextBox";
            this.confirmPasswordLabelTextBox.ReadOnly = true;
            this.confirmPasswordLabelTextBox.Size = new System.Drawing.Size(287, 23);
            this.confirmPasswordLabelTextBox.TabIndex = 12;
            this.confirmPasswordLabelTextBox.Text = "Confirm Password:";
            // 
            // confirmPasswordInputTextBox
            // 
            this.confirmPasswordInputTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.confirmPasswordInputTextBox.Location = new System.Drawing.Point(219, 239);
            this.confirmPasswordInputTextBox.Name = "confirmPasswordInputTextBox";
            this.confirmPasswordInputTextBox.PasswordChar = '.';
            this.confirmPasswordInputTextBox.Size = new System.Drawing.Size(287, 23);
            this.confirmPasswordInputTextBox.TabIndex = 13;
            // 
            // instructionReferalTextBox
            // 
            this.instructionReferalTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.instructionReferalTextBox.Location = new System.Drawing.Point(219, 268);
            this.instructionReferalTextBox.Multiline = true;
            this.instructionReferalTextBox.Name = "instructionReferalTextBox";
            this.instructionReferalTextBox.ReadOnly = true;
            this.instructionReferalTextBox.Size = new System.Drawing.Size(287, 90);
            this.instructionReferalTextBox.TabIndex = 14;
            this.instructionReferalTextBox.Text = "Follow the instructions to the left in order to download google authenticator to " +
    "your mobile device. Then open the app and scan the QR code. Then hit confirm bel" +
    "ow to finish setting up!";
            this.instructionReferalTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // confirmNewAccountTextBox
            // 
            this.confirmNewAccountTextBox.Location = new System.Drawing.Point(219, 364);
            this.confirmNewAccountTextBox.Name = "confirmNewAccountTextBox";
            this.confirmNewAccountTextBox.Size = new System.Drawing.Size(287, 23);
            this.confirmNewAccountTextBox.TabIndex = 15;
            this.confirmNewAccountTextBox.Text = "Confirm";
            this.confirmNewAccountTextBox.UseVisualStyleBackColor = true;
            // 
            // loginButton
            // 
            this.loginButton.Location = new System.Drawing.Point(512, 210);
            this.loginButton.Name = "loginButton";
            this.loginButton.Size = new System.Drawing.Size(276, 23);
            this.loginButton.TabIndex = 16;
            this.loginButton.Text = "Login";
            this.loginButton.UseVisualStyleBackColor = true;
            // 
            // authenticatorInstructionTextBox
            // 
            this.authenticatorInstructionTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.authenticatorInstructionTextBox.Location = new System.Drawing.Point(12, 218);
            this.authenticatorInstructionTextBox.Multiline = true;
            this.authenticatorInstructionTextBox.Name = "authenticatorInstructionTextBox";
            this.authenticatorInstructionTextBox.ReadOnly = true;
            this.authenticatorInstructionTextBox.Size = new System.Drawing.Size(200, 169);
            this.authenticatorInstructionTextBox.TabIndex = 17;
            this.authenticatorInstructionTextBox.Text = resources.GetString("authenticatorInstructionTextBox.Text");
            this.authenticatorInstructionTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // UserLoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.authenticatorInstructionTextBox);
            this.Controls.Add(this.loginButton);
            this.Controls.Add(this.confirmNewAccountTextBox);
            this.Controls.Add(this.instructionReferalTextBox);
            this.Controls.Add(this.confirmPasswordInputTextBox);
            this.Controls.Add(this.confirmPasswordLabelTextBox);
            this.Controls.Add(this.newPasswordInputTextBox);
            this.Controls.Add(this.newPasswordLabelTextBox);
            this.Controls.Add(this.newEmailInputTextBox);
            this.Controls.Add(this.newEmailLabelTextBox);
            this.Controls.Add(this.passwordInputTextBox);
            this.Controls.Add(this.emailInputTextBox);
            this.Controls.Add(this.passwordLabelTextBox);
            this.Controls.Add(this.emailLabelTextBox);
            this.Controls.Add(this.loginTitleTextBox);
            this.Controls.Add(this.newProfileTitleTextBox);
            this.Controls.Add(this.titleBarTextBox);
            this.Controls.Add(this.qrCodePictureBox);
            this.Name = "UserLoginForm";
            this.Text = "UserLoginForm";
            ((System.ComponentModel.ISupportInitialize)(this.qrCodePictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox qrCodePictureBox;
        private System.Windows.Forms.TextBox titleBarTextBox;
        private System.Windows.Forms.TextBox newProfileTitleTextBox;
        private System.Windows.Forms.TextBox loginTitleTextBox;
        private System.Windows.Forms.TextBox emailLabelTextBox;
        private System.Windows.Forms.TextBox passwordLabelTextBox;
        private System.Windows.Forms.TextBox emailInputTextBox;
        private System.Windows.Forms.TextBox passwordInputTextBox;
        private System.Windows.Forms.TextBox newEmailLabelTextBox;
        private System.Windows.Forms.TextBox newEmailInputTextBox;
        private System.Windows.Forms.TextBox newPasswordLabelTextBox;
        private System.Windows.Forms.TextBox newPasswordInputTextBox;
        private System.Windows.Forms.TextBox confirmPasswordLabelTextBox;
        private System.Windows.Forms.TextBox confirmPasswordInputTextBox;
        private System.Windows.Forms.TextBox instructionReferalTextBox;
        private System.Windows.Forms.Button confirmNewAccountTextBox;
        private System.Windows.Forms.Button loginButton;
        private System.Windows.Forms.TextBox authenticatorInstructionTextBox;
    }
}
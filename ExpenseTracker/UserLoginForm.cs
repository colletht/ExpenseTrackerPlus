// <copyright file="UserLoginForm.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTracker
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Net.Mail;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using ExpenseTrackerEngine;

    /// <summary>
    /// Form for logging in/initializing new user.
    /// </summary>
    public partial class UserLoginForm : Form
    {
        private Authenticator authenticator;

        /// <summary>
        /// Initializes a new instance of the <see cref="UserLoginForm"/> class.
        /// </summary>
        public UserLoginForm()
        {
            this.InitializeComponent();
            this.authenticator = new Authenticator();
            this.googleAuthenticatorUserControl.ConfirmButtonClick += this.confirmAuthenticatorCode_Click;
        }

        /// <summary>
        /// Checks if a string is a valid username. Only alphanumeric characters are allowed.
        /// </summary>
        /// <param name="username">string to check.</param>
        /// <returns>True if the string is a valid email address.</returns>
        private bool UsernameIsValid(string username)
        {
            if (username.Equals(string.Empty))
            {
                return false;
            }

            Regex rg = new Regex(@"^[a-zA-Z0-9\s,]*$");
            return rg.IsMatch(username);
        }

        /// <summary>
        /// Makes the google authenticator input usercontrol visible and hides everything else.
        /// </summary>
        private void ShowGoogleAuthenticator()
        {
            this.authenticator.SetUpGoogleAuthenticator();

            // Set everything to disabled and invisible except the google auth form.
            foreach (Control control in this.Controls)
            {
                control.Visible = false;
                control.Enabled = false;
            }

            // Set google auth control to enabled and visible.
            this.googleAuthenticatorUserControl.Enabled = true;
            this.googleAuthenticatorUserControl.Visible = true;
            this.googleAuthenticatorUserControl.SetQrCodeImage(this.authenticator.QRCodeImageURL);
        }

        /// <summary>
        /// Hides the google authenticator screen.
        /// </summary>
        private void HideGoogleAuthenticator()
        {
            // Set everything to disabled and invisible except the google auth form.
            foreach (Control control in this.Controls)
            {
                control.Visible = true;
                control.Enabled = true;
            }

            // Set google auth control to enabled and visible.
            this.googleAuthenticatorUserControl.Enabled = false;
            this.googleAuthenticatorUserControl.Visible = false;
        }

        /// <summary>
        /// Shows the given error message for a new account error.
        /// </summary>
        /// <param name="msg">The message to show.</param>
        private void ShowNewAccountErrorMessage(string msg)
        {
            this.newAccountErrorMessageTextBox.Text = msg;
            this.newAccountErrorMessageTextBox.Enabled = true;
            this.newAccountErrorMessageTextBox.Visible = true;
        }

        /// <summary>
        /// Hides the error message box for a new account error.
        /// </summary>
        private void HideNewAccountErrorMessage()
        {
            this.newAccountErrorMessageTextBox.Text = string.Empty;
            this.newAccountErrorMessageTextBox.Enabled = false;
            this.newAccountErrorMessageTextBox.Visible = false;
        }

        /// <summary>
        /// Shows the given error message for a login error.
        /// </summary>
        /// <param name="msg">The message to show.</param>
        private void ShowLoginErrorMessage(string msg)
        {
            this.loginErrorMessageTextBox.Text = msg;
            this.loginErrorMessageTextBox.Enabled = true;
            this.loginErrorMessageTextBox.Visible = true;
        }

        /// <summary>
        /// Hides the error message box for a login error.
        /// </summary>
        private void HideLoginErrorMessage()
        {
            this.loginErrorMessageTextBox.Text = string.Empty;
            this.loginErrorMessageTextBox.Enabled = false;
            this.loginErrorMessageTextBox.Visible = false;
        }

        private void UserLoginForm_Load(object sender, EventArgs e)
        {
            this.usernameInputTextBox.Focus();
        }

        /// <summary>
        /// Fired when the confrim button in the google authenticator user form is clicked.
        /// </summary>
        /// <param name="sender">Object that registered the event (button).</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void confirmAuthenticatorCode_Click(object sender, EventArgs e)
        {
            Console.WriteLine(this.googleAuthenticatorUserControl.AuthenticatorCode);
            if (!this.authenticator.AuthenticateGoogleAuthenticator(this.googleAuthenticatorUserControl.AuthenticatorCode))
            {
                // do error state: incorrect code entered.
                this.googleAuthenticatorUserControl.ShowErrorMessage("That code wasnt correct. Try double checking your google authenticator app.");
                return;
            }

            // login was succesful - pass the user to ExpenseController and open ExpenseForm.
            ExpenseController expenseController = this.authenticator.CreateExpenseController();
            ExpenseForm expenseForm = new ExpenseForm(expenseController);
            expenseForm.Location = this.Location;
            expenseForm.StartPosition = FormStartPosition.Manual;
            expenseForm.FormClosing += (sender1, e1) => { this.Show(); };
            expenseForm.Show();
            this.Hide();

            this.HideGoogleAuthenticator();

            // Clear authenticator for new use.
            this.authenticator = new Authenticator();

            this.HideLoginErrorMessage();
            this.HideNewAccountErrorMessage();
        }

        /// <summary>
        /// Event registers when login button is clicked. Responsible for validating email and password input and attempting to login user.
        /// </summary>
        /// <param name="sender">Object that registered the event (button).</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void loginButton_Click(object sender, EventArgs e)
        {
            if (!this.UsernameIsValid(this.usernameInputTextBox.Text))
            {
                // do error state: email is invalid show error message.
                this.ShowLoginErrorMessage("Please enter a valid username using only alphanumeric characters.");
                return;
            }

            if (this.passwordInputTextBox.Text.Length == 0)
            {
                // do error state: password is empty show error message.
                this.ShowLoginErrorMessage("You forgot to enter your password!");
                return;
            }

            if (!this.authenticator.AuthenticatePassword(
                this.usernameInputTextBox.Text,
                this.passwordInputTextBox.Text))
            {
                // do error state: username + password not recognized.
                this.ShowLoginErrorMessage("Login failed: Either your username or password is incorrect.");
                return;
            }

            this.HideLoginErrorMessage();

            // success: take to google auth form.
            this.ShowGoogleAuthenticator();
        }

        /// <summary>
        /// Event registered when the new password textbox text is changed. Checks that the two passwords match.
        /// Disables the confrim button if they dont.
        /// </summary>
        /// <param name="sender">Object that registered the event (button).</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void newPasswordInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.newPasswordInputTextBox.Text.Equals(this.confirmPasswordInputTextBox.Text))
            {
                // do error state: passwords dont match so show a message.
                this.ShowNewAccountErrorMessage("The two password fields must match before you can proceed.");
                this.confirmPasswordInputTextBox.BackColor = Color.Red;
                this.confirmNewAccountButton.Enabled = false;
                return;
            }

            this.HideNewAccountErrorMessage();
            this.confirmPasswordInputTextBox.BackColor = Color.White;
            this.confirmNewAccountButton.Enabled = true;
        }

        /// <summary>
        /// Event registered when the confirm password textbox text is changed. Checks that the two passwords match.
        /// Disables the confrim button if they dont.
        /// </summary>
        /// <param name="sender">Object that registered the event (button).</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void confirmPasswordInputTextBox_TextChanged(object sender, EventArgs e)
        {
            if (!this.newPasswordInputTextBox.Text.Equals(this.confirmPasswordInputTextBox.Text))
            {
                // do error state: passwords dont match so show a message.
                this.ShowNewAccountErrorMessage("The two password fields must match before you can proceed.");
                this.confirmPasswordInputTextBox.BackColor = Color.Red;
                this.confirmNewAccountButton.Enabled = false;
                return;
            }

            this.HideNewAccountErrorMessage();
            this.confirmPasswordInputTextBox.BackColor = Color.White;
            this.confirmNewAccountButton.Enabled = true;
        }

        /// <summary>
        /// Event registered when the confirm new profile button is clicked. checks that all fields are valid before attempting to create an account.
        /// </summary>
        /// <param name="sender">Object that registered the event (button).</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void confirmNewAccountTextBox_Click(object sender, EventArgs e)
        {
            if (!this.UsernameIsValid(this.newUsernameInputTextBox.Text))
            {
                // do error state: email is invalid
                this.ShowNewAccountErrorMessage("Please enter a valid username containing only alphanumeric characters.");
                return;
            }

            if (this.newPasswordInputTextBox.Text.Length == 0)
            {
                // do error state: new password is empty
                this.ShowNewAccountErrorMessage("You forgot to enter your password!");
                return;
            }

            if (this.confirmPasswordInputTextBox.Text.Length == 0)
            {
                // do error state: confirm password is empty
                this.ShowNewAccountErrorMessage("You forgot to enter your password confirmation!");
                return;
            }

            if (!this.newPasswordInputTextBox.Text.Equals(this.confirmPasswordInputTextBox.Text))
            {
                // do error state: passwords must match
                this.ShowNewAccountErrorMessage("The two password fields must match before you can proceed.");
                return;
            }

            try
            {
                this.authenticator.SetUpNewUser(
                    this.newUsernameInputTextBox.Text,
                    this.newPasswordInputTextBox.Text);

                this.HideNewAccountErrorMessage();

                // new user setup succesful. proceed to google auth screen.
                this.ShowGoogleAuthenticator();
            }
            catch
            {
                // do error state: username already exists in database
                this.ShowNewAccountErrorMessage("Profile creation failed: That username already exists in our database. Try a different one!");
                return;
            }
        }
    }
}

// <copyright file="GoogleAuthenticatorUserControl.cs" company="Harrison Collet">
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
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;

    /// <summary>
    /// UserControl for entering the google authenticator code.
    /// </summary>
    public partial class GoogleAuthenticatorUserControl : UserControl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GoogleAuthenticatorUserControl"/> class.
        /// </summary>
        public GoogleAuthenticatorUserControl()
        {
            this.InitializeComponent();
            this.HideQrCode();
        }

        /// <summary>
        /// Invoked when the confirm button is clicked.
        /// Passes the value in textbox with the event.
        /// </summary>
        [Browsable(true)]
        [Category("Action")]
        [Description("Invoked when the confirm button is clicked.")]
        public event EventHandler ConfirmButtonClick;

        /// <summary>
        /// Gets the text inside the codeinput box.
        /// </summary>
        public string AuthenticatorCode => this.authenticatorCodeInputMaskedTextBox.Text;

        /// <summary>
        /// Sets the qr code image to be displayed.
        /// </summary>
        /// <param name="img">The image to set the qr code to.</param>
        public void SetQrCodeImage(byte[] img)
        {
            using (var stream = new MemoryStream(img))
            {
                this.qrCodePictureBox.Image = Bitmap.FromStream(stream);
            }
        }

        /// <summary>
        /// Shows the error message box with the given message.
        /// </summary>
        /// <param name="msg">message to display.</param>
        public void ShowErrorMessage(string msg)
        {
            this.errorMessageTextBox.Text = msg;
            this.errorMessageTextBox.Enabled = true;
            this.errorMessageTextBox.Visible = true;
        }

        /// <summary>
        /// Hides the error message box.
        /// </summary>
        public void HideErrorMessage()
        {
            this.errorMessageTextBox.Text = string.Empty;
            this.errorMessageTextBox.Enabled = false;
            this.errorMessageTextBox.Visible = false;
        }

        public void ShowQrCode()
        {
            this.qrCodePictureBox.Enabled = true;
            this.qrCodePictureBox.Visible = true;
            this.authenticatorInstructionTextBox.Enabled = true;
            this.authenticatorInstructionTextBox.Visible = true;
        }

        public void HideQrCode()
        {
            this.qrCodePictureBox.Enabled = false;
            this.qrCodePictureBox.Visible = false;
            this.authenticatorInstructionTextBox.Enabled = false;
            this.authenticatorInstructionTextBox.Visible = false;
        }

        /// <summary>
        /// Resets the form to its initial state.
        /// </summary>
        public void ResetForm()
        {
            this.authenticatorCodeInputMaskedTextBox.Text = string.Empty;
            this.HideQrCode();
        }

        /// <summary>
        /// Fires when the confirmCodeButton is clicked.
        /// </summary>
        /// <param name="sender">Object that registered the event (button).</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void confirmCodeButton_Click(object sender, EventArgs e)
        {
            if (!this.authenticatorCodeInputMaskedTextBox.MaskFull)
            {
                // do error state: code must be completely filled in.
                this.authenticatorCodeInputMaskedTextBox.BackColor = Color.Red;
                this.ShowErrorMessage("You must type in all six digits of your authentication code!");
                return;
            }

            this.HideErrorMessage();

            // if the text is all filled in we can pass the string to the ConfirmButtonClick event
            this.ConfirmButtonClick?.Invoke(this, e);
        }
    }
}

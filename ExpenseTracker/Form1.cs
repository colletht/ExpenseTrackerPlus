// <copyright file="Form1.cs" company="Harrison Collet">
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
    using System.Net;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Google.Authenticator;

    /// <summary>
    /// Main form driving our system.
    /// </summary>
    public partial class Form1 : Form
    {
        private TwoFactorAuthenticator tfa;

        /// <summary>
        /// Initializes a new instance of the <see cref="Form1"/> class.
        /// </summary>
        public Form1()
        {
            this.InitializeComponent();

            this.SetUpGoogleAuthenticator();
        }

        /// <summary>
        /// Provide information for setting up google authenticator, if the user is new.
        /// </summary>
        /// <returns>String representing the manual setup key users must enter into google authenticator.</returns>
        public string SetUpGoogleAuthenticator()
        {
            this.tfa = new TwoFactorAuthenticator();
            SetupCode setupInfo = this.tfa.GenerateSetupCode("ExpenseTrackerPlus", "colletht@gmail.com", "mysupersecretsecretkey", false, 2);

            this.textBox1.Text = "colletht@gmail.com";
            this.textBox2.Text = "mysupersecretsecretkey";
            this.textBox4.Text = setupInfo.ManualEntryKey;

            Console.WriteLine(setupInfo.QrCodeSetupImageUrl);
            Console.WriteLine(setupInfo.QrCodeSetupImageUrl.Substring(22));

            Uri qr = new Uri(setupInfo.QrCodeSetupImageUrl);

            //this.pictureBox1.Load("http://" + setupInfo.QrCodeSetupImageUrl);

            //var request = WebRequest.Create("http://" + setupInfo.QrCodeSetupImageUrl);

            using (var stream = new MemoryStream(Convert.FromBase64String(setupInfo.QrCodeSetupImageUrl.Substring(22))))
            {
                this.pictureBox1.Image = Bitmap.FromStream(stream);
            }
            
            //this.pictureBox1.Load(setupInfo.QrCodeSetupImageUrl);
            return setupInfo.ManualEntryKey;
        }

        private void textBox3_DoubleClick(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(textBox3.Text))
            {
                this.tfa.GetCurrentPINs(this.textBox2.Text).ToList().ForEach(i => Console.WriteLine(i.ToString()));
                if (this.tfa.ValidateTwoFactorPIN(this.textBox2.Text, textBox3.Text))
                {
                    textBox3.BackColor = Color.Green;
                }
                else
                {
                    textBox3.BackColor = Color.Red;
                }
                // Move the selection pointer to the end of the text of the control.
                textBox3.Select(textBox3.Text.Length, 0);
                Console.WriteLine("--------------------------------------");
            }
        }
    }
}

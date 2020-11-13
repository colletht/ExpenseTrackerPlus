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
        }
    }
}

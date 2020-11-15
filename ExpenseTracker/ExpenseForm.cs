// <copyright file="ExpenseForm.cs" company="Harrison Collet">
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
    using ExpenseTrackerEngine;

    /// <summary>
    /// Landing page of application.
    /// </summary>
    public partial class ExpenseForm : Form
    {
        private ExpenseController controller;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseForm"/> class.
        /// </summary>
        /// <param name="expenseController">The expense controller to use for data retrieval.</param>
        public ExpenseForm(ExpenseController expenseController)
        {
            this.InitializeComponent();
            this.controller = expenseController;
        }
    }
}

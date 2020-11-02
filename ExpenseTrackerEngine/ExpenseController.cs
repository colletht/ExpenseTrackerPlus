// <copyright file="ExpenseController.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Class responsible for main exense tracking functionality. Serves as layer between frontend and backend.
    /// </summary>
    public class ExpenseController
    {
        private List<Expense> currentExpenses;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseController"/> class.
        /// Internal so that it may only be instantiated by backend code. Must be created
        /// by the Authenticator.
        /// </summary>
        /// <param name="user">The user whose expenses the object will be interacting with.</param>
        internal ExpenseController(User user)
        {
            // Setup members
            this.CurrentUser = user;
            this.ExpenseDataAccess = new DataAccessFactory(this.CurrentUser);

            // Initially load all expenses into controller
            this.currentExpenses = this.ExpenseDataAccess.GetAll();
            foreach (Expense e in this.currentExpenses)
            {
                e.PropertyChanged += this.OnExpensePropertyChanged;
            }
        }

        /// <summary>
        /// Gets the number of expenses currently loaded in.
        /// </summary>
        public int CurrentExpensesCount => this.currentExpenses.Count();

        /// <summary>
        /// Gets user whose data is being controlled by the ExpenseController.
        /// </summary>
        internal User CurrentUser
        {
            get;
            private set;
        }

        private DataAccessFactory ExpenseDataAccess
        {
            get;
            set;
        }

        /// <summary>
        /// Gets the expense at the specified index.
        /// </summary>
        /// <param name="index">Index of the expense to retrieve.</param>
        /// <returns>The Expense at that index.</returns>
        public Expense GetExpense(int index)
        {
            if (index < 0 || index >= this.CurrentExpensesCount)
            {
                throw new ArgumentOutOfRangeException();
            }

            return this.currentExpenses[index];
        }

        /// <summary>
        /// Inserts the expense with the given values into the database.
        /// </summary>
        /// <param name="e">The expense to insert.</param>
        public void InsertExpense(Expense e)
        {
            this.ExpenseDataAccess.InsertRecord(e);

            this.RefreshExpenses();
        }

        /// <summary>
        /// Deletes the Expense indicated by index.
        /// </summary>
        /// <param name="index">index of the expense in the list.</param>
        public void DeleteExpense(int index)
        {
            if (index < 0 || index >= this.CurrentExpensesCount)
            {
                throw new ArgumentOutOfRangeException();
            }

            this.ExpenseDataAccess.DeleteRecord(this.currentExpenses[index].Id);

            this.RefreshExpenses();
        }

        /// <summary>
        /// Hard synchronises the objects data with the databases data. Should be done after any Deletion of Addition of new expenses.
        /// </summary>
        private void RefreshExpenses()
        {
            this.currentExpenses = this.ExpenseDataAccess.GetAll();
        }

        /// <summary>
        /// Fires any time an Expense has been modified, and consequently writes its value back to the database.
        /// </summary>
        /// <param name="sender">Expense that triggered the event.</param>
        /// <param name="e">The properties that were changed.</param>
        private void OnExpensePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            this.ExpenseDataAccess.UpdateRecord(sender as Expense);
        }
    }
}

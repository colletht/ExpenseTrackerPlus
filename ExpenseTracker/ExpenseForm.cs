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
    using System.Windows;
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
            this.controller.ControllerDataRefreshed += this.OnControllerRefresh;

            this.AverageSelectionComboBox.SelectedIndex = 0;
            this.DisplayFilterNameTextBox.Text = "N/A";

            this.UpdateDataGrid();
        }

        /// <summary>
        /// Event handler function for when the controller data is refreshed.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void OnControllerRefresh(object sender, PropertyChangedEventArgs e)
        {
            this.UpdateDataGrid();
        }

        /// <summary>
        /// Updates the sum displayed.
        /// </summary>
        private void UpdateSum()
        {
            // now update the metrics on the bottom bar.
            if (this.controller.CurrentExpensesCount > 0)
            {
                this.DisplaySumTextBox.Text = this.controller.ComputeNetSum().ToString();
            }
            else
            {
                this.DisplaySumTextBox.Text = "No Expenses";
            }
        }

        /// <summary>
        /// Updates the average displayed.
        /// </summary>
        private void UpdateAverage()
        {
            // now update the metrics on the bottom bar.
            if (this.controller.CurrentExpensesCount > 0)
            {
                this.DisplayAverageTextBox.Text = this.controller.ComputeAverage(
                    (ExpenseController.EExpenseAverageInterval)this.AverageSelectionComboBox.SelectedIndex).ToString();
            }
            else
            {
                this.DisplayAverageTextBox.Text = "No Expenses";
            }
        }

        /// <summary>
        /// Reads values from controller and displays them in data grid.
        /// </summary>
        private void UpdateDataGrid()
        {
            this.ExpensesDataGridView.Rows.Clear();

            for (int i = 0; i < this.controller.CurrentExpensesCount; ++i)
            {
                Expense expense = this.controller.GetExpense(i);
                int index = this.ExpensesDataGridView.Rows.Add(
                    expense.Date.ToString(),
                    expense.Value.ToString(),
                    expense.Place,
                    string.Join(", ", expense.Tag),
                    expense.Notes,
                    expense.Method.ToString(),
                    "Edit",
                    "Delete");
            }

            this.UpdateSum();
            this.UpdateAverage();
        }

        /// <summary>
        /// Activates when a user selects to add an expense.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditExpenseDialog addDialog = new AddEditExpenseDialog();

            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                // get the information from the form.
                this.controller.InsertExpense(addDialog.Expense);
            }
        }

        /// <summary>
        /// Called when the edit button of an expense is clicked. Triggering the dialog.
        /// </summary>
        /// <param name="e">Expense the button was clicked for.</param>
        private void editButton_Click(Expense e)
        {
            AddEditExpenseDialog editDialog = new AddEditExpenseDialog(e);

            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                this.controller.EditExpense(editDialog.Expense);
            }
        }

        /// <summary>
        /// Called when the delete button of an expense is clicked. Triggers a confirm dialog.
        /// </summary>
        /// <param name="e">Expense to delete.</param>
        private void deleteButton_Click(Expense e)
        {
            var result =
                System.Windows.MessageBox.Show(
                    "Are you sure you wish to delete this expense?",
                    "Confirm Delete",
                    MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes)
            {
                this.controller.DeleteExpense(e);
            }
        }

        /// <summary>
        /// Triggers when cells need to be compared.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void ExpensesDataGridView_SortCompare(object sender, DataGridViewSortCompareEventArgs e)
        {
            // if the column being sorted is the Date column
            if (e.Column.Index == 0)
            {
                e.SortResult = DateTime.Parse(e.CellValue1.ToString())
                    .CompareTo(DateTime.Parse(e.CellValue2.ToString()));
                e.Handled = true;
            }

            // if the column being sorted is the PurchaseMethod
            else if (e.Column.Index == 5)
            {
                e.Handled = true;
            }
        }

        /// <summary>
        /// triggers when a new average method is selected.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void AverageSelectionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.UpdateAverage();
        }

        /// <summary>
        /// triggers when the clear filters toolstrip item is selected.
        /// </summary>
        /// <param name="sender">Object that registered the event.</param>
        /// <param name="e">Arguments passed with the event.</param>
        private void clearFiltersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.DisplayFilterNameTextBox.Text = "N/A";

            this.controller.ActiveFilter = null;
        }

        private void ExpensesDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (this.ExpensesDataGridView.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
                e.ColumnIndex > 5 &&
                e.RowIndex > -1)
            {
                if (e.ColumnIndex == 6)
                {
                    this.editButton_Click(this.controller.GetExpense(e.RowIndex));
                }
                else if (e.ColumnIndex == 7)
                {
                    this.deleteButton_Click(this.controller.GetExpense(e.RowIndex));
                }

            }
        }

        private void setCurrentFilterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddEditFilterDialog addDialog = new AddEditFilterDialog();

            if (addDialog.ShowDialog() == DialogResult.OK)
            {
                this.controller.ActiveFilter = addDialog.ExpenseFilter;
                this.DisplayFilterNameTextBox.Text = addDialog.ExpenseFilter.Name;
            }
        }
    }
}

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
        private ExpenseFilter activeFilter;

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
            this.ActiveFilter = null;

            // Initially load all expenses into controller
            this.currentExpenses = this.ExpenseDataAccess.GetAll();
            foreach (Expense e in this.currentExpenses)
            {
                e.PropertyChanged += this.OnExpensePropertyChanged;
            }
        }

        /// <summary>
        /// Event indicating that the controllers... TODO finish this
        /// </summary>
        public event PropertyChangedEventHandler ControllerDataRefreshed;

        /// <summary>
        /// Enumerates the intevals upon which an average can be computed.
        /// </summary>
        public enum EExpenseAverageInterval
        {
            /// <summary>
            /// Average per day.
            /// </summary>
            DAY,

            /// <summary>
            /// Average per week.
            /// </summary>
            WEEK,

            /// <summary>
            /// Average per month.
            /// </summary>
            MONTH,

            /// <summary>
            /// Average per year.
            /// </summary>
            YEAR,

            /// <summary>
            /// Average per decade.
            /// </summary>
            DECADE,

            /// <summary>
            /// Average per century.
            /// </summary>
            CENTURY,

            /// <summary>
            /// Average per item.
            /// </summary>
            ITEM,
        }

        /// <summary>
        /// Enumerates the fields of an expense that controller can sort by.
        /// </summary>
        public enum ESortField
        {
            /// <summary>
            /// Sort by Date.
            /// </summary>
            DATE,

            /// <summary>
            /// Sort by Value.
            /// </summary>
            VALUE,

            /// <summary>
            /// Sort by Place.
            /// </summary>
            PLACE,

            /// <summary>
            /// Sort by Method.
            /// </summary>
            METHOD,
        }

        /// <summary>
        /// Gets the number of expenses currently loaded in.
        /// </summary>
        public int CurrentExpensesCount => this.currentExpenses.Count();

        /// <summary>
        /// Gets a value indicating whether the controller currently has any expenses or not.
        /// </summary>
        public bool Empty => this.CurrentExpensesCount == 0;

        /// <summary>
        /// Gets a value indicating the maximum date the current expense list holds.
        /// </summary>
        public DateTime MaxDate => this.currentExpenses.Aggregate<Expense>((Expense acc, Expense e) =>
            {
                if (e.Date > acc.Date)
                {
                    return e;
                }

                return acc;
            }).Date;

        /// <summary>
        /// Gets a value indicating the minimum date the current expense list holds.
        /// </summary>
        public DateTime MinDate => this.currentExpenses.Aggregate<Expense>((Expense acc, Expense e) =>
            {
                if (e.Date < acc.Date)
                {
                    return e;
                }

                return acc;
            }).Date;

        /// <summary>
        /// Gets or Sets the active filter of the controller. Null if no filter is intended.
        /// In order for a filter to be applied, it must first be assigned here. This will
        /// trigger the <see cref="ControllerDataRefreshed"/> event which will reload the data
        /// from memory applying the filter and notifying listening parties to refresh their
        /// references.
        /// </summary>
        public ExpenseFilter ActiveFilter
        {
            get
            {
                return this.activeFilter;
            }

            set
            {
                this.activeFilter = value;
                this.RefreshExpenses();
            }
        }

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
        /// Sorts the controller by the given field.
        /// </summary>
        /// <param name="field">field to sort by.</param>
        /// <param name="ascending">Sort in ascending or descending order. Defaults to ascending(true).</param>
        public void SortBy(ESortField field, bool ascending = true)
        {
            this.currentExpenses.Sort((Expense e1, Expense e2) =>
            {
                int retVal;
                switch (field)
                {
                    case ESortField.DATE:
                        retVal = e1.Date.CompareTo(e2.Date);
                        break;
                    case ESortField.VALUE:
                        retVal = e1.Value.CompareTo(e2.Value);
                        break;
                    case ESortField.PLACE:
                        retVal = e1.Place.CompareTo(e2.Place);
                        break;
                    case ESortField.METHOD:
                        retVal = e1.Method.CompareTo(e2.Method);
                        break;
                    default:
                        throw new InvalidEnumArgumentException("Should never get here, use a valid value for ESortField");
                }

                if (!ascending)
                {
                    retVal *= -1;
                }

                return retVal;
            });
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
        /// Inserts the expense with the given values into the database. Triggers
        /// <see cref="ControllerDataRefreshed"/> event which reloads data from database.
        /// </summary>
        /// <param name="e">The expense to insert.</param>
        public void InsertExpense(Expense e)
        {
            this.ExpenseDataAccess.InsertRecord(e);

            this.RefreshExpenses();
        }

        /// <summary>
        /// Deletes the Expense indicated by index in the database. Triggers
        /// <see cref="ControllerDataRefreshed"/> event which reloads data from database.
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
        /// Computes the sum irregardless of sign.
        /// </summary>
        /// <returns>Float representing gross sum of expense values irregardless of sign.</returns>
        public float ComputeSum()
        {
            return this.currentExpenses.Aggregate(0, (float acc, Expense e) => Math.Abs(e.Value));
        }

        /// <summary>
        /// Computes the sum of all the expenses currently held in the object.
        /// </summary>
        /// <returns>Float representing sum of expense values.</returns>
        public float ComputeNetSum()
        {
            return this.currentExpenses.Aggregate(0, (float acc, Expense e) => e.Value);
        }

        /// <summary>
        /// Computes the average value exchanged per interval specified, defaults to DAY.
        /// </summary>
        /// <param name="interval">The interval on which the average should be calculated.</param>
        /// <returns>The Average value exchanged on each given interval.</returns>
        public float ComputeAverage(EExpenseAverageInterval interval = EExpenseAverageInterval.DAY)
        {
            if (this.Empty)
            {
                throw new InvalidOperationException("Error: cannot compute average on an empty list of expenses.");
            }

            int count;

            switch (interval)
            {
                case EExpenseAverageInterval.DAY:
                    count = (this.MaxDate - this.MinDate).Days;
                    break;
                case EExpenseAverageInterval.WEEK:
                    count = (int)Math.Ceiling((this.MaxDate - this.MinDate).Days / 7.0);
                    break;
                case EExpenseAverageInterval.MONTH:
                    count = (this.MaxDate.Month - this.MinDate.Month) + ((this.MaxDate.Year - this.MinDate.Year) * 12);
                    break;
                case EExpenseAverageInterval.YEAR:
                    count = this.MaxDate.Year - this.MinDate.Year;
                    break;
                case EExpenseAverageInterval.DECADE:
                    count = (this.MaxDate.Year / 10) - (this.MinDate.Year / 10);
                    break;
                case EExpenseAverageInterval.CENTURY:
                    count = (this.MaxDate.Year / 100) - (this.MinDate.Year / 100);
                    break;
                case EExpenseAverageInterval.ITEM:
                    count = this.CurrentExpensesCount;
                    break;
                default:
                    throw new InvalidEnumArgumentException("Should never get here, pass a valid enum value in, dont cast an integer.");
            }

            return count == 0 ? this.ComputeNetSum() : this.ComputeNetSum() / count;
        }

        /// <summary>
        /// Hard synchronises the objects data with the databases data. Triggers <see cref="ControllerDataRefreshed"/>
        /// event which will notify listening parties of the refresh.
        /// </summary>
        private void RefreshExpenses()
        {
            if (this.ActiveFilter != null)
            {
                this.currentExpenses = this.ExpenseDataAccess.FindAll(this.ActiveFilter);
            }
            else
            {
                this.currentExpenses = this.ExpenseDataAccess.GetAll();
            }

            // Reassign the listeners for the new expenses.
            foreach (Expense e in this.currentExpenses)
            {
                e.PropertyChanged += this.OnExpensePropertyChanged;
            }

            this.ControllerDataRefreshed?.Invoke(this, new PropertyChangedEventArgs(nameof(this.CurrentExpensesCount)));
        }

        /// <summary>
        /// Fires any time an Expense has been modified, and consequently writes its value back to the database.
        /// </summary>
        /// <param name="sender">Expense that triggered the event.</param>
        /// <param name="e">The properties that were changed.</param>
        private void OnExpensePropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            // Update the record in the database.
            this.ExpenseDataAccess.UpdateRecord(sender as Expense);
        }
    }
}

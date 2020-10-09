// <copyright file="Expense.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.Data.SQLite;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Represents one expense within the context of this application. Encapsulates data returned from the SQLite db.
    /// </summary>
    public class Expense
    {
        private int id;
        private float value;
        private DateTime date;
        private string place;
        private PurchaseMethod purchaseMethod;
        private HashSet<string> tag;
        private string notes;

        /// <summary>
        /// Initializes a new instance of the <see cref="Expense"/> class.
        /// </summary>
        /// <param name="id">The id of the reciept in the databse, -1 if not present in db yet.</param>
        /// <param name="value">The monetary value of the currency.</param>
        /// <param name="date">Date the expense was incurred.</param>
        /// <param name="place">Place expense was incurred.</param>
        /// <param name="method">Information about how expense was incurred.</param>
        /// <param name="tag">Tags categorizing expense.</param>
        /// <param name="notes">Other miscellaneous information.</param>
        public Expense(
            float value = 0.0f,
            DateTime date = default(DateTime),
            string place = "",
            PurchaseMethod method = default(Cash),
            HashSet<string> tag = null,
            string notes = "",
            int id = -1)
        {
            this.id = id;
            this.value = value;
            this.date = date;
            this.place = place;
            this.purchaseMethod = method;
            this.tag = tag ?? new HashSet<string>();
            this.notes = notes;
        }

        /// <summary>
        /// Gets id of expense in db. -1 if not yet present in db.
        /// </summary>
        public int Id
        {
            get { return this.id; }
        }

        /// <summary>
        /// Gets or sets monetary value of currency.
        /// </summary>
        public float Value
        {
            get { return this.value; }
            set { this.value = value; }
        }

        /// <summary>
        /// Gets or sets date expense was incurred.
        /// </summary>
        public DateTime Date
        {
            get { return this.date; }
            set { this.date = value; }
        }

        /// <summary>
        /// Gets or sets place expense was incurred.
        /// </summary>
        public string Place
        {
            get { return this.place; }
            set { this.place = value; }
        }

        /// <summary>
        /// Gets or sets method used to incur expense.
        /// </summary>
        public PurchaseMethod Method
        {
            get { return this.purchaseMethod; }
            set { this.purchaseMethod = value; }
        }

        /// <summary>
        /// Gets or sets extra miscellaneous information about expense.
        /// </summary>
        public string Notes
        {
            get { return this.notes; }
            set { this.notes = value; }
        }

        /// <summary>
        /// Gets tags categorizing expense.
        /// </summary>
        public HashSet<string> Tag
        {
            get { return this.tag; }
        }

        /// <summary>
        /// Adds a new tag to the expense.
        /// </summary>
        /// <param name="newTag">Value of new tag.</param>
        public void AddTag(string newTag)
        {
            this.tag.Add(newTag);
        }

        /// <summary>
        /// Removes existing tag from expense. If none exists do nothing.
        /// </summary>
        /// <param name="tagToRemove">Value of tag to find and remove.</param>
        public void RemoveTag(string tagToRemove)
        {
            this.tag.Remove(tagToRemove);
        }
    }
}

// <copyright file="Cash.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// A purchase method representing the cash method.
    /// </summary>
    public class Cash : PurchaseMethod
    {
        private string currency;

        /// <summary>
        /// Initializes a new instance of the <see cref="Cash"/> class.
        /// </summary>
        /// <param name="currency">The unit of currency of the cash.</param>
        public Cash(string currency = "USD")
        {
            this.currency = currency;
        }

        /// <summary>
        /// Gets or sets unit of the cash used.
        /// </summary>
        public string Currency
        {
            get { return this.currency; }
            set { this.currency = value; }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("Method: Cash, Currency: {0}", this.currency);
        }
    }
}

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
    public class Cash : PurchaseMethod, IComparable
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
        public override bool Equals(object obj)
        {
            Cash c = (Cash)obj;
            return this.Currency == c.Currency;
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            // code retrieved from: https://stackoverflow.com/questions/263400/what-is-the-best-algorithm-for-overriding-gethashcode
            unchecked
            {
                // Overflow is fine, just wrap
                int hash = 17;

                // Suitable nullity checks etc, of course :)
                hash = (hash * 23) + this.Currency.GetHashCode();
                return hash;
            }
        }

        /// <inheritdoc/>
        public new int CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card c = obj as Card;

                // Cash should always come before Card.
                return -1;
            }
            else if (obj is Cash)
            {
                Cash c = obj as Cash;

                return this.Currency.CompareTo(c.Currency);
            }
            else if (obj is DirectDeposit)
            {
                DirectDeposit d = obj as DirectDeposit;

                // Cash should always come before DirectDeposit.
                return -1;
            }
            else
            {
                throw new InvalidCastException("Types are incompatible, can only compare subclasses of PurchaseMethod with one another");
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format("Cash: {0}", this.currency);
        }
    }
}

// <copyright file="PurchaseMethod.cs" company="Harrison Collet">
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
    /// Abstract purchase method class for representing purchase methods.
    /// </summary>
    public abstract class PurchaseMethod
        : IComparable
    {
        /// <inheritdoc/>
        public int CompareTo(object obj)
        {
            if (this is Card)
            {
                Card t = this as Card;
                return t.CompareTo(obj);
            }
            else if (this is Cash)
            {
                Cash t = this as Cash;
                return t.CompareTo(obj);
            }
            else if (this is DirectDeposit)
            {
                DirectDeposit t = this as DirectDeposit;
                return t.CompareTo(obj);
            }
            else
            {
                throw new InvalidCastException("Types are incompatible, can only compare subclasses of PurchaseMethod with one another");
            }
        }
    }
}

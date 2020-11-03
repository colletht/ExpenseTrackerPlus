// <copyright file="DirectDeposit.cs" company="Harrison Collet">
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
    /// Models a Direct Deposit method of purchase.
    /// </summary>
    public class DirectDeposit : PurchaseMethod, IComparable
    {
        private bool savings;
        private string bankName;
        private int number;
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectDeposit"/> class.
        /// </summary>
        /// <param name="savings">Represents if the accound is savings or not.</param>
        /// <param name="bankName">The name of the bank the account is under.</param>
        /// <param name="number">The abbreviated six digit account number.</param>
        /// <param name="name">The name the account is under.</param>
        public DirectDeposit(
            bool savings = false,
            string bankName = "Bank of America",
            int number = 123456,
            string name = "John Doe")
        {
            this.savings = savings;
            this.bankName = bankName;
            this.number = number;
            this.name = name;
        }

        /// <summary>
        /// Gets or sets a value indicating whether represents if the accound is savings or not.
        /// </summary>
        public bool Savings
        {
            get { return this.savings; }
            set { this.savings = value; }
        }

        /// <summary>
        /// Gets or sets the name of the bank the account is under.
        /// </summary>
        public string BankName
        {
            get { return this.bankName; }
            set { this.bankName = value; }
        }

        /// <summary>
        /// Gets or sets the abbreviated six digit account number.
        /// </summary>
        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        /// <summary>
        /// Gets or sets the name the account is under.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            DirectDeposit d = (DirectDeposit)obj;
            return (this.Savings == d.Savings) &&
                (this.BankName == d.BankName) &&
                (this.Number == d.Number) &&
                (this.Name == d.Name);
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
                hash = (hash * 23) + this.Savings.GetHashCode();
                hash = (hash * 23) + this.BankName.GetHashCode();
                hash = (hash * 23) + this.Number.GetHashCode();
                hash = (hash * 23) + this.Name.GetHashCode();
                return hash;
            }
        }

        /// <inheritdoc/>
        public new int CompareTo(object obj)
        {
            if (obj is Card)
            {
                Card c = obj as Card;

                // DirectDeposit should always come after Card.
                return 1;
            }
            else if (obj is Cash)
            {
                Cash c = obj as Cash;

                // DirectDeposit should always come after Cash.
                return 1;
            }
            else if (obj is DirectDeposit)
            {
                DirectDeposit d = obj as DirectDeposit;

                if (this.BankName.CompareTo(d.BankName) == 0)
                {
                    if (this.Number.CompareTo(d.Number) == 0)
                    {
                        if (this.Savings.CompareTo(d.Savings) == 0)
                        {
                            return this.Name.CompareTo(d.Name);
                        }
                        else
                        {
                            return this.Savings.CompareTo(d.Savings);
                        }
                    }
                    else
                    {
                        return this.Number.CompareTo(d.Number);
                    }
                }
                else
                {
                    return this.BankName.CompareTo(d.BankName);
                }
            }
            else
            {
                throw new InvalidCastException("Types are incompatible, can only compare subclasses of PurchaseMethod with one another");
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(
                "Direct Deposit {0} Account {1} at {2}: Owned by: {3}",
                this.Savings ? "Savings" : "Checking",
                this.Number,
                this.BankName,
                this.Name);
        }
    }
}

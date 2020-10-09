// <copyright file="Card.cs" company="Harrison Collet">
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
    /// Models the purchase method representing a card.
    /// </summary>
    public class Card : PurchaseMethod
    {
        private bool debit;
        private string provider;
        private int number;
        private string name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Card"/> class.
        /// </summary>
        /// <param name="debit">True or false if card is a debit or not.</param>
        /// <param name="provider">Name of the provider of the card.</param>
        /// <param name="number">Last four numbers of card.</param>
        /// <param name="name">Name of the cardholder.</param>
        public Card(
            bool debit = true,
            string provider = "VISA",
            int number = 1234,
            string name = "John Doe")
        {
            this.debit = debit;
            this.provider = provider;
            this.number = number;
            this.name = name;
        }

        /// <summary>
        /// Gets or sets a value indicating whether the card is a debit card or not.
        /// </summary>
        public bool Debit
        {
            get { return this.debit; }
            set { this.debit = value; }
        }

        /// <summary>
        /// Gets or sets name of the provider of the card.
        /// </summary>
        public string Provider
        {
            get { return this.provider; }
            set { this.provider = value; }
        }

        /// <summary>
        /// Gets or sets last four numbers of card.
        /// </summary>
        public int Number
        {
            get { return this.number; }
            set { this.number = value; }
        }

        /// <summary>
        /// Gets or sets name of the cardholder.
        /// </summary>
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}

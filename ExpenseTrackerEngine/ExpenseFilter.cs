// <copyright file="ExpenseFilter.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Text.RegularExpressions;
    using System.Threading.Tasks;

    /// <summary>
    /// Class Models a filter which encompasses a set of expense objects.
    /// </summary>
    public class ExpenseFilter
    {
        private float maxValue;
        private float minValue;
        private DateTime maxDate;
        private DateTime minDate;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseFilter"/> class.
        /// Used to declare instance with both ranged value and date arguments.
        /// Filters created in this way will not be able to specify exact values
        /// or dates..
        /// </summary>
        /// <param name="name">The name to give to the expense filter.</param>
        /// <param name="maxValue">High value for value range, defaults to float.MaxValue.</param>
        /// <param name="minValue">Low value for value range, defaults to float.MinValue.</param>
        /// <param name="maxDate">High value for date range, defaults to DateTime.MaxValue.</param>
        /// <param name="minDate">Min value for date range, defaults to DateTime.MinValue.</param>
        /// <param name="place">Expression for places we want to match, defaults to match all strings.</param>
        /// <param name="tag">Expression for tag we want to match, defaults to match all strings.</param>
        /// <param name="keywords">Expression for keywords we want to match, defaults to match all strings.</param>
        /// <param name="method">Method we want to match. This is always an exact matcher unless none is specified, then purchase method is disregarded when filtering.</param>
        public ExpenseFilter(
            string name,
            float maxValue = float.MaxValue,
            float minValue = float.MinValue,
            DateTime maxDate = default(DateTime),
            DateTime minDate = default(DateTime),
            HashSet<string> place = null,
            HashSet<string> tag = null,
            HashSet<string> keywords = null,
            PurchaseMethod method = null)
        {
            // initialize name
            this.Name = name;

            // initialize value filters
            this.MaxValue = maxValue;
            this.MinValue = minValue;

            // initialize date filters
            this.MaxDate = (maxDate == default(DateTime)) ? DateTime.MaxValue : maxDate;
            this.MinDate = (minDate == default(DateTime)) ? DateTime.MinValue : minDate;

            // initialize HashSet<string> arguments
            this.Place = place ?? new HashSet<string>();
            this.Tag = tag ?? new HashSet<string>();
            this.Keywords = keywords ?? new HashSet<string>();

            // initialize method
            this.Method = method;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseFilter"/> class.
        /// Used to declare an instance which matches a required exact value, with
        /// ranged date arguments. Filters created in this way will not be able to
        /// specify exact date values.
        /// </summary>
        /// <param name="name">The name to give to the expense filter.</param>
        /// <param name="valueExact">Exact value that we want to match. Required.</param>
        /// <param name="maxDate">High value for date range, defaults to DateTime.MaxValue.</param>
        /// <param name="minDate">Min value for date range, defaults to DateTime.MinValue.</param>
        /// <param name="place">Expression for places we want to match, defaults to match all strings.</param>
        /// <param name="tag">Expression for tag we want to match, defaults to match all strings.</param>
        /// <param name="keywords">Expression for keywords we want to match, defaults to match all strings.</param>
        /// <param name="method">Method we want to match. This is always an exact matcher unless none is specified, then purchase method is disregarded when filtering.</param>
        public ExpenseFilter(
            string name,
            float valueExact,
            DateTime maxDate = default(DateTime),
            DateTime minDate = default(DateTime),
            HashSet<string> place = null,
            HashSet<string> tag = null,
            HashSet<string> keywords = null,
            PurchaseMethod method = null)
        {
            // initialize name
            this.Name = name;

            // initialize value filters
            this.ExactValue = valueExact;

            // initialize date filters
            this.MaxDate = (maxDate == default(DateTime)) ? DateTime.MaxValue : maxDate;
            this.MinDate = (minDate == default(DateTime)) ? DateTime.MinValue : minDate;

            // initialize HashSet<string> arguments
            this.Place = place ?? new HashSet<string>();
            this.Tag = tag ?? new HashSet<string>();
            this.Keywords = keywords ?? new HashSet<string>();

            // initialize method
            this.Method = method;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseFilter"/> class.
        /// Used to declare an instance which matches a required exact date, with
        /// ranged value arguments. Filters created in this way will not be able
        /// to specify exact value values.
        /// </summary>
        /// <param name="name">The name to give to the expense filter.</param>
        /// <param name="dateExact">Exact date to match. Required.</param>
        /// <param name="maxValue">High value for value range, defaults to float.MaxValue.</param>
        /// <param name="minValue">Low value for value range, defaults to float.MinValue.</param>
        /// <param name="place">Expression for places we want to match, defaults to match all strings.</param>
        /// <param name="tag">Expression for tag we want to match, defaults to match all strings.</param>
        /// <param name="keywords">Expression for keywords we want to match, defaults to match all strings.</param>
        /// <param name="method">Method we want to match. This is always an exact matcher unless none is specified, then purchase method is disregarded when filtering.</param>
        public ExpenseFilter(
            string name,
            DateTime dateExact,
            float maxValue = float.MaxValue,
            float minValue = float.MinValue,
            HashSet<string> place = null,
            HashSet<string> tag = null,
            HashSet<string> keywords = null,
            PurchaseMethod method = null)
        {
            // initialize name
            this.Name = name;

            // initialize value filters
            this.maxValue = maxValue;
            this.minValue = minValue;

            this.minDate = DateTime.MinValue;
            this.maxDate = DateTime.MaxValue;

            // initialize date filters
            this.ExactDate = dateExact;

            // initialize HashSet<string> arguments
            this.Place = place ?? new HashSet<string>();
            this.Tag = tag ?? new HashSet<string>();
            this.Keywords = keywords ?? new HashSet<string>();

            // initialize method
            this.Method = method;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ExpenseFilter"/> class.
        /// Used to declare an instance which matches a required exact value and date.
        /// Filters created in this way will not be able to specify ranged values of date
        /// or values.
        /// </summary>
        /// <param name="name">The name to give to the expense filter.</param>
        /// <param name="valueExact">Exact value that we want to match. Required.</param>
        /// <param name="dateExact">Exact date to match. Required.</param>
        /// <param name="place">Expression for places we want to match, defaults to match all strings.</param>
        /// <param name="tag">Expression for tag we want to match, defaults to match all strings.</param>
        /// <param name="keywords">Expression for keywords we want to match, defaults to match all strings.</param>
        /// <param name="method">Method we want to match. This is always an exact matcher unless none is specified, then purchase method is disregarded when filtering.</param>
        public ExpenseFilter(
            string name,
            float valueExact,
            DateTime dateExact,
            HashSet<string> place = null,
            HashSet<string> tag = null,
            HashSet<string> keywords = null,
            PurchaseMethod method = null)
        {
            // initialize name
            this.Name = name;

            this.minValue = float.MinValue;
            this.maxValue = float.MaxValue;

            // initialize value filters
            this.ExactValue = valueExact;

            this.minDate = DateTime.MinValue;
            this.maxDate = DateTime.MaxValue;

            // initialize date filters
            this.ExactDate = dateExact;

            // initialize HashSet<string> arguments
            this.Place = place ?? new HashSet<string>();
            this.Tag = tag ?? new HashSet<string>();
            this.Keywords = keywords ?? new HashSet<string>();

            // initialize method
            this.Method = method;
        }

        /// <summary>
        /// Gets the Name of the filter.
        /// </summary>
        public string Name
        {
            get;
        }

        /// <summary>
        /// Gets or Sets MaxValue. MaxValue an the inclusive upperbound.
        /// </summary>
        /// <throws><see cref="ArgumentOutOfRangeException"/> if new MaxValue is less than MinValue.</throws>
        public float MaxValue
        {
            get
            {
                return this.maxValue;
            }

            set
            {
                if (value < this.minValue)
                {
                    throw new ArgumentOutOfRangeException("Error: value for MaxValue must be at least equal to MinValue or higher.");
                }

                this.maxValue = value;
            }
        }

        /// <summary>
        /// Gets or Sets MinValue. MinValue is the inclusive lowerbound.
        /// </summary>
        /// <throws><see cref="ArgumentOutOfRangeException"/> if new MinValue is greater than MaxValue.</throws>
        public float MinValue
        {
            get
            {
                return this.minValue;
            }

            set
            {
                if (value > this.maxValue)
                {
                    throw new ArgumentOutOfRangeException("Error: value for MinValue must be at least equal to MaxValue or lower.");
                }

                this.minValue = value;
            }
        }

        /// <summary>
        /// Sets ExactValue. Adjusts MaxValue and MinValue so that only the given value is accepted.
        /// </summary>
        public float ExactValue
        {
            set
            {
                this.MaxValue = value;
                this.MinValue = value;
            }
        }

        /// <summary>
        /// Gets or Sets MaxDate. MaxDate is the inclusive upper bound.
        /// </summary>
        /// <throws><see cref="ArgumentOutOfRangeException"/> if new MaxDate is less than MinDate.</throws>
        public DateTime MaxDate
        {
            get
            {
                return this.maxDate;
            }

            set
            {
                if (value < this.minDate)
                {
                    throw new ArgumentOutOfRangeException("Error: value for MaxDate must be at least equal to MinDate or higher.");
                }

                this.maxDate = value;
            }
        }

        /// <summary>
        /// Gets or Sets MinDate. MinDate is the exclusive lower bound.
        /// </summary>
        /// <throws><see cref="ArgumentOutOfRangeException"/> if new MinDate is greater than MaxDate.</throws>
        public DateTime MinDate
        {
            get
            {
                return this.minDate;
            }

            set
            {
                if (value > this.maxDate)
                {
                    throw new ArgumentOutOfRangeException("Error: value for MinDate must be at least equal to MaxDate or lower.");
                }

                this.minDate = value;
            }
        }

        /// <summary>
        /// Sets ExactDate. Adjusts Min and Max Date so that only the value passed is accepted.
        /// </summary>
        /// <throws><see cref="InvalidOperationException"/> if AcceptsExactDates is false.</throws>
        public DateTime ExactDate
        {
            set
            {
                this.MaxDate = value;
                this.MinDate = value;
            }
        }

        /// <summary>
        /// Gets the <see cref="HashSet{T}"/> for matching place.
        /// </summary>
        public HashSet<string> Place { get; set; }

        /// <summary>
        /// Gets the <see cref="HashSet{T}"/> for matching tags.
        /// </summary>
        public HashSet<string> Tag { get; set; }

        /// <summary>
        /// Gets the <see cref="HashSet{T}"/> for matching keywords in the notes.
        /// </summary>
        public HashSet<string> Keywords { get; set; }

        /// <summary>
        /// Gets or Sets the PurchaseMethod being used to match.
        /// </summary>
        public PurchaseMethod Method { get; set; }

        /// <summary>
        /// Creates a new expense filter that matches the provided expense.
        /// NOTE: the keyword argument is NOT placed in the filter. neither
        /// is the method argument, these can be added after if prefered.
        /// </summary>
        /// <param name="filterName">Name to be given to the new filter.</param>
        /// <param name="e">Expense to create a filter for.</param>
        /// <returns>A filter matching the expense.</returns>
        public static ExpenseFilter FromExpense(string filterName, Expense e)
        {
            return new ExpenseFilter(
                name: filterName,
                valueExact: e.Value,
                dateExact: e.Date,
                place: new HashSet<string> { e.Place },
                tag: e.Tag);
        }

        /// <summary>
        /// computes intersection of two filters and returns a new filter.
        /// if the two filters produce a null intersection, null is returned.
        /// </summary>
        /// <param name="f1">First Filter to intersect with.</param>
        /// <param name="f2">Second Filter to intersect with.</param>
        /// <returns>ExpenseFilter containing the intersection.</returns>
        public static ExpenseFilter Intersection(ExpenseFilter f1, ExpenseFilter f2)
        {
            // NOTE: Implementation is stretch goal
            throw new NotImplementedException();
        }

        /// <summary>
        /// computes union of two filters and returns a new filter.
        /// </summary>
        /// <param name="f1">First Filter to intersect with.</param>
        /// <param name="f2">Second Filter to intersect with.</param>
        /// <param name="filterName">Name to be given to the new filter. Defaults to "f1.Name|f2.Name".</param>
        /// <returns>ExpenseFilter containing the union.</returns>
        public static ExpenseFilter Union(ExpenseFilter f1, ExpenseFilter f2, string filterName = "")
        {
            if (filterName == string.Empty)
            {
                filterName = f1.Name + '|' + f2.Name;
            }

            return new ExpenseFilter(
                    name: filterName,
                    maxValue: new[] { f1.MaxValue, f2.MaxValue }.Max(),
                    minValue: new[] { f1.MinValue, f2.MinValue }.Min(),
                    maxDate: new[] { f1.MaxDate, f2.MaxDate }.Max(),
                    minDate: new[] { f1.MinDate, f2.MinDate }.Min(),
                    place: new HashSet<string>(f1.Place.Union(f2.Place)),
                    tag: new HashSet<string>(f1.Tag.Union(f2.Tag)),
                    keywords: new HashSet<string>(f1.Keywords.Union(f2.Keywords)),
                    method: ExpenseFilter.MethodEqual(f1.Method, f2.Method) ? f1.Method : null);
        }

        /// <inheritdoc/>
        public override bool Equals(object obj)
        {
            ExpenseFilter f = (ExpenseFilter)obj;

            return (this.Name == f.Name) &&
                (this.MinValue == f.MinValue) &&
                (this.MaxValue == f.MaxValue) &&
                (this.MinDate == f.MinDate) &&
                (this.MaxDate == f.MaxDate) &&
                this.Place.SetEquals(f.Place) &&
                this.Tag.SetEquals(f.Tag) &&
                this.Keywords.SetEquals(f.Keywords) &&
                ExpenseFilter.MethodEqual(this.Method, f.Method);
        }

        /// <summary>
        /// Checks that the two filters functionally are the same. That is they match the same set of expenses.
        /// The name is left out during this comparison.
        /// </summary>
        /// <param name="f">Filter to compare against.</param>
        /// <returns>True if the filters are functionaly equal. False if not.</returns>
        public bool FunctionalEquals(ExpenseFilter f)
        {
            return (this.MinValue == f.MinValue) &&
                (this.MaxValue == f.MaxValue) &&
                (this.MinDate == f.MinDate) &&
                (this.MaxDate == f.MaxDate) &&
                this.Place.SetEquals(f.Place) &&
                this.Tag.SetEquals(f.Tag) &&
                this.Keywords.SetEquals(f.Keywords) &&
                ExpenseFilter.MethodEqual(this.Method, f.Method);
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
                hash = (hash * 23) + this.Name.GetHashCode();
                hash = (hash * 23) + this.MaxValue.GetHashCode();
                hash = (hash * 23) + this.MinValue.GetHashCode();
                hash = (hash * 23) + this.MaxDate.GetHashCode();
                hash = (hash * 23) + this.MinDate.GetHashCode();
                hash = (hash * 23) + this.Place.GetHashCode();
                hash = (hash * 23) + this.Tag.GetHashCode();
                hash = (hash * 23) + this.Keywords.GetHashCode();

                if (this.Method != null)
                {
                    hash = (hash * 23) + this.Method.GetHashCode();
                }

                return hash;
            }
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            string outstring = string.Format(
                "ExpenseFilter {0}: {1}-{2}, {3}-{4}",
                this.Name,
                this.MinValue,
                this.maxValue,
                this.MinDate,
                this.MaxDate);

            if (this.Place.Count == 0)
            {
                outstring += ", Place: ANY";
            }
            else
            {
                outstring += string.Format(
                    ", Place: {0}",
                    string.Join("|", this.Place));
            }

            if (this.Tag.Count == 0)
            {
                outstring += ", Tag: ANY";
            }
            else
            {
                outstring += string.Format(
                    ", Tag: {0}",
                    string.Join("|", this.Tag));
            }

            if (this.Keywords.Count == 0)
            {
                outstring += ", Keywords: ANY";
            }
            else
            {
                outstring += string.Format(
                    ", Keywords: {0}",
                    string.Join("|", this.Keywords));
            }

            if (this.Method == null)
            {
                outstring += ", Method: ANY";
            }
            else
            {
                outstring += string.Format(
                    ", Method: ({0})",
                    this.Method.ToString());
            }

            return outstring;
        }

        private static bool MethodEqual(PurchaseMethod m1, PurchaseMethod m2)
        {
            if (m1 == null && m2 == null)
            {
                return true;
            }
            else if ((m1 == null && m2 != null) ||
                (m1 != null && m2 == null))
            {
                return false;
            }
            else
            {
                if (m1 is Cash && m2 is Cash)
                {
                    return ((Cash)m1).Equals((Cash)m2);
                }

                if (m1 is Card && m2 is Card)
                {
                    return ((Card)m1).Equals((Card)m2);
                }

                if (m1 is DirectDeposit && m2 is DirectDeposit)
                {
                    return ((DirectDeposit)m1).Equals((DirectDeposit)m2);
                }

                // If they have differing types they arent equal.
                return false;
            }
        }
    }
}

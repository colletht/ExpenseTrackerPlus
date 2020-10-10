// <copyright file="ExpenseFilterTest.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace NUnit.ExpenseTrackerEngineTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using ExpenseTrackerEngine;
    using NUnit.Framework;

    /// <summary>
    /// For testing functionality of ExpenseFilter.
    /// </summary>
    [TestFixture]
    public class ExpenseFilterTest
    {
        /// <summary>
        /// Setup function.
        /// </summary>
        [SetUp]
        public void SetUp()
        {
        }

        /// <summary>
        /// Tests functionality of FromExpense.
        /// </summary>
        [Test]
        public void FromExpenseTest()
        {
            Expense e = new Expense(
                50f,
                DateTime.Today,
                "Walmart",
                new Card(),
                new HashSet<string> { "food", "hygene" },
                "Bought groceries and handsoap");

            ExpenseFilter f = new ExpenseFilter(
                50f,
                DateTime.Today,
                new HashSet<string> { "Walmart" },
                new HashSet<string> { "food", "hygene" });

            Assert.AreEqual(f, ExpenseFilter.FromExpense(e));
        }

        /// <summary>
        /// Tests functionality of Union.
        /// </summary>
        [Test]
        public void UnionTest()
        {
            // case 1: Filters have no intersection.
            ExpenseFilter f1 = new ExpenseFilter(
                1000f,
                DateTime.Today.AddYears(5),
                new HashSet<string> { "Walmart" },
                new HashSet<string> { "Groceries", "Food" },
                new HashSet<string> { "ChexMix" },
                new Card());

            ExpenseFilter f2 = new ExpenseFilter(
                -1000f,
                DateTime.Today.AddYears(-5),
                new HashSet<string> { "ToysRUs" },
                new HashSet<string> { "Games" },
                new HashSet<string> { "Mario" },
                new Cash());

            ExpenseFilter fSolution = new ExpenseFilter(
                1000f,
                -1000f,
                DateTime.Today.AddYears(5),
                DateTime.Today.AddYears(-5),
                new HashSet<string> { "Walmart", "ToysRUs" },
                new HashSet<string> { "Groceries", "Games", "Food" },
                new HashSet<string> { "ChexMix", "Mario" });

            ExpenseFilter fUnion = ExpenseFilter.Union(f1, f2);

            Assert.AreEqual(fSolution, fUnion);

            // case 2: Filters have a intersection.
            f1 = new ExpenseFilter(
                1000f,
                -1000f,
                DateTime.Today.AddYears(5),
                DateTime.Today.AddYears(-5),
                new HashSet<string> { "Walmart" },
                new HashSet<string> { "Groceries", "Food" },
                new HashSet<string> { "ChexMix" },
                new Card());

            f2 = new ExpenseFilter(
                1500f,
                -500f,
                DateTime.Today.AddYears(7),
                DateTime.Today.AddYears(-2),
                new HashSet<string> { "ToysRUs" },
                new HashSet<string> { "Games" },
                new HashSet<string> { "Mario" },
                new Card());

            fSolution = new ExpenseFilter(
                1500f,
                -1000f,
                DateTime.Today.AddYears(7),
                DateTime.Today.AddYears(-5),
                new HashSet<string> { "Walmart", "ToysRUs" },
                new HashSet<string> { "Groceries", "Games", "Food" },
                new HashSet<string> { "ChexMix", "Mario" },
                new Card());

            fUnion = ExpenseFilter.Union(f1, f2);

            Assert.AreEqual(fSolution, fUnion);
        }

        /// <summary>
        /// Teardown function.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
        }
    }
}

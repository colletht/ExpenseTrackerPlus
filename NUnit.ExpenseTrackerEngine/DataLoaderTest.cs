// <copyright file="DataLoaderTest.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

// TODO: Try encrypting data wiht passowrd - https://web.archive.org/web/20100207030625/http://Sqlite.phxsoftware.com/forums/t/130.aspx
// research what encryption standard is used here
// https://www.Sqlite.org/see/doc/release/www/readme.wiki
namespace NUnit.ExpenseTrackerEngineTest
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using ExpenseTrackerEngine;
    using Microsoft.Data.Sqlite;
    using NUnit.Framework;

    /// <summary>
    /// Class for exercising ExpenseTrackerEngine.DataLoaderTest.
    /// </summary>
    [TestFixture]
    public class DataLoaderTest
    {
        private const string TABLENAME = "Expenses";
        private User testUser;
        private DataAccessFactory dataAccessFactory;

        /// <summary>
        /// Sets up testing assets.
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\myDatabase.db");
            Console.WriteLine("Here in one time Setup");
            this.testUser = new User("testUser", "password", "mysupersecretkey", "myDatabase", "supersaltysalt");
            this.dataAccessFactory = new DataAccessFactory(this.testUser);
        }

        /// <summary>
        /// Local method setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Here in Setup!");
        }

        /// <summary>
        /// Tests that CreateNewExpenseTable creates a correct base table.
        /// </summary>
        [Test]
        public void CreateNewExpenseTableTest()
        {
            string[] columns = { "Id", "Value", "Date", "Place", "Tag", "Notes", "Type", "Debit", "Provider", "Number", "Name", "Currency", "Savings", "Bankname" };
            string[] types = { "INTEGER", "DECIMAL", "DATETIME", "VARCHAR(50)", "VARCHAR(200)", "VARCHAR(200)", "INTEGER", "INTEGER", "VARCHAR(20)", "INTEGER", "VARCHAR(100)", "VARCHAR(20)", "INTEGER", "VARCHAR(50)" };
            int i = 0;

            this.dataAccessFactory.CreateNewExpenseTable();

            // verify columns created correctly
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("PRAGMA table_info({0});", TABLENAME);
                    SqliteDataReader res = cmd.ExecuteReader();
                    while (res.Read())
                    {
                        Console.WriteLine($"{res.GetString(1),-8} {res.GetString(2),-8}");
                        Assert.That(
                            res.GetString(1),
                            Is.EqualTo(columns[i]),
                            string.Format("Row: {0}", i));  // check that column names are correct
                        Assert.That(
                            res.GetString(2),
                            Is.EqualTo(types[i]),
                            string.Format("Row: {0}", i));    // check that column types are correct
                        ++i;
                    }
                }

                // Clean table of all entries for consecutive runs
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tests that insert record validly inserts data that is correct, into DB.
        /// </summary>
        [Test]
        public void InsertRecordTest()
        {
            if (!this.dataAccessFactory.ExpenseTableExists)
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable();
            }

            Expense e = new Expense(
                50.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                null,
                "bought groceries and deoderant");

            e.AddTag("Food");
            e.AddTag("Hygene");

            this.dataAccessFactory.InsertRecord(e);

            // verify columns created correctly
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT * FROM {0};", TABLENAME);

                    using (SqliteDataReader res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            Console.WriteLine(this.StringifyDataRow(res));
                            Assert.AreEqual(1, res.GetInt32(0));                                            // Id
                            Assert.AreEqual(e.Value, (float)res.GetDecimal(1));                             // Value
                            Assert.AreEqual(e.Date, res.GetDateTime(2));                                    // Date
                            Assert.AreEqual(e.Place, res.GetString(3));                                     // Place
                            Assert.AreEqual(string.Join(":", e.Tag), res.GetString(4));                     // Tag
                            Assert.AreEqual(e.Notes, res.GetString(5));                                     // Notes
                            Assert.AreEqual((int)DataAccessFactory.EpurchaseMethod.CASH, res.GetInt32(6));  // type
                            Assert.True(res.IsDBNull(7)); // Debit field should be null.                     Debit
                            Assert.True(res.IsDBNull(8)); // Provider field should be null.                  Provider
                            Assert.True(res.IsDBNull(9)); // Number should be null.                          Number
                            Assert.True(res.IsDBNull(10)); // Name should be null.                           Name
                            Assert.False(res.IsDBNull(11)); // Currency should NOT be null.                  Currency
                            Assert.AreEqual((e.Method as Cash).Currency, res.GetValue(11).ToString());      // Currency
                            Assert.True(res.IsDBNull(12));                                                  // Savings
                            Assert.True(res.IsDBNull(13));                                                  // Bankname
                        }
                    }
                }

                // Clean table of all entries for consecutive runs
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tests that UpdateRecord executes succesfully with 'correct' inputs.
        /// </summary>
        [Test]
        public void UpdateRecordTest()
        {
            if (!this.dataAccessFactory.ExpenseTableExists)
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable();
            }

            Expense e = new Expense(
                50.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                null,
                "bought groceries and deoderant");

            e.AddTag("Food");
            e.AddTag("Hygene");

            this.dataAccessFactory.InsertRecord(e);

            // Now change e and update it
            e = new Expense(
                1,                  // Note: never hard assign this value except here for testing.
                999.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                null,
                "bought drugz");
            e.AddTag("Drugs");

            this.dataAccessFactory.UpdateRecord(e);

            // verify columns created correctly
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT * FROM {0};", TABLENAME);

                    using (SqliteDataReader res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            Console.WriteLine(this.StringifyDataRow(res));
                            Assert.AreEqual(1, res.GetInt32(0));                                            // Id
                            Assert.AreEqual(e.Value, (float)res.GetDecimal(1));                             // Value
                            Assert.AreEqual(e.Date, res.GetDateTime(2));                                    // Date
                            Assert.AreEqual(e.Place, res.GetString(3));                                     // Place
                            Assert.AreEqual(string.Join(":", e.Tag), res.GetString(4));                     // Tag
                            Assert.AreEqual(e.Notes, res.GetString(5));                                     // Notes
                            Assert.AreEqual((int)DataAccessFactory.EpurchaseMethod.CASH, res.GetInt32(6));  // type
                            Assert.True(res.IsDBNull(7)); // Debit field should be null.                     Debit
                            Assert.True(res.IsDBNull(8)); // Provider field should be null.                  Provider
                            Assert.True(res.IsDBNull(9)); // Number should be null.                          Number
                            Assert.True(res.IsDBNull(10)); // Name should be null.                           Name
                            Assert.False(res.IsDBNull(11)); // Currency should NOT be null.                  Currency
                            Assert.AreEqual((e.Method as Cash).Currency, res.GetValue(11).ToString());      // Currency
                            Assert.True(res.IsDBNull(12));                                                  // Savings
                            Assert.True(res.IsDBNull(13));                                                  // Bankname
                        }
                    }
                }

                // Clean table of all entries for consecutive runs
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tests that DeleteRecord executes succesfully with 'correct' inputs.
        /// </summary>
        [Test]
        public void DeleteRecordTest()
        {
            if (!this.dataAccessFactory.ExpenseTableExists)
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable();
            }

            Expense e = new Expense(
                50.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                null,
                "bought groceries and deoderant");

            e.AddTag("Food");
            e.AddTag("Hygene");

            this.dataAccessFactory.InsertRecord(e);

            // Now delete it
            this.dataAccessFactory.DeleteRecord(1);

            // verify columns created correctly
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT count(*) FROM {0};", TABLENAME);

                    using (SqliteDataReader res = cmd.ExecuteReader())
                    {
                        while (res.Read())
                        {
                            Console.WriteLine(
                                $@"{res.GetInt32(0),-3}");
                            Assert.AreEqual(0, res.GetInt32(0));    // count
                        }
                    }
                }

                // Clean table of all entries for consecutive runs
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tests that find all executes succesfully.
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            if (!this.dataAccessFactory.ExpenseTableExists)
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable();
            }

            Expense e = new Expense(
                50.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                null,
                "bought groceries and deoderant");

            e.AddTag("Food");
            e.AddTag("Hygene");

            this.dataAccessFactory.InsertRecord(e);
            this.dataAccessFactory.InsertRecord(e);
            this.dataAccessFactory.InsertRecord(e);

            List<Expense> expenses = this.dataAccessFactory.GetAll();

            Assert.AreEqual(3, expenses.Count);
            foreach (Expense expense in expenses)
            {
                Assert.AreEqual(e, expense);
            }

            // Clean table of all entries for consecutive runs
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tests that FindOne functions properly.
        /// </summary>
        [Test]
        public void FindOneTest()
        {
            if (!this.dataAccessFactory.ExpenseTableExists)
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable();
            }

            // put expenses into database
            Expense e1 = new Expense(
                50.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                new HashSet<string> { "Food", "Hygene" },
                "bought groceries and deoderant");

            Expense e2 = new Expense(
                -150.00f,
                DateTime.Today.AddYears(5),
                "Safeway",
                new Card(),
                new HashSet<string> { "Food", "Hygene" },
                "bought groceries and deoderant");

            Expense e3 = new Expense(
                1000.00f,
                DateTime.Today.AddYears(-5),
                "GameStop",
                new DirectDeposit(),
                new HashSet<string> { "Pay" },
                "first paycheck from gamestop");

            this.dataAccessFactory.InsertRecord(e1);
            this.dataAccessFactory.InsertRecord(e2);
            this.dataAccessFactory.InsertRecord(e3);

            // case: only one expense is returned anyways
            ExpenseFilter f = new ExpenseFilter(
                name: "TestFilter",
                place: new HashSet<string> { "GameStop" });

            Expense result = this.dataAccessFactory.FindOne(f);

            Assert.AreEqual(e3, result);

            // case: nothing is returned
            f = new ExpenseFilter(
                name: "TestFilter",
                dateExact: DateTime.Today.AddDays(3));

            result = this.dataAccessFactory.FindOne(f);

            Assert.IsNull(result);

            // case: multiple are returned so we need to make sure they are ordered correctly.
            f = new ExpenseFilter(
                name: "TestFilter",
                keywords: new HashSet<string> { "groceries" });

            result = this.dataAccessFactory.FindOne(f);

            Assert.AreEqual(e1, result);    // Since both e1 and e2 match they should be sorted ascendingly by id, since e1 was inserted first it should have a lower id and thus be selected over e2

            // Clean table of all entries for consecutive runs
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tests functionality of FindAll.
        /// </summary>
        [Test]
        public void FindAllTest()
        {
            if (!this.dataAccessFactory.ExpenseTableExists)
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable();
            }

            // put expenses into database
            Expense e1 = new Expense(
                50.00f,
                DateTime.Today,
                "Walmart",
                new Cash(),
                new HashSet<string> { "Food", "Hygene" },
                "bought groceries and deoderant");

            Expense e2 = new Expense(
                -150.00f,
                DateTime.Today.AddYears(5),
                "Safeway",
                new Card(),
                new HashSet<string> { "Food", "Hygene" },
                "bought groceries and deoderant");

            Expense e3 = new Expense(
                1000.00f,
                DateTime.Today.AddYears(-5),
                "GameStop",
                new DirectDeposit(),
                new HashSet<string> { "Pay" },
                "first paycheck from gamestop");

            this.dataAccessFactory.InsertRecord(e1);
            this.dataAccessFactory.InsertRecord(e2);
            this.dataAccessFactory.InsertRecord(e3);

            // case: only one expense is returned anyways
            ExpenseFilter f = new ExpenseFilter(
                name: "TestFilter",
                place: new HashSet<string> { "GameStop" });

            List<Expense> result = this.dataAccessFactory.FindAll(f);

            Assert.AreEqual(e3, result[0]);

            // case: nothing is returned
            f = new ExpenseFilter(
                name: "TestFilter",
                dateExact: DateTime.Today.AddDays(3));

            result = this.dataAccessFactory.FindAll(f);

            Assert.AreEqual(0, result.Count);

            // case: multiple are returned so we need to make sure they are ordered correctly.
            f = new ExpenseFilter(
                name: "TestFilter",
                keywords: new HashSet<string> { "groceries" });

            result = this.dataAccessFactory.FindAll(f);

            Assert.AreEqual(e1, result[0]);    // Since both e1 and e2 match they should be sorted ascendingly by id, since e1 was inserted first it should have a lower id and thus be selected over e2
            Assert.AreEqual(e2, result[1]);

            // Clean table of all entries for consecutive runs
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("DROP TABLE {0};", TABLENAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Tear down after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Here in Teardown!");
        }

        /// <summary>
        /// Clean up testing assets.
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Here in one time Teardown");
            File.Delete(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\myDatabase.db");
        }

        private string StringifyDataRow(SqliteDataReader res)
        {
            return $@"{res.GetInt32(0),-3} {res.GetDecimal(1),-8} {res.GetDateTime(2),8} {res.GetString(3),8} {res.GetString(4),20} {res.GetString(5),10} {res.GetInt32(6),3} {res.GetValue(7),3} {res.GetValue(8),22} {res.GetValue(8),22} {res.GetValue(9),6} {res.GetValue(10),10} {res.GetValue(11),5} {res.GetValue(12),3} {res.GetValue(13),10}";
        }

        /// <summary>
        /// Generate proper connection string for database connection.
        /// </summary>
        /// <returns>Properly formatted connection string.</returns>
        private string CreateConnectionString()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + this.testUser.DocumentName + ".db";
            builder.Password = "mypassword";

            return builder.ConnectionString;
        }
    }
}
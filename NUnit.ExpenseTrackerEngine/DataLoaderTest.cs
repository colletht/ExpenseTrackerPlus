// <copyright file="DataLoaderTest.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>


// TODO: Try encrypting data wiht passowrd - https://web.archive.org/web/20100207030625/http://sqlite.phxsoftware.com/forums/t/130.aspx
// research what encryption standard is used here
//https://www.sqlite.org/see/doc/release/www/readme.wiki
namespace NUnit.ExpenseTrackerEngineTest
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Runtime.CompilerServices;
    using System.Text;
    using System.Threading.Tasks;
    using ExpenseTrackerEngine;
    using NUnit.Framework;

    /// <summary>
    /// Class for exercising ExpenseTrackerEngine.DataLoaderTest.
    /// </summary>
    [TestFixture]
    public class DataLoaderTest
    {
        private const string dbName = "myDatabase";
        private const string tableName = "myTable";
        private DataAccessFactory dataAccessFactory;
        private SQLiteConnection db;

        /// <summary>
        /// Sets up testing assets.
        /// </summary>
        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            File.Delete("./myDatabase.db");
            Console.WriteLine("Here in one time Setup");
            this.dataAccessFactory = new DataAccessFactory(dbName, tableName);
            this.dataAccessFactory.CreateFile();
        }

        /// <summary>
        /// Local method setup.
        /// </summary>
        [SetUp]
        public void Setup()
        {
            Console.WriteLine("Here in Setup!");
            this.db = this.dataAccessFactory.CreateConnection();
        }

        /// <summary>
        /// Tests the create file function of DataLoader.
        /// </summary>
        [Test]
        public void CreateFileTest()
        {
            DataAccessFactory factory = new DataAccessFactory("testFile2", "myTable");
            File.Delete("./testFile2.db");

            Assert.That(factory.CreateFile(), Is.True);
            Assert.That(File.Exists("./testFile2.db"), Is.True);
            Assert.That(factory.CreateFile(), Is.False);

            File.Delete("./testFile2.db");
        }

        /// <summary>
        /// Tests the create connection function of the data loader under succesful inputs.
        /// </summary>
        [Test]
        public void CreateCloseConnectionSuccessTest()
        {
            DataAccessFactory factory = new DataAccessFactory("testFile1", "myTable");
            File.Delete("./testFile1.db");
            SQLiteConnection.CreateFile("./testFile1.db");

            // Use a seperate connection so we can use the other connection for testing the rest of the functions.
            SQLiteConnection conn = factory.CreateConnection();
            Assert.That(conn, Is.Not.Null);
            Assert.That(factory.CloseConnection(conn), Is.True);

            File.Delete("./testFile1.db");
        }

        /// <summary>
        /// Tests the create connection function of the data loader under fail inputs.
        /// </summary>
        [Test]
        public void CloseConnectionFailTest()
        {
            Assert.That(this.dataAccessFactory.CloseConnection(null), Is.False);
        }

        /// <summary>
        /// Tests that CreateNewExpenseTable creates a correct base table.
        /// </summary>
        [Test]
        public void CreateNewExpenseTableTest()
        {
            string[] COLUMNS = { "Id", "Value", "Date", "Place", "Tag", "Notes", "Type", "Debit", "Provider", "Number", "Name", "Currency", "Savings", "Bankname" };
            string[] TYPES = { "INTEGER", "DECIMAL", "DATETIME", "VARCHAR(50)", "VARCHAR(200)", "VARCHAR(200)", "INTEGER", "INTEGER", "VARCHAR(20)", "INTEGER", "VARCHAR(100)", "VARCHAR(20)", "INTEGER", "VARCHAR(50)" };
            int i = 0;

            this.db = this.dataAccessFactory.CreateConnection();
            this.dataAccessFactory.CreateNewExpenseTable(this.db);

            // verify columns created correctly
            SQLiteCommand cmd = this.db.CreateCommand();
            cmd.CommandText = string.Format("PRAGMA table_info({0});", tableName);
            SQLiteDataReader res = cmd.ExecuteReader();
            while (res.Read())
            {
                Console.WriteLine($"{res.GetString(1),-8} {res.GetString(2),-8}");
                Assert.That(
                    res.GetString(1),
                    Is.EqualTo(COLUMNS[i]),
                    string.Format("Row: {0}", i));  // check that column names are correct
                Assert.That(
                    res.GetString(2),
                    Is.EqualTo(TYPES[i]),
                    string.Format("Row: {0}", i));    // check that column types are correct
                ++i;
            }
        }

        /// <summary>
        /// Tests that CreateNewExpenseTable handles incorrect connections being passed.
        /// </summary>
        [Test]
        public void CreateNewExpenseTableNullTest()
        {
            Assert.Throws<Exception>(
                () => this.dataAccessFactory.CreateNewExpenseTable(null),
                "Does not throw on null connection");
        }

        /// <summary>
        /// Tests that insert record validly inserts data that is correct, into DB.
        /// </summary>
        [Test]
        public void InsertRecordTest()
        {
            try
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable(this.db);
            }
            catch
            {
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

            this.dataAccessFactory.InsertRecord(this.db, e);

            // verify columns created correctly
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT * FROM {0};", tableName);

                using (SQLiteDataReader res = cmd.ExecuteReader())
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
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("DROP TABLE {0};", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tests that UpdateRecord executes succesfully with 'correct' inputs.
        /// </summary>
        [Test]
        public void UpdateRecordTest()
        {
            try
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable(this.db);
            }
            catch
            {
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

            this.dataAccessFactory.InsertRecord(this.db, e);

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

            this.dataAccessFactory.UpdateRecord(this.db, e);

            // verify columns created correctly
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT * FROM {0};", tableName);

                using (SQLiteDataReader res = cmd.ExecuteReader())
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
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("DROP TABLE {0};", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tests that DeleteRecord executes succesfully with 'correct' inputs.
        /// </summary>
        [Test]
        public void DeleteRecordTest()
        {
            try
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable(this.db);
            }
            catch
            {
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

            this.dataAccessFactory.InsertRecord(this.db, e);

            // Now delete it
            this.dataAccessFactory.DeleteRecord(this.db, 1);

            // verify columns created correctly
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("SELECT count(*) FROM {0};", tableName);

                using (SQLiteDataReader res = cmd.ExecuteReader())
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
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("DROP TABLE {0};", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tests that find all executes succesfully.
        /// </summary>
        [Test]
        public void GetAllTest()
        {
            try
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable(this.db);
            }
            catch
            {
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

            this.dataAccessFactory.InsertRecord(this.db, e);
            this.dataAccessFactory.InsertRecord(this.db, e);
            this.dataAccessFactory.InsertRecord(this.db, e);

            List<Expense> expenses = this.dataAccessFactory.GetAll(this.db);

            Assert.AreEqual(3, expenses.Count);
            foreach (Expense expense in expenses)
            {
                Assert.AreEqual(e, expense);
            }

            // Clean table of all entries for consecutive runs
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("DROP TABLE {0};", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tests that FindOne functions properly.
        /// </summary>
        [Test]
        public void FindOneTest()
        {
            try
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable(this.db);
            }
            catch
            {
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

            this.dataAccessFactory.InsertRecord(this.db, e1);
            this.dataAccessFactory.InsertRecord(this.db, e2);
            this.dataAccessFactory.InsertRecord(this.db, e3);

            // case: only one expense is returned anyways
            ExpenseFilter f = new ExpenseFilter(
                place: new HashSet<string> { "GameStop" });

            Expense result = this.dataAccessFactory.FindOne(this.db, f);

            Assert.AreEqual(e3, result);

            // case: nothing is returned
            f = new ExpenseFilter(
                dateExact: DateTime.Today.AddDays(3));

            result = this.dataAccessFactory.FindOne(this.db, f);

            Assert.IsNull(result);

            // case: multiple are returned so we need to make sure they are ordered correctly.
            f = new ExpenseFilter(
                keywords: new HashSet<string> { "groceries" });

            result = this.dataAccessFactory.FindOne(this.db, f);

            Assert.AreEqual(e1, result);    // Since both e1 and e2 match they should be sorted ascendingly by id, since e1 was inserted first it should have a lower id and thus be selected over e2

            // Clean table of all entries for consecutive runs
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("DROP TABLE {0};", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tests functionality of FindAll.
        /// </summary>
        [Test]
        public void FindAllTest()
        {
            try
            {
                // Create Table if it has not been created yet
                this.dataAccessFactory.CreateNewExpenseTable(this.db);
            }
            catch
            {
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

            this.dataAccessFactory.InsertRecord(this.db, e1);
            this.dataAccessFactory.InsertRecord(this.db, e2);
            this.dataAccessFactory.InsertRecord(this.db, e3);

            // case: only one expense is returned anyways
            ExpenseFilter f = new ExpenseFilter(
                place: new HashSet<string> { "GameStop" });

            List<Expense> result = this.dataAccessFactory.FindAll(this.db, f);

            Assert.AreEqual(e3, result[0]);

            // case: nothing is returned
            f = new ExpenseFilter(
                dateExact: DateTime.Today.AddDays(3));

            result = this.dataAccessFactory.FindAll(this.db, f);

            Assert.AreEqual(0, result.Count);

            // case: multiple are returned so we need to make sure they are ordered correctly.
            f = new ExpenseFilter(
                keywords: new HashSet<string> { "groceries" });

            result = this.dataAccessFactory.FindAll(this.db, f);

            Assert.AreEqual(e1, result[0]);    // Since both e1 and e2 match they should be sorted ascendingly by id, since e1 was inserted first it should have a lower id and thus be selected over e2
            Assert.AreEqual(e2, result[1]);

            // Clean table of all entries for consecutive runs
            using (SQLiteCommand cmd = this.db.CreateCommand())
            {
                cmd.CommandText = string.Format("DROP TABLE {0};", tableName);
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Tear down after each test.
        /// </summary>
        [TearDown]
        public void TearDown()
        {
            Console.WriteLine("Here in Teardown!");
            this.dataAccessFactory.CloseConnection(this.db);
        }

        /// <summary>
        /// Clean up testing assets.
        /// </summary>
        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            Console.WriteLine("Here in one time Teardown");
            File.Delete("./myDatabase.db");
        }

        private string StringifyDataRow(SQLiteDataReader res)
        {
            return $@"{res.GetInt32(0),-3} {res.GetDecimal(1),-8} {res.GetDateTime(2),8} {res.GetString(3),8} {res.GetString(4),20} {res.GetString(5),10} {res.GetInt32(6),3} {res.GetValue(7),3} {res.GetValue(8),22} {res.GetValue(8),22} {res.GetValue(9),6} {res.GetValue(10),10} {res.GetValue(11),5} {res.GetValue(12),3} {res.GetValue(13),10}";
        }
    }
}
// <copyright file="DataAccessFactory.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

// TODO: Make whole thing static class.
namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.Data.SQLite;
    using System.IO;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Responsible for all data access actions of ExpenseTracker.
    /// </summary>
    internal class DataAccessFactory
    {
        private string filename;
        private string tablename;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessFactory"/> class.
        /// </summary>
        /// <param name="filename">Name of the database file to access.</param>
        /// <param name="tablename">Name of the table within the database file to access.</param>
        public DataAccessFactory(string filename, string tablename)
        {
            this.filename = filename;
            this.tablename = tablename;
        }

        /// <summary>
        /// Represents type of purchase.
        /// </summary>
        public enum EpurchaseMethod
        {
            CARD,
            CASH,
            DIRECT_DEPOSIT,
        }

        /// <summary>
        /// Creates a '.db' file with the given filename.
        /// </summary>
        /// <returns>True if succesfully created false otherwise.</returns>
        public bool CreateFile()
        {
            if (File.Exists("./" + this.filename + ".db"))
            {
                return false;
            }

            try
            {
                SQLiteConnection.CreateFile("./" + this.filename + ".db");
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return false;
            }
        }

        /// <summary>
        /// Establish connection to db specified by filename.
        /// </summary>
        /// <returns>Connection if it was established, null otherwise.</returns>
        public SQLiteConnection CreateConnection()
        {
            SQLiteConnection db = new SQLiteConnection(
                string.Format("Data Source=./{0}.db;Version={1};New={2};Compress={3};datetimeformat=CurrentCulture", this.filename, 3, "True", "True"));

            try
            {
                db.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
                return null;
            }

            return db;
        }

        /// <summary>
        /// Closes a connection to the db.
        /// </summary>
        /// <param name="db">The connection to the db that should be opeprated on.</param>
        /// <returns>True or false based on the success of the operation.</returns>
        public bool CloseConnection(SQLiteConnection db)
        {
            if (db == null)
            {
                return false;
            }

            db.Close();
            return true;
        }

        /// <summary>
        /// Create a new table in the users database for storing expenses.
        /// </summary>
        /// <param name="db">The connection to the db that should be opeprated on.</param>
        public void CreateNewExpenseTable(SQLiteConnection db)
        {
            if (db == null || db.State == System.Data.ConnectionState.Closed)
            {
                throw new Exception("Error: Connection must be open prior to calling this method.");
            }

            SQLiteCommand cmd;

            string cmdText = string.Format(
                "CREATE TABLE {0} (Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                    "Value DECIMAL, " +
                    "Date DATETIME, " +
                    "Place VARCHAR(50), " +
                    "Tag VARCHAR(200), " +
                    "Notes VARCHAR(200), " +
                    "Type INTEGER, " +
                    "Debit INTEGER, " +
                    "Provider VARCHAR(20), " +
                    "Number INTEGER, " +
                    "Name VARCHAR(100), " +
                    "Currency VARCHAR(20), " +
                    "Savings INTEGER, " +
                    "Bankname VARCHAR(50));",
                this.tablename);

            using (cmd = db.CreateCommand())
            {
                cmd.CommandText = cmdText;
                cmd.ExecuteNonQuery();
            }
        }

        /// <summary>
        /// Inserts the given expense into the given table.
        /// </summary>
        /// <param name="db">The connection to the db that should be opeprated on.</param>
        /// <param name="expense">The expense object to be placed in the table.</param>
        public void InsertRecord(SQLiteConnection db, Expense expense)
        {
            if (db == null || db.State == System.Data.ConnectionState.Closed)
            {
                throw new Exception("Error: Connection must be open prior to calling this method.");
            }

            if (expense.Id > -1)
            {
                throw new Exception("Error: expense does has valid Id and therefore should be updated with UpdateRecord()");
            }

            SQLiteCommand cmd;

            string cmdText = string.Format(
                "INSERT INTO {0} {1};",
                this.tablename,
                DataAccessFactory.ExpenseToSQL(expense));

            cmd = db.CreateCommand();
            cmd.CommandText = cmdText;
            Console.WriteLine(cmdText);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Updates a given expense in the table.
        /// </summary>
        /// <precondition>Expense must not have a null (-1) id. Must have an id corresponding to an id in the table.</precondition>
        /// <param name="db">The connection to the db that should be opeprated on.</param>
        /// <param name="expense">The expense object containing the record id and data to update.</param>
        /// <throws>Exception if expense does not contain a valid id.</throws>
        public void UpdateRecord(SQLiteConnection db, Expense expense)
        {
            if (db == null || db.State == System.Data.ConnectionState.Closed)
            {
                throw new Exception("Error: Connection must be open prior to calling this method.");
            }

            if (expense.Id < 0)
            {
                throw new Exception("Error: expense does not have a valid id");
            }

            SQLiteCommand cmd;

            string cmdText = string.Format(
                "REPLACE INTO {0} {1};",
                this.tablename,
                DataAccessFactory.ExpenseToSQL(expense));

            cmd = db.CreateCommand();
            cmd.CommandText = cmdText;
            Console.WriteLine(cmdText);
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Deletes a given expenses data from the table.
        /// </summary>
        /// <precondition>Expense must not have a null (-1) id. Must have an id corresponding to an id in the table.</precondition>
        /// <param name="db">The connection to the db that should be opeprated on.</param>
        /// <param name="id">The id of the expense to be deleted. Normally, obtained by first loading the expense from the database.</param>
        /// <throws>Exception if expense does not contain a valid id.</throws>
        public void DeleteRecord(SQLiteConnection db, int id)
        {

            if (db == null || db.State == System.Data.ConnectionState.Closed)
            {
                throw new Exception("Error: Connection must be open prior to calling this method.");
            }

            if (id < 0)
            {
                throw new Exception("Error: expense does not have a valid id");
            }

            SQLiteCommand cmd;

            string cmdText = string.Format(
                "DELETE FROM {0} WHERE Id = {1};",
                this.tablename,
                id);

            cmd = db.CreateCommand();
            cmd.CommandText = cmdText;
            cmd.ExecuteNonQuery();
        }

        /// <summary>
        /// Constructs SQL query format for expense in the form: '(cols) VALUES (vals)'. If the expense has a valid id that will also be included.
        /// </summary>
        /// <param name="expense">Expense object with populated fields.</param>
        /// <returns>String of the specified format.</returns>
        private static string ExpenseToSQL(Expense expense)
        {
            string purchaseMethodCols = string.Empty;
            string purchaseMethodVals = string.Empty;

            if (expense.Method is Cash)
            {
                // This is an undesireable solution - ideally would like a way for derived classes to provide this information themselves,
                // but we dont want that functionality available outside of the engine.
                Cash c = (Cash)expense.Method;
                purchaseMethodCols = "Type, Currency";
                purchaseMethodVals = string.Format("{0}, '{1}'", (int)EpurchaseMethod.CASH, c.Currency);
            }
            else if (expense.Method is Card)
            {
                Card c = (Card)expense.Method;
                purchaseMethodCols = "Type, Debit, Provider, Number, Name";
                purchaseMethodVals = string.Format("{0}, {1}, {2}, {3}, {4}", EpurchaseMethod.CARD, c.Debit ? 1 : 0, c.Provider, c.Number, c.Name);
            }
            else if (expense.Method is DirectDeposit)
            {
                DirectDeposit d = (DirectDeposit)expense.Method;
                purchaseMethodCols = "Type, Savings, Bankname, Number, Name";
                purchaseMethodVals = string.Format("{0}, {1}, {2}, {3}, {4}", EpurchaseMethod.DIRECT_DEPOSIT, d.Savings ? 1 : 0, d.BankName, d.Number, d.Name);
            }

            Console.WriteLine(expense.Date.Date.ToString());

            if (expense.Id > -1)
            {
                return string.Format(
                    "(Id, Value, Date, Place, Tag, Notes, {0}) " +
                        "VALUES ({1}, {2}, '{3}', '{4}', '{5}', '{6}', {7})",
                    purchaseMethodCols,
                    expense.Id,
                    expense.Value,
                    expense.Date.ToString(),
                    expense.Place,
                    string.Join(":", expense.Tag),
                    expense.Notes,
                    purchaseMethodVals);
            }
            else
            {
                return string.Format(
                    "(Value, Date, Place, Tag, Notes, {0}) " +
                        "VALUES ({1}, '{2}', '{3}', '{4}', '{5}', {6})",
                    purchaseMethodCols,
                    expense.Value,
                    expense.Date.ToString(),
                    expense.Place,
                    string.Join(":", expense.Tag),
                    expense.Notes,
                    purchaseMethodVals);
            }
        }
    }
}

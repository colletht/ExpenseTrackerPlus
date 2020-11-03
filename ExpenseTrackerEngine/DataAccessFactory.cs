// <copyright file="DataAccessFactory.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.Design;
    using System.IO;
    using System.Linq;
    using System.Runtime.InteropServices;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Data.Sqlite;

    /// <summary>
    /// Responsible for all data access actions of ExpenseTracker.
    /// </summary>
    internal class DataAccessFactory
    {
        private static readonly string EXPENSE_TABLE_NAME = "Expenses";
        private static readonly string FILTER_TABLE_NAME = "Filters";
        private User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="DataAccessFactory"/> class.
        /// </summary>
        /// <param name="user">User the object is responsible for.</param>
        public DataAccessFactory(User user)
        {
            this.user = user;
        }

        /// <summary>
        /// Represents type of purchase.
        /// </summary>
        public enum EpurchaseMethod
        {
            /// <summary>
            /// Represents a Card method.
            /// </summary>
            CARD = 1,

            /// <summary>
            /// Represents a Cash method.
            /// </summary>
            CASH,

            /// <summary>
            /// Represents a Direct Deposit method.
            /// </summary>
            DIRECT_DEPOSIT,
        }

        /// <summary>
        /// Gets a value indicating whether an expense table already exists in the users db.
        /// </summary>
        public bool ExpenseTableExists => this.TableExists(EXPENSE_TABLE_NAME);

        /// <summary>
        /// Gets a value indicating whether a filter table already exists in the users db.
        /// </summary>
        public bool FilterTableExists => this.TableExists(FILTER_TABLE_NAME);

        /// <summary>
        /// Create a new table in the users database for storing expenses.
        /// </summary>
        public void CreateNewExpenseTable()
        {
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                SqliteCommand cmd;

                using (cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format(
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
                        "Bankname VARCHAR(50));", DataAccessFactory.EXPENSE_TABLE_NAME);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Create a new table in the users database for storing filters.
        /// </summary>
        public void CreateNewFilterTable()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Inserts the given expense into the users expense table.
        /// </summary>
        /// <param name="expense">The expense object to be placed in the table.</param>
        public void InsertRecord(Expense expense)
        {
            if (expense.Id > -1)
            {
                throw new Exception("Error: expense does has valid Id and therefore should be updated with UpdateRecord()");
            }

            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    string cmdText = string.Format(
                        "INSERT INTO {0} ",
                        DataAccessFactory.EXPENSE_TABLE_NAME);

                    DataAccessFactory.PrepareColValueCommand(cmdText, cmd, expense);

                    Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Inserts the given filter into the users filter table.
        /// </summary>
        /// <param name="filter">The filter object to be placed in the table.</param>
        public void InsertFilter(ExpenseFilter filter)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Updates a given expense in the table.
        /// </summary>
        /// <precondition>Expense must not have a null (-1) id. Must have an id corresponding to an id in the table.</precondition>
        /// <param name="expense">The expense object containing the record id and data to update.</param>
        /// <throws>Exception if expense does not contain a valid id.</throws>
        public void UpdateRecord(Expense expense)
        {
            if (expense.Id < 0)
            {
                throw new Exception("Error: expense does not have a valid id");
            }

            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    string cmdText = string.Format(
                      "REPLACE INTO {0} ",
                      DataAccessFactory.EXPENSE_TABLE_NAME);

                    DataAccessFactory.PrepareColValueCommand(cmdText, cmd, expense);

                    Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a given expenses data from the table.
        /// </summary>
        /// <precondition>Expense must not have a null (-1) id. Must have an id corresponding to an id in the table.</precondition>
        /// <param name="id">The id of the expense to be deleted. Normally, obtained by first loading the expense from the database.</param>
        /// <throws>Exception if expense does not contain a valid id.</throws>
        public void DeleteRecord(int id)
        {
            if (id < 0)
            {
                throw new Exception("Error: expense does not have a valid id");
            }

            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    string cmdText = string.Format(
                       "DELETE FROM {0} WHERE Id = @id;",
                       DataAccessFactory.EXPENSE_TABLE_NAME);

                    cmd.Parameters.Add(new SqliteParameter("@id", id));
                    cmd.CommandText = cmdText;
                    cmd.Prepare();

                    Console.WriteLine(cmd.CommandText);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Deletes a given filters data from the table.
        /// </summary>
        /// <param name="name">The name of the expense to be deleted.</param>
        public void DeleteFilter(string name)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Returns all expenses present within the table in the database.
        /// </summary>
        /// <returns>List{expense} of all expenses retrieved.</returns>
        public List<Expense> GetAll()
        {
            List<Expense> expenses = new List<Expense>();

            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    string cmdText = string.Format(
                          "SELECT * FROM {0}",
                          DataAccessFactory.EXPENSE_TABLE_NAME);

                    cmd.CommandText = cmdText;

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            expenses.Add(DataAccessFactory.FromRow(rdr));
                        }
                    }
                }
            }

            return expenses;
        }

        /// <summary>
        /// Returns all the filters present within the database.
        /// </summary>
        /// <returns>List{ExpenseFilter} of all filters retrieved.</returns>
        public List<ExpenseFilter> GetAllFilters()
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Finds the first expense in the database that matches the filter.
        /// </summary>
        /// <param name="filter">Filter to select expenses by.</param>
        /// <returns>The first expense that matches the filter, otherwise null.</returns>
        public Expense FindOne(ExpenseFilter filter)
        {
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    string cmdText = string.Format(
                          "SELECT * FROM {0} WHERE ",
                          DataAccessFactory.EXPENSE_TABLE_NAME);

                    DataAccessFactory.PrepareFilterConstraintCommand(cmdText, cmd, filter);
                    Console.WriteLine(cmd.CommandText);

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return DataAccessFactory.FromRow(rdr);
                        }
                        else
                        {
                            return null;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Finds and returns all expenses in the database that match the given filter.
        /// </summary>
        /// <param name="filter">Filter to select expenses by.</param>
        /// <returns>All expenses that match the filter, empty list if none are found.</returns>
        public List<Expense> FindAll(ExpenseFilter filter)
        {
            List<Expense> expenses = new List<Expense>();

            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    string cmdText = string.Format(
                        "SELECT * FROM {0} WHERE ",
                        DataAccessFactory.EXPENSE_TABLE_NAME);

                    DataAccessFactory.PrepareFilterConstraintCommand(cmdText, cmd, filter);

                    Console.WriteLine(cmd.CommandText);

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            Expense e = DataAccessFactory.FromRow(rdr);

                            Console.WriteLine(e);
                            expenses.Add(e);
                        }
                    }
                }
            }

            return expenses;
        }

        /// <summary>
        /// Constructs SQL query format for expense in the form: '(cols) VALUES (vals)'. If the expense has a valid id that will also be included.
        /// The command is constructed so that it is parameterized. Defending from SQLInjection attacks.
        /// </summary>
        /// <param name="prefix">The command to perform such as 'INSERT INTO tablename '.</param>
        /// <param name="cmd">The command to populate with parameters and command text.</param>
        /// <param name="expense">Expense object with populated fields.</param>
        private static void PrepareColValueCommand(string prefix, SqliteCommand cmd, Expense expense)
        {
            string cols = string.Empty;
            string vals = string.Empty;

            if (expense.Id > -1)
            {
                cols += "(Id, Value, Date, Place, Tag, Notes, ";
                vals += "VALUES (@id, @value, @date, @place, @tag, @notes, ";
                cmd.Parameters.Add(new SqliteParameter("@id", expense.Id));
                cmd.Parameters.Add(new SqliteParameter("@value", expense.Value));
                cmd.Parameters.Add(new SqliteParameter("@date", expense.Date));
                cmd.Parameters.Add(new SqliteParameter("@place", expense.Place));
                cmd.Parameters.Add(new SqliteParameter("@tag", string.Join(":", expense.Tag)));
                cmd.Parameters.Add(new SqliteParameter("@notes", expense.Notes));
            }
            else
            {
                cols += "(Value, Date, Place, Tag, Notes, ";
                vals += "VALUES (@value, @date, @place, @tag, @notes, ";
                cmd.Parameters.Add(new SqliteParameter("@value", expense.Value));
                cmd.Parameters.Add(new SqliteParameter("@date", expense.Date));
                cmd.Parameters.Add(new SqliteParameter("@place", expense.Place));
                cmd.Parameters.Add(new SqliteParameter("@tag", string.Join(":", expense.Tag)));
                cmd.Parameters.Add(new SqliteParameter("@notes", expense.Notes));
            }

            if (expense.Method is Cash)
            {
                // This is an undesireable solution - ideally would like a way for derived classes to provide this information themselves,
                // but we dont want that functionality available outside of the engine.
                Cash c = (Cash)expense.Method;
                cols += "Type, Currency) ";
                vals += "@type, @currency);";
                cmd.Parameters.Add(new SqliteParameter("@type", (int)EpurchaseMethod.CASH));
                cmd.Parameters.Add(new SqliteParameter("@currency", c.Currency));
            }
            else if (expense.Method is Card)
            {
                Card c = (Card)expense.Method;
                cols += "Type, Debit, Provider, Number, Name) ";
                vals += "@type, @debit, @provider, @number, @name);";
                cmd.Parameters.Add(new SqliteParameter("@type", (int)EpurchaseMethod.CARD));
                cmd.Parameters.Add(new SqliteParameter("@debit", c.Debit));
                cmd.Parameters.Add(new SqliteParameter("@provider", c.Provider));
                cmd.Parameters.Add(new SqliteParameter("@number", c.Number));
                cmd.Parameters.Add(new SqliteParameter("@name", c.Name));
            }
            else if (expense.Method is DirectDeposit)
            {
                DirectDeposit d = (DirectDeposit)expense.Method;
                cols += "Type, Savings, Bankname, Number, Name) ";
                vals += "@type, @savings, @bankname, @number, @name);";
                cmd.Parameters.Add(new SqliteParameter("@type", (int)EpurchaseMethod.DIRECT_DEPOSIT));
                cmd.Parameters.Add(new SqliteParameter("@savings", d.Savings));
                cmd.Parameters.Add(new SqliteParameter("@bankname", d.BankName));
                cmd.Parameters.Add(new SqliteParameter("@number", d.Number));
                cmd.Parameters.Add(new SqliteParameter("@name", d.Name));
            }

            cmd.CommandText = prefix + cols + vals;
            cmd.Prepare();
        }

        /// <summary>
        /// Summarizes the ExpenseFilters set of expenses in SQL, that can be easily added to a where clause.
        /// </summary>
        private static void PrepareFilterConstraintCommand(string prefix, SqliteCommand cmd, ExpenseFilter filter)
        {
            // TODO: TEST THIS
            string outstring = string.Empty;

            // add date clause
            outstring += "(Date BETWEEN @mindate AND @maxdate) AND ";
            cmd.Parameters.Add(new SqliteParameter("@mindate", filter.MinDate));
            cmd.Parameters.Add(new SqliteParameter("@maxdate", filter.MaxDate));

            // handle value clause
            outstring += "(Value BETWEEN @minvalue AND @maxvalue)";
            cmd.Parameters.Add(new SqliteParameter("@minvalue", filter.MinValue));
            cmd.Parameters.Add(new SqliteParameter("@maxvalue", filter.MaxValue));

            // handle place clause
            if (filter.Place.Count > 0)
            {
                int i = 0;
                outstring += " AND (Place IN (";
                foreach (var place in filter.Place)
                {
                    outstring += "@place" + i;
                    outstring += (filter.Place.Count - 1 == i) ? string.Empty : ", ";
                    cmd.Parameters.Add(new SqliteParameter("@place" + i, place));
                    ++i;
                }

                outstring += "))";
            }

            // handle tag clause
            if (filter.Tag.Count > 0)
            {
                int i = 0;
                outstring += " AND (";
                foreach (var tag in filter.Tag)
                {
                    outstring += "(Tag LIKE @tag" + i + ")";
                    outstring += (filter.Tag.Count - 1 == i) ? string.Empty : " OR ";
                    cmd.Parameters.Add(new SqliteParameter("@tag" + i, "%" + tag + "%"));
                    ++i;
                }

                outstring += ")";
            }

            // handle keyword clause
            if (filter.Keywords.Count > 0)
            {
                int i = 0;
                outstring += " AND (";
                foreach (var word in filter.Keywords)
                {
                    outstring += "(Notes LIKE @word" + i + ")";
                    outstring += (filter.Keywords.Count - 1 == i) ? string.Empty : " OR ";
                    cmd.Parameters.Add(new SqliteParameter("@word" + i, "%" + word + "%"));
                    ++i;
                }

                outstring += ")";
            }

            // prepare purchasemethod args
            if (filter.Method != null)
            {
                if (filter.Method is Cash)
                {
                    // This is an undesireable solution - ideally would like a way for derived classes to provide this information themselves,
                    // but we dont want that functionality available outside of the engine.
                    Cash c = (Cash)filter.Method;
                    outstring += " AND (Type = @type) AND (Currency = @currency)";
                    cmd.Parameters.Add(new SqliteParameter("@type", (int)EpurchaseMethod.CASH));
                    cmd.Parameters.Add(new SqliteParameter("@currency", c.Currency));
                }
                else if (filter.Method is Card)
                {
                    Card c = (Card)filter.Method;
                    outstring += " AND (Type = @type) AND (Debit = @debit) AND (Provider = @provider) AND (Number = @number) AND (Name = @name)";
                    cmd.Parameters.Add(new SqliteParameter("@type", (int)EpurchaseMethod.CARD));
                    cmd.Parameters.Add(new SqliteParameter("@debit", c.Debit));
                    cmd.Parameters.Add(new SqliteParameter("@provider", c.Provider));
                    cmd.Parameters.Add(new SqliteParameter("@number", c.Number));
                    cmd.Parameters.Add(new SqliteParameter("@name", c.Name));
                }
                else if (filter.Method is DirectDeposit)
                {
                    DirectDeposit d = (DirectDeposit)filter.Method;
                    outstring += " AND (Type = @type) AND (Savings = @savings) AND (Bankname = @bankname) AND (Number = @number) AND (Name = @name)";
                    cmd.Parameters.Add(new SqliteParameter("@type", (int)EpurchaseMethod.DIRECT_DEPOSIT));
                    cmd.Parameters.Add(new SqliteParameter("@savings", d.Savings));
                    cmd.Parameters.Add(new SqliteParameter("@bankname", d.BankName));
                    cmd.Parameters.Add(new SqliteParameter("@number", d.Number));
                    cmd.Parameters.Add(new SqliteParameter("@name", d.Name));
                }
            }

            outstring += " ORDER BY Id ASC;";

            cmd.CommandText = prefix + outstring;
            cmd.Prepare();
        }

        /// <summary>
        /// Retrieves an expense given the row it is represented by in SQL.
        /// </summary>
        /// <param name="rdr">The row the expense is contained within.</param>
        /// <returns>an expense object.</returns>
        private static Expense FromRow(SqliteDataReader rdr)
        {
            Console.WriteLine(rdr);

            Expense e = new Expense(
                rdr.GetInt32(0),                                    // Id
                (float)rdr.GetDecimal(1),                           // Value
                rdr.GetDateTime(2),                                 // Date
                rdr.GetString(3),                                   // Place
                null,                                               // PurchaseMethod (fill in below)
                new HashSet<string>(rdr.GetString(4).Split(':')),   // Tags
                rdr.GetString(5));                                  // Notes

            // Purchase Method
            switch ((DataAccessFactory.EpurchaseMethod)rdr.GetInt32(6))
            {
                case EpurchaseMethod.CASH:
                    e.Method = new Cash(
                        rdr.GetString(11));                         // Currency
                    break;
                case EpurchaseMethod.CARD:
                    e.Method = new Card(
                        rdr.GetBoolean(7),                          // Debit
                        rdr.GetString(8),                           // Provider
                        rdr.GetInt32(9),                            // Number
                        rdr.GetString(10));                         // Name
                    break;
                case EpurchaseMethod.DIRECT_DEPOSIT:
                    e.Method = new DirectDeposit(
                        rdr.GetBoolean(12),                         // Savings
                        rdr.GetString(13),                          // Bankname
                        rdr.GetInt32(9),                            // Number
                        rdr.GetString(10));                         // Name
                    break;
                default:
                    throw new NotSupportedException(string.Format("Error: Unsupported type specified for purchase method. Was {0}", rdr.GetInt32(6)));
            }

            return e;
        }

        /// <summary>
        /// Generate proper connection string for database connection.
        /// </summary>
        /// <returns>Properly formatted connection string.</returns>
        private string CreateConnectionString()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = "./" + this.user.DocumentName + ".db";
            builder.Password = "mypassword";

            return builder.ConnectionString;
        }

        /// <summary>
        /// Checks if the table with the given name exists in the database.
        /// </summary>
        /// <param name="tablename">Name of the table to check for.</param>
        /// <returns>True if the table exists false otherwise.</returns>
        private bool TableExists(string tablename)
        {
            using (SqliteConnection db = new SqliteConnection(this.CreateConnectionString()))
            {
                db.Open();
                SqliteCommand cmd;

                using (cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format(
                        "SELECT COUNT() FROM sqlite_master WHERE type = 'table' AND name = '{0}'; ",
                        tablename);

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        rdr.Read();
                        return rdr.GetInt32(0) == 1;
                    }
                }
            }
        }
    }
}

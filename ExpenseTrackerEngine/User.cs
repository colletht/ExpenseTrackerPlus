// <copyright file="User.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Reflection;
    using System.Text;
    using System.Threading.Tasks;
    using Microsoft.Data.Sqlite;

    /// <summary>
    /// Represents a user of the system.
    /// </summary>
    internal class User
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="User"/> class. This constructor can only be invoked by static members of this class.
        /// </summary>
        /// <param name="username">The username of the user.</param>
        /// <param name="password">The hashed and salted password of the user.</param>
        /// <param name="secretKey">The secret key of the user.</param>
        /// <param name="documentName">The name of the document in which the users data is stored.</param>
        /// <param name="salt">The salt used when hashing the password.</param>
        internal User(string username, string password, string secretKey, string documentName, string salt)
        {
            this.Username = username;
            this.PasswordHash = password;
            this.SecretKey = secretKey;
            this.DocumentName = documentName;
            this.Salt = salt;
        }

        /// <summary>
        /// Specifies which fields to change in the database when calling ModifyExisingUser.
        /// </summary>
        public enum EFieldToModify
        {
            /// <summary>
            /// Indicates the username field should be modified.
            /// </summary>
            USERNAME,

            /// <summary>
            /// Indicates the password field should be modified.
            /// </summary>
            PASSWORD,
        }

        /// <summary>
        /// Gets the document name of the given user.
        /// </summary>
        internal string DocumentName
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the username of the user.
        /// </summary>
        internal string Username
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the users secret key.
        /// </summary>
        internal string SecretKey
        {
            get;
            private set;
        }

        private static string MetaDataFileName
        {
            get
            {
                return "ExpenseTrackerMetaData";
            }
        }

        private static string UserTableName
        {
            get
            {
                return "Users";
            }
        }

        private static bool UserTableExists => TableExists(UserTableName);

        /// <summary>
        /// Gets or Sets the password of the user (salted and hashed).
        /// </summary>
        private string PasswordHash
        {
            get;
            set;
        }

        /// <summary>
        /// Gets or Sets the salt of the given user.
        /// </summary>
        private string Salt
        {
            get;
            set;
        }

        /// <summary>
        /// Creates a new user based off information passed. Throws an error if the provided username is already in use on the machine.
        /// </summary>
        /// <param name="username">Username of new user.</param>
        /// <param name="password">Password of new user, plaintext, will be hashed and salted here.</param>
        /// <returns>New <see cref="User"/> object representing user now existing in DB.</returns>
        public static User CreateNewUser(string username, string password)
        {
            string documentName = "ExpenseTracker" + username;
            string salt = PasswordUtility.GenerateSalt(password.Length);
            string secret = PasswordUtility.GenerateSecret();
            string hashedPassword = PasswordUtility.HashPassword(PasswordUtility.SaltPassword(password, salt));

            string connString = CreateConnectionString();

            if (!UserTableExists)
            {
                CreateUserTable();
            }

            using (SqliteConnection db = new SqliteConnection(connString))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("INSERT INTO {0} (Username, Password, Secret, Document, Salt) VALUES (@username, @password, @secret, @document, @salt);", UserTableName);

                    cmd.Parameters.Add(new SqliteParameter("@username", username));
                    cmd.Parameters.Add(new SqliteParameter("@password", hashedPassword));
                    cmd.Parameters.Add(new SqliteParameter("@secret", secret));
                    cmd.Parameters.Add(new SqliteParameter("@document", documentName));
                    cmd.Parameters.Add(new SqliteParameter("@salt", salt));

                    cmd.Prepare();

                    cmd.ExecuteNonQuery();
                }
            }

            return new User(username, hashedPassword, secret, documentName, salt);
        }

        /// <summary>
        /// Load existing user from the database. Throws if the user is not found.
        /// </summary>
        /// <param name="username">Username to search for.</param>
        /// <returns>New <see cref="User"/> object representing user now existing in DB.</returns>
        public static User LoadExistingUser(string username)
        {
            string connString = CreateConnectionString();

            if (!UserTableExists)
            {
                CreateUserTable();
            }

            using (SqliteConnection db = new SqliteConnection(connString))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT * FROM {0} WHERE (Username = @username);", UserTableName);

                    cmd.Parameters.Add(new SqliteParameter("@username", username));

                    cmd.Prepare();

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return new User(username, rdr.GetString(2), rdr.GetString(3), rdr.GetString(4), rdr.GetString(5));
                        }
                        else
                        {
                            throw new KeyNotFoundException("Specified User does not exist, try creating an account first.");
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Checks if a user with the given username exists within the database.
        /// </summary>
        /// <param name="username">The username to check if it exists.</param>
        /// <returns>True if the username exists, false otherwise.</returns>
        public static bool UserExists(string username)
        {
            string connString = CreateConnectionString();

            if (!UserTableExists)
            {
                CreateUserTable();
            }

            using (SqliteConnection db = new SqliteConnection(connString))
            {
                db.Open();
                using (SqliteCommand cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format("SELECT COUNT() FROM {0} WHERE (Username = @username);", UserTableName);

                    cmd.Parameters.Add(new SqliteParameter("@username", username));

                    cmd.Prepare();

                    using (SqliteDataReader rdr = cmd.ExecuteReader())
                    {
                        if (rdr.Read())
                        {
                            return rdr.GetInt32(0) >= 1;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Returns true if the credentials passed match the user.
        /// </summary>
        /// <param name="username">username of the user.</param>
        /// <param name="password">password of the user in plaintext, will be salted and hashed here.</param>
        /// <returns>True if the user does indeed match these credentials, false otherwise.</returns>
        public bool VerifyUser(string username, string password)
        {
            return username.Equals(this.Username) && PasswordUtility.VerifyPassword(this.PasswordHash, password, this.Salt);
        }

        /// <summary>
        /// Generate proper connection string for database connection.
        /// </summary>
        /// <returns>Properly formatted connection string.</returns>
        private static string CreateConnectionString()
        {
            SqliteConnectionStringBuilder builder = new SqliteConnectionStringBuilder();
            builder.DataSource = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location) + "\\" + MetaDataFileName + ".db";
            builder.Password = "mypassword";
            builder.Mode = SqliteOpenMode.ReadWriteCreate;

            return builder.ConnectionString;
        }

        /// <summary>
        /// Checks if the table with the given name exists in the database.
        /// </summary>
        /// <param name="tablename">Name of the table to check for.</param>
        /// <returns>True if the table exists false otherwise.</returns>
        private static bool TableExists(string tablename)
        {
            using (SqliteConnection db = new SqliteConnection(CreateConnectionString()))
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

        /// <summary>
        /// Create the user table.
        /// </summary>
        private static void CreateUserTable()
        {
            using (SqliteConnection db = new SqliteConnection(CreateConnectionString()))
            {
                db.Open();
                SqliteCommand cmd;

                using (cmd = db.CreateCommand())
                {
                    cmd.CommandText = string.Format(
                        "CREATE TABLE {0} (Id INTEGER PRIMARY KEY AUTOINCREMENT, " +
                        "Username VARCHAR(50), " +
                        "Password VARCHAR(200), " +
                        "Secret VARCHAR(50), " +
                        "Document VARCHAR(200), " +
                        "Salt VARCHAR(50)); ", UserTableName);
                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}

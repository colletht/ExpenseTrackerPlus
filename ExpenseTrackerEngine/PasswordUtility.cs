// <copyright file="PasswordUtility.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Helpers;

    /// <summary>
    /// Responsible for password utility operations, hashing, salt generation, secret generation, etc.
    /// </summary>
    internal static class PasswordUtility
    {
        /// <summary>
        /// Generates a salt of the given length.
        /// </summary>
        /// <param name="byteLength">The length in bytes the given salt should be.</param>
        /// <returns>The salt generated.</returns>
        public static string GenerateSalt(int byteLength = 32)
        {
            return Crypto.GenerateSalt(byteLength);
        }

        /// <summary>
        /// Salts a plaintext password with the provided salt.
        /// </summary>
        /// <param name="password">Password in plaintext to be salted.</param>
        /// <param name="salt">Salt to be applied to the plaintext password.</param>
        /// <returns>The salted password.</returns>
        public static string SaltPassword(string password, string salt)
        {
            return string.Concat(password, salt);
        }

        /// <summary>
        /// Hashes a password string passed to the function using System.Web.Helpers.Crypto.HashPassword().
        /// </summary>
        /// <param name="password">The password to be hashed.</param>
        /// <returns>The hashed password.</returns>
        public static string HashPassword(string password)
        {
            return Crypto.HashPassword(password);
        }

        /// <summary>
        /// Generates a secret key of length byteLength.
        /// </summary>
        /// <param name="byteLength">Length in bytes of the secret generated.</param>
        /// <returns>The secret key generated.</returns>
        public static string GenerateSecret(int byteLength = 32)
        {
            RandomNumberGenerator cryptoRandomDataGenerator = new RNGCryptoServiceProvider();
            byte[] buffer = new byte[byteLength];
            cryptoRandomDataGenerator.GetBytes(buffer);
            string uniq = Convert.ToBase64String(buffer);
            return uniq;
        }

        /// <summary>
        /// Verifies that the plaintext password and provided salt match the given hash.
        /// </summary>
        /// <param name="hash">The hash to compare against.</param>
        /// <param name="plaintext">The plaintext password to check.</param>
        /// <param name="salt">the salt to use when comparing the two passwords.</param>
        /// <returns>True if the plaintext+salt combination is a match.</returns>
        public static bool VerifyPassword(string hash, string plaintext, string salt)
        {
            return Crypto.VerifyHashedPassword(hash, SaltPassword(plaintext, salt));
        }
    }
}

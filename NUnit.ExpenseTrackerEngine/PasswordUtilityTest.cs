// <copyright file="PasswordUtilityTest.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace NUnit.ExpenseTrackerEngineTest
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using ExpenseTrackerEngine;
    using NUnit.Framework;

    /// <summary>
    /// Responsible for testing functions of PasswordUtility.
    /// </summary>
    [TestFixture]
    public class PasswordUtilityTest
    {
        /// <summary>
        /// Tests salt password.
        /// </summary>
        [Test]
        public void SaltPasswordTest()
        {
            string salt = PasswordUtility.GenerateSalt(32);
            string password = "mypassword";

            Assert.That(PasswordUtility.SaltPassword(password, salt), Is.EqualTo(string.Concat(password, salt)));
        }

        /// <summary>
        /// Tests VerifyPassword.
        /// </summary>
        [Test]
        public void VerifyPasswordTest()
        {
            string password = "mypassword";
            string salt = PasswordUtility.GenerateSalt(password.Length);
            string hashPassword = PasswordUtility.HashPassword(PasswordUtility.SaltPassword(password, salt));

            Assert.That(PasswordUtility.VerifyPassword(hashPassword, password, salt), Is.True);

            Assert.That(PasswordUtility.VerifyPassword(hashPassword, "notmypassword", salt), Is.False);
        }
    }
}

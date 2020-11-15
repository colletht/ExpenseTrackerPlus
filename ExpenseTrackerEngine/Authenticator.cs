// <copyright file="Authenticator.cs" company="Harrison Collet">
// Copyright (c) Harrison Collet. All rights reserved.
// </copyright>

namespace ExpenseTrackerEngine
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Google.Authenticator;

    /// <summary>
    /// Class responsible for authenticating users, this includes 2FA and logging users in.
    /// </summary>
    public class Authenticator
    {
        private TwoFactorAuthenticator tfa;
        private User user;

        /// <summary>
        /// Initializes a new instance of the <see cref="Authenticator"/> class.
        /// </summary>
        public Authenticator()
        {
            this.QRCodeImageURL = null;
        }

        /// <summary>
        /// Gets the Setup QR code for google authenticator if SetUpGoogleAuthenticator has been called.
        /// </summary>
        public byte[] QRCodeImageURL
        {
            get;
            private set;
        }

        /// <summary>
        /// Gets the user authorized by the authenticator.
        /// </summary>
        internal User AuthorizedUser
        {
            get;
            private set;
        }

        /// <summary>
        /// Responsible for setting up a new user.
        /// </summary>
        /// <param name="username">Username of new user.</param>
        /// <param name="password">Password of new user, plaintext.</param>
        public void SetUpNewUser(string username, string password)
        {
            if (User.UserExists(username))
            {
                throw new DuplicateNameException("It looks like that username is already taken!");
            }

            this.user = User.CreateNewUser(username, password);
        }

        /// <summary>
        /// Provide information for setting up google authenticator, if the user is new.
        /// </summary>
        /// <returns>String representing the manual setup key users must enter into google authenticator.</returns>
        public string SetUpGoogleAuthenticator()
        {
            this.tfa = new TwoFactorAuthenticator();
            SetupCode setupInfo = this.tfa.GenerateSetupCode("ExpenseTrackerPlus", this.user.Username, this.user.SecretKey, false, 3);

            this.QRCodeImageURL = Convert.FromBase64String(setupInfo.QrCodeSetupImageUrl.Substring(22));
            return setupInfo.ManualEntryKey;
        }

        /// <summary>
        /// Authenticate a user based off their username and password. Returns true if a user
        /// can be succesfully authenticated, that is, a user is found with the given username
        /// and password in the database.
        /// </summary>
        /// <param name="username">The username we are trying to authenticate.</param>
        /// <param name="password">The password we are trying to authenticate, plaintext.</param>
        /// <returns>True if a user is found in the database that matches these fields.</returns>
        public bool AuthenticatePassword(string username, string password)
        {
            if (User.UserExists(username))
            {
                this.user = User.LoadExistingUser(username);
                return this.user.VerifyUser(username, password);
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Authorizes a user using google authenticator, returns true and populates AuthorizedUser if succesful
        /// returns false otherwise. Throws InvalidOperationException if called before AuthenticatePassword is called succesfully.
        /// </summary>
        /// <param name="code">The PIN recieved from the Goolge Authenticator app.</param>
        /// <returns>True and populates AuthorizedUser if Succesful.</returns>
        public bool AuthenticateGoogleAuthenticator(string code)
        {
            if (this.user == null)
            {
                throw new InvalidOperationException("Must have called AuthenticatePassword() with a true return before invoking this function.");
            }

            if (this.tfa.ValidateTwoFactorPIN(this.user.SecretKey, code))
            {
                this.AuthorizedUser = this.user;
                return true;
            }
            else
            {
                return false;
            }
        }

        /// <summary>
        /// Creates a new <see cref="ExpenseController"/> for use.
        /// This method throws an error if the use has not been authorized
        /// i.e. <see cref="AuthenticateGoogleAuthenticator(string)"/> must
        /// be called with a true return value to execute this function.
        /// </summary>
        /// <returns>A new ExpenseController controlling the authenticated users credentials.</returns>
        public ExpenseController CreateExpenseController()
        {
            if (this.AuthorizedUser == null)
            {
                throw new InvalidOperationException("Must have called AuthenticateGoogleAuthenticator() with a true return before invoking this function.");
            }

            return new ExpenseController(this.AuthorizedUser);
        }
    }
}

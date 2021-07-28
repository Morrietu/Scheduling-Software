using System;
using System.Windows.Forms;
using System.Globalization;
using System.IO;

namespace Scheduling_Software
{
    /// <summary>
    /// Code behind for the Login form.
    /// </summary>
    public partial class Login : Form
    {
        #region Global variables
        // Declarations for error messages
        public string noInfo = "Fields cannot be left blank.";
        public string wrongInfo = "Invalid username or password.";
        // Stores the username used for login
        string userName;
        // Stores the time that a user logs in to the application
        DateTime userLogin;
        #endregion

        #region Form Constructor
        /// <summary>
        /// Initializes form component.
        /// </summary>
        public Login()
        {
            InitializeComponent();
            // Use of statment lamba to prevent need of individual function to change language
            Action<string> AlternateLanguage = language =>
            {
                if (language == "de-DE" || language == "en-DE")
                {
                    loginLabel.Text = "Anmeldung";
                    submitButton.Text = "Einreichen";
                    exitButton.Text = "Ausfahrt";
                    noInfo = "Bitte geben Sie die Anmeldeinformationen ein.";
                    wrongInfo = "Der Benutzername und das Passwort stimmten nicht überein.";
                }
            };
            AlternateLanguage(CultureInfo.CurrentCulture.Name);
        }
        #endregion
        
        #region Event Handlers
        /// <summary>
        /// Closes application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        /// <summary>
        /// Grants user access to main form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void submitButton_Click(object sender, EventArgs e)
        {
            // Checks for user input
            if (usernameTextBox.Text.Length != 0 || passwordTextBox.Text.Length != 0)
            {
                //Connects to the SQL database
                DBHelper conn = new DBHelper();
                if (conn.UserLogin(usernameTextBox.Text, passwordTextBox.Text))
                {
                    // Stores the user name
                    userName = usernameTextBox.Text;
                    // Stores the login time
                    userLogin = DateTime.Now.ToLocalTime();
                    // Creates a file stream to  append timstamps to an existing text file
                    try
                    {
                        using (StreamWriter writetext = new StreamWriter("LoginLog.txt", append:true))
                        {
                            writetext.WriteLine($"Successful login by {userName} at {userLogin.ToString()}");
                        }
                    }
                    // Displays error message, should one occur
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    // Hides login form
                    this.Hide();
                    // Creates new object of Main class
                    Main mainForm = new Main();
                    // Shows main form object
                    mainForm.Show();
                }
                else
                {
                    // Stores the user name
                    userName = usernameTextBox.Text;
                    // Stores the login time
                    userLogin = DateTime.Now.ToLocalTime();
                    // Creates a file stream to  append timstamps to an existing text file
                    try
                    {
                        using (StreamWriter writetext = new StreamWriter("LoginLog.txt", append: true))
                        {
                            writetext.WriteLine($"Unsuccessful login by {userName} at {userLogin.ToString()}");
                        }
                    }
                    // Displays error message, should one occur
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.ToString());
                    }
                    MessageBox.Show(wrongInfo);
                }
            }
            // Notifies user that no information was entered.
            else
            {
                // Stores the login time
                userLogin = DateTime.Now.ToLocalTime();
                // Creates a file stream to  append timstamps to an existing text file
                try
                {
                    using (StreamWriter writetext = new StreamWriter("LoginLog.txt", append: true))
                    {
                        writetext.WriteLine($"Unsuccessful blank login at {userLogin.ToString()}");
                    }
                }
                // Displays error message, should one occur
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                MessageBox.Show(noInfo);
            }
        }
        #endregion
    }
}

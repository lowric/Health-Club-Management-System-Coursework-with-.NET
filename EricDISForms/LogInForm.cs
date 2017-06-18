using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.Remoting;
using EricDISLibrary;


namespace EricDISForms
{
    public partial class LogInForm : Form
    {
        EricRemoteLogin myRemoteLogin = new EricRemoteLogin();
        EricDAO myDAO = new EricDAO();
        public LogInForm()
        {
            InitializeComponent();
           /* RemotingConfiguration.RegisterWellKnownClientType(
                              typeof(EricRemoteStaff),
                              "tcp://127.0.0.1:12000/EricRemoteStaffService");*/
            RemotingConfiguration.RegisterWellKnownClientType(
                              typeof(EricRemoteLocalManager),
                              "tcp://127.0.0.1:12000/EricRemoteLocalManagerService");
            RemotingConfiguration.RegisterWellKnownClientType(
                              typeof(EricRemoteNationalManager),
                              "tcp://127.0.0.1:12000/EricRemoteNationalManagerService");
            RemotingConfiguration.RegisterWellKnownClientType(
                              typeof(EricRemoteLogin),
                              "tcp://127.0.0.1:12000/EricRemoteLoginService");
            /*RemotingConfiguration.RegisterWellKnownClientType(
                              typeof(EricRemotePrincipal),
                              "tcp://127.0.0.1:12000/EricRemotePrincipalService");
            RemotingConfiguration.RegisterWellKnownClientType(
                              typeof(EricRemoteRegistrar),
                              "tcp://127.0.0.1:12000/EricRemoteRegistrarService");*/
        }

        // Checks if the the login fields are empty
        private bool emptyField()
        {
            if (userNameTextBox.Text.Trim().Equals("") ||
                (passwordTextBox.Text.Trim().Equals("")))
            {
                // empty fields.
                return (true);
            }
            else
            {
                // data in both fields.
                return (false);
            }
        }//End of emptyField() method

        //returns the login details from the form 
        private Staff getEnteredLoginDetails()
        {
            if (emptyField())
            {
                return (null);
            }
            else
            {
                Staff staffLogin = new Staff();
                staffLogin.userName = userNameTextBox.Text;
                staffLogin.password = passwordTextBox.Text;
                return (staffLogin);
            }
        }//End (Staff) getEnteredLoginDetails() method

        //Action performed when the login button is clicked
        private void loginButton_Click(object sender, EventArgs e)
        {
            // Hold the value for the returned user type
            byte staffType = 0;

            // get the user details entered for validation at the remote database
            Staff staffLogin = getEnteredLoginDetails();

            if (staffLogin == null)
            {
                // There is blank fields
                MessageBox.Show("Blank fields not allowed.");
                return;
            }

            // Validate the user at the remote database
            myRemoteLogin = new EricRemoteLogin();

            staffType = myRemoteLogin.login(staffLogin);

            // Determine the type of user returned.
            // If successful take the user to their appropriate
            // interface.
            // Otherwise handle any invalid users appropriately.

            switch (staffType)
            {
                case (byte)StaffType.Administrator:
                    MessageBox.Show(myRemoteLogin.dbResultMessage);
                    break;
                case (byte)StaffType.Staff:
                    //MessageBox.Show(myRemoteLogin.dbResultMessage);
                    StaffMainMenu myStaffMenu = new StaffMainMenu();
                    myStaffMenu.getStaffTextBox().Text = myDAO.getStaff(this.userNameTextBox.Text);
                    myStaffMenu.ShowDialog();
                    break;
                case (byte)StaffType.LocalManager:
                    MessageBox.Show(myRemoteLogin.dbResultMessage);
                    break;
                case (byte)StaffType.NationalManager:
                    MessageBox.Show(myRemoteLogin.dbResultMessage);
                    break;
                case (byte)StaffType.UnknownUser:
                    MessageBox.Show(myRemoteLogin.dbResultMessage);
                    break;
                default:
                    // Handle database error
                    MessageBox.Show(myRemoteLogin.dbResultMessage);
                    break;
            }
        }

        private void LogInForm_Load(object sender, EventArgs e)
        {

        }

        private void Titlelabel_Click(object sender, EventArgs e)
        {

        }

        private void loginExitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

       /* private void loginButton_Click_1(object sender, EventArgs e)
        {

        }*/
    }
}

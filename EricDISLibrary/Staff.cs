using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    public class Staff
    {
        private string _staffID;
        private string _firstName;
        private string _lastName;
        private DateTime _dateOfBirth;
        private string _userName;
        private string _password;
        private byte _position;
        private string _centreID;

        //******* Define Properties ********//

        public string staffID
        {
            set { _staffID = value; }
            get { return (_staffID); }
        }//End of staffID property definition

        public string firstName
        {
            set { _firstName = value; }
            get { return (_firstName); }
        }//End of firstName property definition

        public string lastName
        {
            set { _lastName = value; }
            get { return (_lastName); }
        }//End of lastName property definition

        public DateTime dateOfBirth
        {
            set { _dateOfBirth = value; }
            get { return (_dateOfBirth); }
        }//End of dateOfBirth property definition

        public string userName
        {
            set { _userName = value; }
            get { return (_userName); }
        }//End of userName property definition

        public string password
        {
            set { _password = value; }
            get { return (_password); }
        }//End of password property definition

        public string centreID
        {
            set { _centreID = value; }
            get { return (_centreID); }
        }//End of centreID property definition

        public byte position
        {
            set { _position = value; }
            get { return (_position); }
        }//End of position property definition

        //******* End of Properties definition *******//
        public Staff()
        {
            _firstName = "";
            _lastName = "";
            _userName = "";
            _password = "";
            _position = 0;
        }//End Staff constructor
    }// End of Staff class
}// End of EricDISLibrary namespac

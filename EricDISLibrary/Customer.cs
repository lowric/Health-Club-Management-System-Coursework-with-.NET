using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    public class Customer
    {
        private string _pkCustomerID;
        private string _customerName;
        private string _membership;

        //------- Define properties -------//
        public string pkCustomerID
        {
            set { _pkCustomerID = value; }
            get { return (_pkCustomerID); }
        }//End of pkCustomerID property definition

        public string customerName
        {
            set { _customerName = value; }
            get { return (_customerName); }
        }//End of customerName definition

        public string membership
        {
            set { _membership = value; }
            get { return (_membership); }
        }//End of membership definition

        public Customer()
        {
             _pkCustomerID = "";
             _customerName = "";
             _membership = "";
        }//End Customer constructor

        //------- End of properties definitions -------//

    }//End of Customer class
}//End EricDISLibrary namespace

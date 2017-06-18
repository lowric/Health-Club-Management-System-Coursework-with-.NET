using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    class Membership
    {
        private string _membershipName;
        private decimal _discount;

        //*********Property definition*************//

        public string membershipName
        {
            set { _membershipName = value; }
            get { return (_membershipName);}
        }//End of membershipName definition

        public decimal discount
        {
            set { _discount = value; }
            get { return (_discount); }
        }//End of discount definition

        //**********End Property Definition********//

        public Membership()
        {
            _membershipName = "";
            _discount = 0.0m;
        }//End membership constructor
    }//End of Membership class
}//End EricDISLibrary namespace

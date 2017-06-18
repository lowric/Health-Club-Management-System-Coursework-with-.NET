using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    public class Booking
    {
        private string _pkBookingID;
        private String _fkCustomerID;
        private string _fkStaffID;
        private String _fkActivityID;
        private DateTime _bookingDate;
        private decimal _totalFee;

        //******* Define Properties ********//

        public string pkBookingID
        {
            set { _pkBookingID = value; }
            get { return (_pkBookingID); }
        }//End of pkBookingID property definition

        public String fkCustomerID
        {
            set{ _fkCustomerID = value;}
            get{ return (_fkCustomerID);}
        }//End of fkCustomerID property definition

        public string fkStaffID
        {
            set { _fkStaffID = value; }
            get { return (_fkStaffID); }
        }//End of fkStaffID property definition

        public String fkActivityID
        {
            set { _fkActivityID = value; }
            get { return (_fkActivityID); }
        }//End of fkActivityID property definition

        public DateTime bookingDate
        {
            set { _bookingDate = value; }
            get { return (_bookingDate); }
        }//End of bookingDate property definition


        public decimal totalFee
        {
            set { _totalFee = value; }
            get { return (_totalFee); }
        }//End of totalFee property definition

        //******* End of Properties definition *******//
        public Booking()
        {
            _pkBookingID = "";
            _fkCustomerID = "";
            _fkStaffID = "";
            _fkActivityID = "";
            _bookingDate = DateTime.Now;
            _totalFee = 0.0M;
        }//End of Booking constructor
    }// End of Booking class
}// End of EricDISLibrary namespace

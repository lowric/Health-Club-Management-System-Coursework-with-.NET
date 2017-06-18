using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    public class Activity
    {
        private string _activityID;
        private string _activityName;
        private decimal _activityPrice;
        private decimal _bookingFee;

        //------- Define properties -------//
        public string activityID
        {
            set { _activityID = value; }
            get { return (_activityID); }
        }//End of activityID property definition

        public string activityName
        {
            set { _activityName = value; }
            get { return (_activityName); }
        }//End of activityName definition

        public decimal activityPrice
        {
            set { _activityPrice = value; }
            get { return (_activityPrice); }
        }//End of activityPrice definition

        public decimal bookingFee
        {
            set { _bookingFee = value; }
            get { return (_bookingFee); }
        }//End of bookingFee definition

        //------- End of properties definitions -------//

        public Activity()
        {
             _activityID = "";
             _activityName = "";
             _activityPrice = 0.0m;
             _bookingFee = 0.0m;
        }//End Activity constructor
    }// End of Activity class
}// End of EricDISLibrary namespace

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    public class EricRemoteStaff : MarshalByRefObject
    {
        private EricDAO myDAO;
        private string _dbResultMessage;

        //------- Define Properties -------//

        public string dbResultMessage
        {
            set { _dbResultMessage = value; }
            get { return (_dbResultMessage); }

        }//End of id property definition
        //------- End of properties definitions -------//

        public EricRemoteStaff()
        {

        }//End of EricRemoteStaff() constructor

        public bool addBooking(Booking aBooking)
        {
            myDAO = new EricDAO();
            bool result = myDAO.addBooking(aBooking);
            _dbResultMessage = myDAO.resultMessage;
            return (result);
        }//End of  bool addBooking()
        
        public FoodBeverage[] getAllFood()
        {
            myDAO = new EricDAO();
            FoodBeverage[] listOfFood = myDAO.getAllFoods();
            _dbResultMessage = myDAO.resultMessage;
            return (listOfFood);
        }//End of  FoodBeverage[] getAllFood()

        public FoodBeverage[] getAllBeverage()
        {
            myDAO = new EricDAO();
            FoodBeverage[] listOfBeverage = myDAO.getAllBeverages();
            _dbResultMessage = myDAO.resultMessage;
            return (listOfBeverage);
        }//End of  FoodBeverage[] getAllBeverage()
    }// End of EricRemoteAdministrator class
}// End of EricDISLibrary namespace

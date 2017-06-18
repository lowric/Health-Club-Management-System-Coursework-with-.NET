using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    public class EricRemoteLogin : MarshalByRefObject
    {
        private EricDAO myDAO;
        private string _dbResultMessage;

        //------- Define Properties -------//

        public string dbResultMessage
        {
            set { _dbResultMessage = value; }
            get { return (_dbResultMessage); }

        }//End of dbResultMessage property definition
        //------- End of properties definitions -------//

        public EricRemoteLogin()
        {
            myDAO = new EricDAO();
        }//End of EricRemoteLogin() constructor

        public byte login(Staff aStaff)
        {
            byte result =
                myDAO.identifyStaff(aStaff);
            _dbResultMessage = myDAO.resultMessage;
            return (result);
        }
    }// End EricRemoteLogin class 
}// EricDISLibrary namespace

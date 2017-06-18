using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    public class Sale
    {
        private int _pkSaleID;
        private string _fkStaffID;
        private string _fkFoodBeverageID;
        private DateTime _dateOfSell;
        private byte _quantity;
        private decimal _totalAmount;
        

        //------- Define Properties -------//
        public int pkSaleID
        {
            set { _pkSaleID = value; }
            get { return (_pkSaleID); }
        }//End of pkSaleID property definition

        public string fkStaffID
        {
            set { _fkStaffID = value; }
            get { return (_fkStaffID); }
        }//End of fkStaffID property definition

        public string fkFoodBeverageID
        {
            set { _fkFoodBeverageID = value; }
            get { return (_fkFoodBeverageID); }
        }//End of fkFoodBeverageID property definition

        public DateTime dateOfSell
        {
            set { _dateOfSell = value; }
            get { return (_dateOfSell); }
        }//End of dateOfSell property definition

        public byte quantity
        {
            set { _quantity = value; }
            get { return (_quantity); }
        }//End of quantity property definition

        public decimal totalAmount
        {
            set { _totalAmount = value; }
            get { return (_totalAmount); }
        }//End of totalAmount property definition


        public Sale()
        {
            _pkSaleID = 0;
            _fkStaffID = "";
            _fkFoodBeverageID = "";
            _dateOfSell = new DateTime();
            _quantity = 0;
            _totalAmount = 0.0m;
            
        }//End of Student Constructor
        //------- End of properties definitions ------//
    }// End of Sale class
}// End of EricDISLibrary namespace

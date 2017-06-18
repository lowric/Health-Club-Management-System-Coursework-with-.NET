using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace EricDISLibrary
{
    [Serializable]
    public class FoodBeverage
    {
        private string _pkFoodBeverageID;
        private string _foofBeverageName;
        private decimal _foodBeveragePrice;
        private string _type;

        //------- Define properties -------//
        public string pkFoodBeverageID
        {
            set { _pkFoodBeverageID = value; }
            get { return (_pkFoodBeverageID); }
        }//End of pkFoodBeverageID property definition

        public string foofBeverageName
        {
            set { _foofBeverageName = value; }
            get { return (_foofBeverageName); }
        }//End of foofBeverageName definition

        public decimal foodBeveragePrice
        {
            set { _foodBeveragePrice = value; }
            get { return (_foodBeveragePrice); }
        }//End of foodBeveragePrice definition

        public string type
        {
            set { _type = value; }
            get { return (_type); }
        }//End of type definition

        //------- End of properties definitions -------//

        public FoodBeverage()
        {
            _pkFoodBeverageID = "";
            _foofBeverageName = "";
            _foodBeveragePrice= 0.0m;
            _type = "";
        }//End FoodBeverage constructor

    }//End of FoodBeverage class
}//End EricDISLibrary namespace

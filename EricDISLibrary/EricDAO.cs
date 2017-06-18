using System;

// Used to handle configuration of data such as pointing to data sources etc.
using System.Configuration;

// Enables to use components that manage data from multiple sources
using System.Data;

// Used to access OLE DB Data Sources such as Microsoft Access
using System.Data.OleDb;

// Allows you use utility classes such as ArrayList
using System.Collections;


namespace EricDISLibrary
{
    public class EricDAO
    {
        //Generates a code that determines the message displyed in case anything goes wrong
        private readonly byte _ERROR_CODE;

        //
        private string _resultMessage;

        //Configures the connection and gives the path to the database
        private ConnectionStringSettings _connectionString;
        private ConnectionStringSettings _myConnectionString;

        //connection object to communicate with the database
        private OleDbConnection _myConnection;

        //Holds the Quiery to send to the database
        private OleDbCommand _myCommand;

        //Object to read the database
        private OleDbDataReader _myDbDataReader;

        /******* Define Properties *******/

        public byte ERROR_CODE
        {
            get { return (_ERROR_CODE); }
        }//End of ERROR_CODE property definition

        public string resultMessage
        {
            get { return (_resultMessage); }
        }//End of resultString property definition

        public ConnectionStringSettings aConnectionString
        {
            set { _connectionString = value; }
            get { return (_connectionString); }
        }//End of  connectionString property definition

        public ConnectionStringSettings myConnectionString
        {
            set { _myConnectionString = value; }
            get{return (_myConnectionString);}
        }

        public OleDbConnection myConnection
        {
            set { _myConnection = value; }
            get { return (_myConnection); }
        }//End of  myConnection property definition

        public OleDbCommand myCommand
        {
            set { _myCommand = value; }
            get { return (_myCommand); }
        }//End of  myCommand property definition

        public OleDbDataReader myDbDataReader
        {
            set { _myDbDataReader = value; }
            get { return (_myDbDataReader); }
        }//End of myDbReader property definition

        /******* End Properties Definitions *******/

        public EricDAO()
        {
            _ERROR_CODE = 255;
            _resultMessage = "";
            _connectionString = ConfigurationManager.ConnectionStrings["Eric_DIS_CourseWork"];
            _myConnectionString = ConfigurationManager.ConnectionStrings["Eric_DIS_CourseWork"];

        }//End of EricDAO() constructor

        public byte identifyStaff(Staff staff)
        {
            byte staffType = 0;
            //aConnectionString = ConfigurationManager.ConnectionStrings["Eric_DIS_CourseWork"];

            try
            {

                // Create New Database Connection
               // myConnection = new OleDbConnection(aConnectionString.ConnectionString);
                myConnection = new OleDbConnection(myConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Create the Adapter and fill the DataSet
                myCommand = new OleDbCommand("FindStaffTypeIdByUsernameAndPassword", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@Username", OleDbType.VarChar);
                myCommand.Parameters.Add("@Password", OleDbType.VarChar);
                myCommand.Parameters["@Username"].Value = staff.userName;
                myCommand.Parameters["@Password"].Value = staff.password;

                // Check for a single return value from the database.
                // In this case, we are only interested in the type of
                // user returned from the database
                staffType = Convert.ToByte(myCommand.ExecuteScalar());


                if ((staffType <= (byte)StaffType.UnknownUser) ||
                    staffType > (byte)StaffType.Error)
                {
                    _resultMessage = "Unknown User";
                    return ((byte)StaffType.UnknownUser);
                }
                else
                {
                    // Eureka - every little thing is going be alright.
                    //_resultMessage = "Success Login... Staff Type is: " +
                                       //staffType;
                    return (staffType);
                }
            }
            catch (Exception ex)
            {
                _resultMessage = "DB Error: " + ex.Message;
                return ((byte)StaffType.Error);
            }
            finally
            {
                // Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of byte identifyStaff(Staff) method

        public Staff[] getAllStaffs()
        {
            try
            {
                ArrayList listOfStaff = new ArrayList();

                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Prepare Command to add new current total to the database
                myCommand = new OleDbCommand("GetAllStaffs", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myDbDataReader = myCommand.ExecuteReader();

                while (myDbDataReader.Read())
                {
                    Staff aStaff = new Staff();

                    aStaff.staffID = myDbDataReader.GetString(0);
                    aStaff.firstName = myDbDataReader.GetString(1);
                    aStaff.lastName = myDbDataReader.GetString(2);
                    aStaff.dateOfBirth = myDbDataReader.GetDateTime(3);
                    aStaff.position = myDbDataReader.GetByte(4);
                    aStaff.userName = myDbDataReader.GetString(5);
                    aStaff.password = myDbDataReader.GetString(6);
                    aStaff.centreID = myDbDataReader.GetString(7);

                    listOfStaff.Add(aStaff);
                }

                _resultMessage = "Database read successfully...";
                return ((Staff[])listOfStaff.ToArray(typeof(Staff)));
            }
            catch (Exception ex)
            {
                _resultMessage =
                    "DB Error: " + ex.Message;
                return (null);
            }
            finally
            {
                //Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of getAllStaffs() method

        public string getStaff(string username)
        {
            try
            {

                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Prepare Command to add new current total to the database
                myCommand = new OleDbCommand("GetStaff", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                //myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@Username", OleDbType.VarChar);
                myCommand.Parameters["@Username"].Value = username;
                string ID = Convert.ToString(myCommand.ExecuteScalar());
               /* myDbDataReader = myCommand.ExecuteReader();

               
                    Staff aStaff = new Staff();

                    aStaff.staffID = myDbDataReader.GetString(0);
                    aStaff.firstName = myDbDataReader.GetString(1);
                    aStaff.lastName = myDbDataReader.GetString(2); */              

                _resultMessage = "Database read successfully...";
                return (ID);
            }
            catch (Exception ex)
            {
                _resultMessage =
                    "DB Error: " + ex.Message;
                return (null);
            }
            finally
            {
                //Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of getStaff() method

        public Customer[] getAllCustomers()
        {
            try
            {
                ArrayList listOfCustomer = new ArrayList();

                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Prepare Command to add new current total to the database
                myCommand = new OleDbCommand("GetAllCustomers", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myDbDataReader = myCommand.ExecuteReader();

                while (myDbDataReader.Read())
                {
                    Customer aCustomer = new Customer();

                    aCustomer.pkCustomerID = myDbDataReader.GetString(0);
                    aCustomer.customerName = myDbDataReader.GetString(1);
                    aCustomer.membership = myDbDataReader.GetString(2);
                    

                    listOfCustomer.Add(aCustomer);
                }

                _resultMessage = "Database read successfully...";
                return ((Customer[])listOfCustomer.ToArray(typeof(Customer)));
            }
            catch (Exception ex)
            {
                _resultMessage =
                    "DB Error: " + ex.Message;
                return (null);
            }
            finally
            {
                //Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of getAllcustomers() method

        public Activity[] getAllactivities()
        {
            try
            {
                ArrayList listOfActivity = new ArrayList();

                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Prepare Command to add new current total to the database
                myCommand = new OleDbCommand("GetAllActivities", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myDbDataReader = myCommand.ExecuteReader();

                while (myDbDataReader.Read())
                {
                    Activity anActivity = new Activity();

                    anActivity.activityID = myDbDataReader.GetString(0);
                    anActivity.activityName = myDbDataReader.GetString(1);
                    anActivity.activityPrice = myDbDataReader.GetDecimal(2);
                    anActivity.bookingFee = myDbDataReader.GetDecimal(3);

                    listOfActivity.Add(anActivity);
                }

                _resultMessage = "Database read successfully...";
                return ((Activity[])listOfActivity.ToArray(typeof(Activity)));
            }
            catch (Exception ex)
            {
                _resultMessage =
                    "DB Error: " + ex.Message;
                return (null);
            }
            finally
            {
                //Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of getAllActivities() method

        public FoodBeverage[] getAllBeverages()
        {
            try
            {
                ArrayList listOfBeverage = new ArrayList();

                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Prepare Command to add new current total to the database
                myCommand = new OleDbCommand("GetAllBeverages", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myDbDataReader = myCommand.ExecuteReader();

                while (myDbDataReader.Read())
                {
                    FoodBeverage aBeverage = new FoodBeverage();

                    aBeverage.pkFoodBeverageID = myDbDataReader.GetString(0);
                    aBeverage.foofBeverageName = myDbDataReader.GetString(1);
                    aBeverage.type = myDbDataReader.GetString(2);
                    aBeverage.foodBeveragePrice = myDbDataReader.GetDecimal(3);

                    listOfBeverage.Add(aBeverage);
                }

                _resultMessage = "Database read successfully...";
                return ((FoodBeverage[])listOfBeverage.ToArray(typeof(FoodBeverage)));
            }
            catch (Exception ex)
            {
                _resultMessage =
                    "DB Error: " + ex.Message;
                return (null);
            }
            finally
            {
                //Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of getAllBeverages() method

        public FoodBeverage[] getAllFoods()
        {
            try
            {
                ArrayList listOfFood = new ArrayList();

                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Prepare Command to add new current total to the database
                myCommand = new OleDbCommand("GetAllFoods", myConnection);
                myCommand.CommandType = CommandType.StoredProcedure;
                myDbDataReader = myCommand.ExecuteReader();

                while (myDbDataReader.Read())
                {
                    FoodBeverage aFood = new FoodBeverage();

                    aFood.pkFoodBeverageID = myDbDataReader.GetString(0);
                    aFood.foofBeverageName = myDbDataReader.GetString(1);
                    aFood.type = myDbDataReader.GetString(2);
                    aFood.foodBeveragePrice = myDbDataReader.GetDecimal(3);

                    listOfFood.Add(aFood);
                }

                _resultMessage = "Database read successfully...";
                return ((FoodBeverage[])listOfFood.ToArray(typeof(FoodBeverage)));
            }
            catch (Exception ex)
            {
                _resultMessage =
                    "DB Error: " + ex.Message;
                return (null);
            }
            finally
            {
                //Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of getAllFoods() method

        public bool takeOrder(Sale aSale)
        {
            try
            {
                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Create the Adapter and fill the DataSet
                myCommand = new OleDbCommand("InsertNewSale", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;
                myCommand.Parameters.Add("@saleID", OleDbType.Numeric);
                myCommand.Parameters.Add("@StaffID", OleDbType.VarChar);
                myCommand.Parameters.Add("@FBID", OleDbType.VarChar);
                //myCommand.Parameters.Add("@CID", OleDbType.VarChar);
                myCommand.Parameters.Add("@DateOfSell", OleDbType.DBDate);
                myCommand.Parameters.Add("@Quantity", OleDbType.Numeric);
                myCommand.Parameters.Add("@TotalAmount", OleDbType.Currency);
                myCommand.Parameters["@saleID"].Value = aSale.pkSaleID;
                myCommand.Parameters["@StaffID"].Value = aSale.fkStaffID;
                myCommand.Parameters["@FBID"].Value = aSale.fkFoodBeverageID;
                //myCommand.Parameters["@CID"].Value = aSale.fkCustomerID;
                myCommand.Parameters["@DateOfSell"].Value = aSale.dateOfSell;
                myCommand.Parameters["@Quantity"].Value = aSale.quantity;
                myCommand.Parameters["@TotalAmount"].Value = aSale.totalAmount;

                myCommand.ExecuteNonQuery();

                // Eureka - New Enrolment successfull added
                // Report this in the dbResultMessage
                _resultMessage =
                    "Sale Confirmed.";
                return (true);
            }
            catch (Exception ex)
            {
                _resultMessage = "DB Error: " + ex.Message;
                return (false);
            }
            finally
            {
                // Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of bool takeOrder(Sale) method

        public bool addBooking(Booking newBooking)
        {
            try
            {
                // Create New Database Connection
                myConnection = new OleDbConnection(aConnectionString.ConnectionString);

                // Open the Database Connection
                myConnection.Open();

                // Create the Adapter and fill the DataSet
                myCommand = new OleDbCommand("InsertNewBooking", myConnection);

                myCommand.CommandType = CommandType.StoredProcedure;
               // myCommand.Parameters.Add("@BookID", OleDbType.);
                myCommand.Parameters.Add("@StaffID", OleDbType.VarChar);
                myCommand.Parameters.Add("@ActID", OleDbType.VarChar);
                myCommand.Parameters.Add("@CID", OleDbType.VarChar);
                myCommand.Parameters.Add("@BookDate", OleDbType.DBDate);
                myCommand.Parameters.Add("@TotalFee", OleDbType.Currency);
               // myCommand.Parameters["@BookID"].Value = newEnrolment.fkStudentNo;
                myCommand.Parameters["@StaffID"].Value = newBooking.fkStaffID;
                myCommand.Parameters["@ActID"].Value = newBooking.fkActivityID;
                myCommand.Parameters["@CID"].Value = newBooking.fkCustomerID;
                myCommand.Parameters["@BookDate"].Value = newBooking.bookingDate;
                myCommand.Parameters["@TotalFee"].Value = newBooking.totalFee;

                myCommand.ExecuteNonQuery();

                // Eureka - New Enrolment successfull added
                // Report this in the dbResultMessage
                _resultMessage =
                    "Booking Confirmed.";
                return (true);
            }
            catch (Exception ex)
            {
                _resultMessage = "DB Error: " + ex.Message;
                return (false);
            }
            finally
            {
                // Tidy up the Database Connection if it is unclosed
                if (myConnection != null)
                {
                    myConnection.Close();
                }
            }
        }//End of bool addBooking(Booking) method


    }// of EricDAO class
}//End of EricDISLibrary namespace

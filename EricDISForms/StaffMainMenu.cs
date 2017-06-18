using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EricDISLibrary;

namespace EricDISForms
{
    public partial class StaffMainMenu : Form
    {
        private EricRemoteStaff anEricRemoteStaff;
        public StaffMainMenu()
        {
            InitializeComponent();
            anEricRemoteStaff = new EricRemoteStaff();
            if (fillFoodComboBox() && fillBeverageComboBox())
            {
                buyButton.Enabled = true;
            }
        }

       

        private void StaffMainMenu_Load(object sender, EventArgs e)
        {

        }


        private void SaleButton_Click(object sender, EventArgs e)
        {
            salePanel.Show();
            membershipPanel.Hide();
            bookingPanel.Hide();
        }

        private void BookingButton_Click(object sender, EventArgs e)
        {
            bookingPanel.Show();
            membershipPanel.Hide();
            salePanel.Show();
        }

        private void MembershipButton_Click(object sender, EventArgs e)
        {
            salePanel.Hide();
            bookingPanel.Hide();
            membershipPanel.Show();
           
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void bookbutton_Click(object sender, EventArgs e)
        {

        }

        private void changeMembershipbutton_Click(object sender, EventArgs e)
        {

        }

        private void salePanel_Paint(object sender, PaintEventArgs e)
        {

        }

        public FoodBeverage[] createFoodList()
        {
            FoodBeverage[] FoodList = anEricRemoteStaff.getAllFood();

            return (FoodList);
        }
        public FoodBeverage[] createBeverageList()
        {
            FoodBeverage[] BeverageList = anEricRemoteStaff.getAllBeverage();

            return (BeverageList);
        }

        public bool fillFoodComboBox()
        {
            FoodBeverage[] FoodList = createFoodList();

            if (FoodList != null)
            {
                for (int i = 0; i < FoodList.Length; i++)
                {
                    KeyValuePair<string, string> itemForComboBox = new KeyValuePair<string, string>
                    (FoodList[i].pkFoodBeverageID, FoodList[i].foofBeverageName + " " + "(" + FoodList[i].type + ")");
                    FoodComboBox.Items.Add(itemForComboBox);
                }
                //store the primary key as a hidden value in the combobox
                FoodComboBox.ValueMember = "Key";
                FoodComboBox.DisplayMember = "Value";
                //Automatically select the first student
                FoodComboBox.SelectedIndex = 0;
                return (true);
            }
            return (false);
        }

        public bool fillBeverageComboBox()
        {
            FoodBeverage[] BeverageList = createBeverageList();

            if (BeverageList != null)
            {
                for (int i = 0; i < BeverageList.Length; i++)
                {
                    KeyValuePair<string, string> itemForComboBox = new KeyValuePair<string, string>
                    (BeverageList[i].pkFoodBeverageID, BeverageList[i].foofBeverageName + " " + "(" + BeverageList[i].type + ")");
                    beverageComboBox.Items.Add(itemForComboBox);
                }
                //store the primary key as a hidden value in the combobox
                beverageComboBox.ValueMember = "Key";
                beverageComboBox.DisplayMember = "Value";
                //Automatically select the first course
                beverageComboBox.SelectedIndex = 0;
                return (true);
            }
            return (false);
        }

        public TextBox getStaffTextBox()
        {
            return (staffIDTextBox);
        }

       /* private Sale extractSaleFieldsDetails()
        {
            try
            {
                Sale aSale = null;
                aSale = new Sale();

                KeyValuePair<string, string> comboBoxItem = (KeyValuePair<string, string>)FoodComboBox.SelectedItem;
                aSale. = comboBoxItem.Key;
                comboBoxItem = (KeyValuePair<string, string>)courseComboBox.SelectedItem;
                anEnrolment.fkCourseNo = comboBoxItem.Key;
                anEnrolment.startDate = startDateTimePicker.Value;
                anEnrolment.endDate = endDateTimePicker.Value;
                anEnrolment.fee = Convert.ToDecimal(feeTextBox.Text);
                return (anEnrolment);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return (null);
            }
        }*/
    }
}

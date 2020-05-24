using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATM_Simulator
{
    partial class ATM : Form
    {
        //local referance to the array of accounts
        public Account[] ac;
        //used to store user input
        string inputtedAccountNumber = "";
        //used to store user input
        string inputtedPin = "";
        // bool to check if account number is entered
        bool accountNumberEntered = false;
        // bool to check if logging in is active, so the correct window elements can be displayed
        bool loggingIn = true;
        // same as above but for menu of atm
        bool menuActive = false;
        //same as above but for withdraw menu
        bool withdrawMenuActive = false;

        //this is a referance to the account that is being used
        private Account activeAccount = null;

        // simple validate bool used to check correct input
        Boolean validate = false;


        //constructor to set correct window elements and initilize the window
        public ATM(Account[] ac)
        {
            InitializeComponent();

            hideMenu();
            bool show = false;
            hideWithdrawMenu(show);


            // InitializeComponent();
            pinLabel.Hide();
            this.Show();
            this.ac = ac;



            //findAccount();
        }


        // used to hide certain labels and textboxes when not needed
        public void hideMenu()
        {
            withdrawOptionLabel.Hide();
            displayBalanceLabel.Hide();
            exitOptionLabel.Hide();
            accountInfoDisplayONMenuScreen.Hide();
            accountMenuInput.Hide();
        }

        //same as above but for withdraw menu, uses a parameter to set hide/show so slightly more useful implementation
        public void hideWithdrawMenu(bool show)
        {
            if (!show)
            {
                withdraw20label.Hide();
                withdraw50label.Hide();
                withdraw100label.Hide();
                withdraw500label.Hide();
            }
            else
            {
                withdraw20label.Show();
                withdraw50label.Show();
                withdraw100label.Show();
                withdraw500label.Show();
            }

        }


        /*private Account findAccount()
        {
            //display.AppendText("\nEnter your account number:");
            //pinLabel.Hide();


            for (int i = 0; i < this.ac.Length; i++)
            {
                // if (ac[i].getAccountNum() == input)
                //  {
                //     return ac[i];
                // }
            }

            return null;
        }*/

        
       
        //used when a button is clicked, the appropiate action is performed depending on the button press
        private void btn_Clicked(object sender, EventArgs e)
        {
            switch (((Button)sender).Name)
            {
                case "btnValidate":
                    // implemented on its own below
                    break;

                case "btnCancel":
                    if (loggingIn == true)
                        loginTextBox.Clear();
                    if (menuActive == true || withdrawMenuActive == true)
                    {
                        accountMenuInput.Clear();
                    }

                    break;
                
                default:
                    // displays to correct textbox depending on active menu
                    if (loggingIn == true)
                        loginTextBox.AppendText(((Button)sender).Text);
                    if (menuActive == true || withdrawMenuActive == true)
                    {
                        accountMenuInput.AppendText(((Button)sender).Text);
                    }
                    break;
            }
        }



        // method to check for a valid account and pin number
        public void checkAccountNum(string accountNum, string pin)
        {

            //locals variables for storing input when converted
            int convertedAccountNum;
            int convertedPin;

            Int32.TryParse(accountNum, out convertedAccountNum);
            Int32.TryParse(pin, out convertedPin);

            for (int i = 0; i < ac.Length; i++)
            {
                if (ac[i].getAccountNum() == convertedAccountNum)
                {
                    if (ac[i].checkPin(convertedPin))
                    {
                        loggingIn = false;

                        activeAccount = ac[i];
                        //launches account initializaton
                        accountMenu();
                        Console.WriteLine("22222222222222");
                        i = 4;
                        // accountNumberValid = true;    
                    }
                }




                //i = 4;
                // accountNumberValid = false;

            }
            //displays error msg and resets window labels
            if (loggingIn == true)
            {
                loginTextBox.Text += "  ERROR WITH ACCOUNT NUMBER OR PIN";
                accountNumberEntered = false;
                pinLabel.Hide();
                accountLabel.Show();

            }

        }


        // shows elements required for the menu after logging in
        public void accountMenu()
        {
            menuActive = true;
            loginTextBox.Clear();
            loginTextBox.Hide();
            withdrawOptionLabel.Show();
            displayBalanceLabel.Show();
            exitOptionLabel.Show();
            accountInfoDisplayONMenuScreen.Show();
            accountMenuInput.Show();
            accountInfoDisplayONMenuScreen.Clear();
            accountInfoDisplayONMenuScreen.Text += "Active Account: " + activeAccount.getAccountNum();

            //int userChoice;






        }


        // menu to show the withdraw menu correctly
        public void withdrawSubMenu()
        {
            ///hiding labels
            withdrawOptionLabel.Hide();
            displayBalanceLabel.Hide();
            exitOptionLabel.Hide();

            //displaying withdraw options 
            bool showMenu = true;
            hideWithdrawMenu(showMenu);

            withdrawMenuActive = true;




        }

        // method to deal with validate button being pressed
        private void btnValidate_Click(object sender, EventArgs e)
        {

            // checks if log in menu is active
            if (loggingIn)
            {
                if (accountNumberEntered == false)
                {
                    // stores entered data into account number
                    inputtedAccountNumber = loginTextBox.Text.ToString();
                    pinLabel.Show();
                    accountLabel.Hide();
                    loginTextBox.Clear();
                    accountNumberEntered = true;

                }
                else
                {
                    //stores data into pin and calls the validation
                    inputtedPin = loginTextBox.Text.ToString();
                    checkAccountNum(inputtedAccountNumber, inputtedPin);
                }
            }
            
            // checks if the menu after logging in is active and processes the user choice
            if (menuActive)
            {
                if (accountMenuInput.Text.ToString().Equals("1"))
                {
                    ///display balance optiom

                    accountMenuInput.Clear();
                    accountMenuInput.Text += "Current Balance: " + activeAccount.getBalance();
                }
                else if (accountMenuInput.Text.ToString().Equals("2"))
                {
                    //calls for withdraw menu to become active
                    Console.WriteLine("123244657");
                    
                    menuActive = false;

                    withdrawSubMenu();
                    if (withdrawMenuActive == true)
                    {
                        return;
                    }
                    
                }
                else if (accountMenuInput.Text.ToString().Equals("3"))
                {
                    // closes atm
                    this.Close();
                        
                }
            }


            bool showWithdrawMenu = false;

            // deals with user choice on the withdraw menu
            if (withdrawMenuActive == true)
            {
                if (accountMenuInput.Text.ToString().Equals("1"))
                {
                    //withdraw 20 option, calls method to validate 
                    if (activeAccount.decrementBalance(20))
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Successful withdrawal of: 20";
                        accountMenu();
                        
                        hideWithdrawMenu(showWithdrawMenu);
                    }
                    else
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Error, not enough funds";
                        
                    }
                }
                else if (accountMenuInput.Text.ToString().Equals("2"))
                {
                    //withdraw 50
                    if (activeAccount.decrementBalance(50))
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Successful withdrawal of: 50";
                        accountMenu();
                        hideWithdrawMenu(showWithdrawMenu);
                    }
                    else
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Error, not enough funds";
                        
                    }
                }
                else if (accountMenuInput.Text.ToString().Equals("3"))
                {
                    //withdraw 100
                    if (activeAccount.decrementBalance(100))
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Successful withdrawal of: 100";
                        accountMenu();
                        hideWithdrawMenu(showWithdrawMenu);
                    }
                    else
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Error, not enough funds";
                    }
                }
                else if (accountMenuInput.Text.ToString().Equals("4"))
                {
                    //withdraw 500
                    if (activeAccount.decrementBalance(500))
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Successful withdrawal of: 500";
                        accountMenu();
                        hideWithdrawMenu(showWithdrawMenu);
                    }
                    else
                    {
                        accountMenuInput.Clear();
                        accountMenuInput.Text += "Error, not enough funds";
                    }
                }

            }
            //accountNumberEntered = true;
        }
    }

        
}

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
    public partial class centralComputer : Form
    {
        //local version of the accounts 
        public Account[] accountArray;
        public centralComputer(Account[] accounts)
        {
            InitializeComponent();

            accountArray = accounts;
        }

        //calls the static method on the program class to launch a new atm
        private void launchNewATM_Click(object sender, EventArgs e)
        {
            Program.newATM();
        }

        //sets the accounts to be "thread locked" when checked.
        private void threadSafeCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (threadSafeCheckBox.Checked)
            {
                for (int i=0;i<accountArray.Length; i++)
                {
                    accountArray[i].setLockedThread(true);
                }

            }
        }
    }
}

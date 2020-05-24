using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace ATM_Simulator
{
    public class Program
    {

        static Account[] ac = new Account[3];
        static Thread newATMThread;

        /*
         * This fucntions initilises the 3 accounts 
         * and instanciates the ATM class passing a referance to the account information
         * 
         */
        public Program()
        {
            ac[0] = new Account(300, 1111, 111111);
            ac[1] = new Account(750, 2222, 222222);
            ac[2] = new Account(3000, 3333, 333333);

            Application.Run(new centralComputer(ac));
        }


        //static method to launch a thread for each atm
        public static void newATM()
        {

            newATMThread = new Thread(LaunchThread);
            newATMThread.Start();

           // ATM newATM = new ATM(ac);

        }

        //method to launch a new atm
        public static void LaunchThread()
        {
            Application.Run(new ATM(ac));
        }

        static void Main(string[] args)
        {
            new Program();
        }
    }
}

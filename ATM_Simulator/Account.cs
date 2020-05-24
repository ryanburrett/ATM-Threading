using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace ATM_Simulator
{
    public class Account
    {
        //the attributes for the account
        private int balance;
        private int pin;
        private int accountNum;
        private object lockAccountThread = new object();
        private bool lockedThread;

        

        // a constructor that takes initial values for each of the attributes (balance, pin, accountNumber)
        public Account(int balance, int pin, int accountNum)
        {
            lockedThread = false;
            this.balance = balance;
            this.pin = pin;
            this.accountNum = accountNum;
        }

        //getter and setter functions for balance
        public int getBalance()
        {
            return balance;
        }
        public void setBalance(int newBalance)
        {
            this.balance = newBalance;
        }

        //getter and setter for checking if locking a thread is needed
        public void setLockedThread(bool locked)
        {
            lockedThread = locked;
        }

        public bool getLockedThreadState()
        {
            return lockedThread;
        }

        
        /*
         *   This funciton allows us to decrement the balance of an account
         *   it perfomes a simple check to ensure the balance is greater tha
         *   the amount being debeted
         *   
         *   reurns:
         *   true if the transactions if possible
         *   false if there are insufficent funds in the account
         */
        public Boolean decrementBalance(int amount)
        {
            if (this.balance > amount)
            {
                // check if thread should be locked, set on the centralcomputer
                if (lockedThread)
                {
                    //only allows one thread to access this piece of code at a time.
                    lock (lockAccountThread)
                    {
                        Thread.Sleep(2000);
                        //rechecks balance amount so to make sure a thread cannot edit unjustly
                        if (balance < amount)
                        {
                            return false;
                        }
                        else
                        {
                            balance -= amount;

                            return true;
                        }
                    }
                }
                else
                {
                    Thread.Sleep(2000);
                    balance -= amount;
                    return true;
                }
            }
            else
            {
                return false;
            }
        }

        /*
         * This funciton check the account pin against the argument passed to it
         *
         * returns:
         * true if they match
         * false if they do not
         */
        public Boolean checkPin(int pinEntered)
        {
            if (pinEntered == pin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        //gettter for the account number of the account
        public int getAccountNum()
        {
            return accountNum;
        }
    }
}

# ATM-Threading

Application created in March 2017. 

A C# application created to show the impact of thread locking. The context being trying to withdraw funds from an ATM.

The project was very useful in terms of teaching me how thread locking can stop unintended behaviour and stop a race to access the same data. One of the most enjoyable projects I did at University. 


The UI is very janky but this was purely used as a teaching oppurtunity about threading importance. 




Context for the Image. The artificial bank account had 750 value inside it. All instances of the ATM's tried to withdraw 500 at the same time. Thanks to locking the thread. Only the first ATM instance had enough funds to successfully withdraw.

![atm image](https://user-images.githubusercontent.com/35525550/82750354-82eeaa80-9da7-11ea-982b-50f7779eb412.png)

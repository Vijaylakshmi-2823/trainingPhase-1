
// See https://aka.ms/new-console-template for more information

// Multithreading in c# which allow the concurrent execution of multiple parts of a program to maximie the CPU Utiliation
//. It is useful for running time-consuming tasks without blocking the main thread such as UI  ,

// Thread - >  is the smallest unit of execution within  a process . program starts with a main thread and can create additionalthreads

//  We can create threads using the Thread class in System.Threading 

using System;
using System.Threading;

class Program
{


    static void printnumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Method 1" + Thread.CurrentThread.Name);


        }

    }
    static void displaynumbers()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Method 2" + Thread.CurrentThread.Name);
            if (i == 3)
            {
                Console.WriteLine("Performing some operations the data to be fetched");
                Thread.Sleep(1000);
                Console.WriteLine("After Performing some operations completed");



            }


        }

    }

    static void Executingbackgroundtask()
    {
        for (int i = 1; i <= 5; i++)
        {
            Console.WriteLine("Method 3" + Thread.CurrentThread.Name);


        }

    }
    // single Threaded Application
    static void Main1()
    {
        // Creates and manage threads manually
        Thread T1 = new Thread(printnumbers);
        T1.Name = "  Thread -1";

        Thread T2 = new Thread(displaynumbers);
        T2.Name = "  Thread -2";

        Thread T3 = new Thread(Executingbackgroundtask);
        T3.Name = "  Thread -3";

        T1.Start();
        T2.Start();
        T3.Start();

        Console.WriteLine("Main Thread is Ended");

        /*  printnumbers();
          displaynumbers();
          Executingbackgroundtask();*/
        {

        }
    }

}


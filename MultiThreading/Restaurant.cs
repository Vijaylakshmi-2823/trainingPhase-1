using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingExample
{
    // Without multithreading
    public class Restaurant

    {

        static async Task ProcessOrder(string customerName, int timeToPrepare)
        {
            Console.WriteLine($"{customerName} placed an Order");
            await Task.Delay(timeToPrepare * 1000); //simulation for  preparation time
            Console.WriteLine($"{customerName} order is ready {timeToPrepare}");


        }

        // here main() is an async one which allows asynchronous execution 
        static async Task Main()
        {
            Stopwatch sw = Stopwatch.StartNew();
            /*  ProcessOrder("Niti", 3);
              ProcessOrder("Jatin", 4);
              ProcessOrder("Aditi", 2);

              sw.Stop();*/
            // will run asynchronously in parallel  // multi 8 core cpu
            Task t1 = ProcessOrder("Niti", 3);
            Task t2 = ProcessOrder("Jatin", 4);
            Task t3 = ProcessOrder("Aditi", 2);

            await Task.WhenAll(t1, t2, t3); // wait for all the orders to complete
            sw.Stop();

            Console.WriteLine($"Total time taken: {sw.Elapsed.Seconds} sec");
        }
    }
}

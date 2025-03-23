using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultithreadingExample
{
    public class Program2
    {


        // Task -- we use it to manage asynchronous operations
        static async Task PrintNumbersAsync()
        {
            await Task.Run(() =>
            {
                for (int i = 1; i <= 5; i++)
                {
                    Console.WriteLine($"Number {i} from Task");
                    Task.Delay(1000).Wait();
                }


            });

        }

        static async Task Main()
        {
            Console.WriteLine("Started ..");
            await PrintNumbersAsync();
            Console.WriteLine("Completed ...");


            // Executes tasks in parallel for faster processing
            Parallel.For(1, 6, i =>

            {
                Console.WriteLine($"Processing {i} on thread {Task.CurrentId}");
            }
            );



        }
    }
}

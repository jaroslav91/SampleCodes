using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;

namespace SimpleAsyncConsoleApp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var tokenSource = new CancellationTokenSource();
            var cancellationToken = tokenSource.Token;
            int intervalForShowExecutionTime = 3;

            Stopwatch timer = new Stopwatch();

            Console.WriteLine("Fibonacci i async timer");
            Console.WriteLine("Nacisnij dowolny klawisz aby wystartować aplikacje...");
            Console.ReadKey(true);
            Console.WriteLine("Wprowdz znak 'q' aby zakończyć...");

            timer.Start();
            var t = Task.Run(() => ShowExecutionTime(timer, intervalForShowExecutionTime, cancellationToken));

            var cancelTask = Task.Run(() => WaitForUserCancel(tokenSource));

            Console.WriteLine();
            Console.WriteLine("Start Fibonacci");

            foreach (var fib in Fibonaicci())
            {
                await Task.Delay(TimeSpan.FromMilliseconds(500));

                if (cancellationToken.IsCancellationRequested)
                {
                    //Console.WriteLine("Task get fibonacci has been cancelled");
                    //cancellationToken.ThrowIfCancellationRequested();
                    break;
                }

                Console.WriteLine($"{fib}");
            }

            timer.Stop();
            Console.WriteLine("\nZamykanie...");
        }

        private static async Task ShowExecutionTime(Stopwatch timer, int intervalInSeconds, CancellationToken cancellationToken)
        {
            await RunMethodEvery(() => { Console.WriteLine($"Od uruchomienia aplikacji upłyneło: {(int)timer.Elapsed.TotalSeconds} sekund"); }, intervalInSeconds, cancellationToken);
        }
        private static async Task RunMethodEvery(Action method, double seconds, CancellationToken cancellationToken)
        {
            while (true)
            {
                if (cancellationToken.IsCancellationRequested)
                {
                    //Console.WriteLine($"Task show execution time has been cancelled");
                    //cancellationToken.ThrowIfCancellationRequested();
                    return;
                }
                await Task.Delay(TimeSpan.FromSeconds(seconds));
                method();
            }
        }

        private static async Task WaitForUserCancel(CancellationTokenSource cancellationTokenSource)
        {
            await Task.Run(() =>
            {
                while (true)
                {
                    char ch = Console.ReadKey().KeyChar;
                    if (ch == 'Q' || ch == 'q')
                    {
                        cancellationTokenSource.Cancel();
                        //Console.WriteLine("\nTask cancellation requested.");
                        return;
                    }
                }
            });
        }

        public static IEnumerable<long> Fibonaicci()
        {
            long prev = -1;
            long next = 1;
            while (true)
            {
                long sum = prev + next;
                prev = next;
                next = sum;
                yield return sum;
            }
        }
    }
}

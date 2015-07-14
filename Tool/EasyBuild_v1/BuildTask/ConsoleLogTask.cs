namespace BuildTask
{
    using System;
    using Infrastructure.Interface;
    public class ConsoleLogTask : ITask
    {
        public void Run()
        {
            Console.WriteLine("\nThis is only fancy output");
           // System.Threading.Thread.Sleep(1000);
        }
    }
}

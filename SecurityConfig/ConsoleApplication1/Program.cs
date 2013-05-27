using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            //try
            //{
            //    using (DisposeTest d = new DisposeTest())
            //    {
            //        try
            //        {
            //            throw new ApplicationException("twinkle twinkle Lille star");
            //        }
            //        catch (Exception ec)
            //        {
            //            Console.WriteLine(ec.Message);
            //        }
            //    }
            //}
            //catch (ApplicationException ExpAP)
            //{
            //    Console.WriteLine(ExpAP.Message);
            //}
            try
            {
                DisposeTest d = new DisposeTest();
                try
                {

                    throw new ApplicationException("One");

                }
                catch (ApplicationException apEx)
                {
                    Console.WriteLine(apEx.Message);
                }
                finally
                {
                    d.Dispose();
                }
            }
            catch (Exception sss)
            {
                Console.WriteLine(sss.Message);
            }
            Console.ReadKey();
        }
    }
    class DisposeTest : IDisposable
    {
        public void Dispose()
        {
            throw new ApplicationException("ba ba Black sheep..");
        }
    }
}

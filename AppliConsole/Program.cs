using System;
using System.Resources;
using System.Reflection;
using System.Threading;
using System.Globalization;

namespace AppliConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            ResourceManager rm = new ResourceManager("AppliConsole.Resources.Strings",
                Assembly.GetExecutingAssembly());

            Console.WriteLine("Veuillez choisir la langue.");
            Console.WriteLine("1 : Français, 2 : English");
            string value = Console.ReadLine();
            if (value == "1")
            {
            Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("fr-FR");
            Console.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);
            Console.WriteLine(rm.GetString("TestFR"));
            Console.ReadLine();
            }
            if (value == "2")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Console.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);
                Console.WriteLine(rm.GetString("TestEN"));
                Console.ReadLine();
            }
            //Console.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);
            
            //Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
            //Console.WriteLine(Thread.CurrentThread.CurrentUICulture.Name);
            //Console.WriteLine(rm.GetString("Welcome"));

            //Controller controller = new Controller();
        }
    }
}

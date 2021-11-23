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
                Console.WriteLine(rm.GetString("SelectFR"));
                Controller controller = new Controller();
            }
            if (value == "2")
            {
                Thread.CurrentThread.CurrentUICulture = CultureInfo.CreateSpecificCulture("en-US");
                Console.WriteLine(rm.GetString("SelectEN"));
                Controller controller = new Controller();
            }
            else if (value != "1" | value != "2")
            {
                Console.WriteLine("Erreur, la langue sélectionnée n'est pas valide.");
                Console.WriteLine("Fin du programme.");
            }
        }
    }
}

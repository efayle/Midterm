using System;
using NLog.Web;
using System.IO;

namespace Midterm
{
    class Program
    {
        private static NLog.Logger logger = NLogBuilder.ConfigureNLog(Directory.GetCurrentDirectory() + "\\nlog.config").GetCurrentClassLogger();
        static void Main(string[] args)
        {
            logger.Info("Program started");

            string userChoice;
            do {
                Console.WriteLine("1.) Display all tickets\n2.) Create a ticket\n3.) Exit");
                userChoice = Console.ReadLine();

                if (userChoice == "1") {
                    Console.WriteLine("Display all tickets");
                } else if (userChoice == "2") {
                    Console.WriteLine("Create a ticket");

                    string userOption;
                    do {
                        Console.WriteLine("What type of ticket are you creating?");
                        Console.WriteLine("1.) Bug/Defect\n2.) Enhancement\n3.) Task\n4.) Exit");
                        userOption = Console.ReadLine();

                        if (userOption == "1") {
                            Console.WriteLine("Bug/Defect");
                        } else if (userOption == "2") {
                            Console.WriteLine("Enhancement");
                        } else if (userOption == "3") {
                            Console.WriteLine("Task");
                        }
                    } while (userOption == "1" || userOption == "2" || userOption == "3");
                }
          } while (userChoice == "1" || userChoice == "2");

            logger.Info("Program ended");
        }
    }
}

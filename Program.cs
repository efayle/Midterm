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
            string ticketFilePath = Directory.GetCurrentDirectory() + "\\Tickets.csv";
            TicketFile ticketFile = new TicketFile(ticketFilePath);

            logger.Info("Program started");

            string userChoice;
            do {
                Console.WriteLine("1.) Display all tickets\n2.) Create a ticket\n3.) Exit");
                userChoice = Console.ReadLine();

                if (userChoice == "1") {
                    foreach (System s in ticketFile.Systems) {
                        Console.WriteLine(s.Display());
                    }
                } else if (userChoice == "2") {
                    Console.WriteLine("Create a ticket");

                    string userOption;
                    do {
                        Console.WriteLine("What type of ticket are you creating?");
                        Console.WriteLine("1.) Bug/Defect\n2.) Enhancement\n3.) Task\n4.) Exit");
                        userOption = Console.ReadLine();

                        if (userOption == "1") {
                            //add ticket
                            Tickets tickets = new Tickets();

                            //ask user 
                            Console.WriteLine("Bug/Defect");
                            Console.WriteLine("Enter the following");

                            Console.WriteLine("ID:");
                            tickets.ID = Convert.ToInt32(Console.ReadLine());
                            Console.WriteLine("Summary:");
                            tickets.summary = Console.ReadLine();

                            Console.WriteLine("Status:");
                            tickets.status = Console.ReadLine();

                            Console.WriteLine("Priority:");
                            tickets.priority = Console.ReadLine();

                            Console.WriteLine("Submitter:");
                            tickets.submitter = Console.ReadLine();

                            Console.WriteLine("Assigner:");
                            tickets.assigner = Console.ReadLine();

                            string watchers;
                            do {
                                Console.WriteLine("Watchers (Enter 'done' when fininshed)");
                                watchers = Console.ReadLine();

                                if (watchers != "done" && watchers.Length > 0) {
                                    tickets.watchers.Add(watchers);
                                } else if (tickets.watchers.Count == 0) {
                                    tickets.watchers.Add("(No watchers listed)");
                                }

                            } while (watchers != "done");

                            Console.WriteLine("Severity:");
                            tickets.severity = Console.ReadLine();

                            //add ticket
                            ticketFile.AddTicket(tickets);
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

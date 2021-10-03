using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class Controller
    {

        private static UserView view = new UserView();
        public static void programRun()
        {
            Console.Clear();

            List<Ticket> ticketList = new List<Ticket>();

            //////////////////////////////
            //      NLOG Instantiation  //
            //////////////////////////////

            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            logger.Info("NLOG Loaded");

            //////////////////////////////
            //       Create File        //
            //////////////////////////////

            string file = "Tickets.csv";  // File Name For Streamreader and Streamwriter

            List<string> fileContents = new List<string>();

            fileContents = FileReader.getFileContents(file);

            if(fileContents == null)
            {
                logger.Warn("File does not exists. {file}", file);
            }            

            //////////////////////////////
            //       Map Tickets        //
            //////////////////////////////

            if(fileContents != null)
            {
                ticketList = TicketMapper.mapTicketListFromCSV(fileContents);
            }            

            //////////////////////////////
            //        Create Menu       //
            //////////////////////////////

            List<string> menuOptions = new List<string>();
            menuOptions.Add("1: To Create A New Ticket");
            menuOptions.Add("2: To View All Current Tickets");
            menuOptions.Add("3: Save Tickets To File And End The Program");

            view.SetMenuOptions(menuOptions);

            view.showWelcome();
            mainLoop(menuOptions, ticketList);

            System.Console.WriteLine("");

            //////////////////////////////
            //    Display Ticket List   //
            //////////////////////////////

            view.displayFormattedTicketList(ticketList);


        
        //*********************************//
        }

        private static void mainLoop(List<string> menuOptions, List<Ticket> ticketList)
        {
            int exit = menuOptions.Count;
            int choice = -1;
            while(choice != exit)
            {
                view.displayMenuOptions();
                choice = getUserChoice(menuOptions);

                if(choice == 2)
                {
                    view.displayFormattedTicketList(ticketList);
                }
            }
            
        }

        private static int getUserChoice(List<string> menuOptions)
        {
            //////////////////////////////
            //      NLOG Instantiation  //
            //////////////////////////////

            string path = Directory.GetCurrentDirectory() + "\\nlog.config";

            // create instance of Logger
            var logger = NLog.Web.NLogBuilder.ConfigureNLog(path).GetCurrentClassLogger();

            int userChoice = 0;
            int max = menuOptions.Count;
            bool validInput = false;

            string optionNotFoundMessage = "Option Not Found!";

            while(!validInput)
                {
                    try
                    {
                        userChoice = int.Parse(Console.ReadLine());

                        if(userChoice<=0)
                        {
                            logger.Error("Please Enter A Value Greater Than 0");
                        }
                        else if(userChoice>max)
                        {
                            logger.Error(optionNotFoundMessage);
                        }
                        else
                        {
                            validInput = true;
                            System.Console.WriteLine("User Input Accepted");
                        }
                        
                    }
                    catch
                    {
                        logger.Error("Not Valid Input");
                    }
                }

            System.Console.WriteLine("{0} Chosen", userChoice);
            return userChoice;
        }
        
    }
}
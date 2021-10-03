using System;
using System.Collections.Generic;
using System.Collections;
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
            menuOptions.Add("3: End The Program");

            view.SetMenuOptions(menuOptions);

            view.showWelcome();
            mainLoop(menuOptions, ticketList, file);

            System.Console.WriteLine("");       
        }

        private static void mainLoop(List<string> menuOptions, List<Ticket> ticketList, string file)
        {
            int exit = menuOptions.Count;
            int choice = -1;
            Ticket tempTicket = new Ticket();
            string csv = "";
            StreamWriter sw;

            while(choice != exit)
            {
                view.displayMenuOptions();
                choice = getUserChoice(menuOptions);


                if(choice == 1)
                {
                    tempTicket = enterTicket(ticketList); 
                    ticketList.Add(tempTicket);                 
                    csv = TicketMapper.mapTicketToCSV(tempTicket);
                    
                    sw = File.AppendText(file);                      
                    sw.WriteLine(csv);                    
                    sw.Close(); // Saves the file   
                }
                if(choice == 2)
                {
                    view.displayFormattedTicketList(ticketList);
                }
            }            
        }

        private static Ticket enterTicket(List<Ticket> ticketList)
        {
            Ticket ticket = new Ticket();
            ticket.ticketId = TicketMapper.genNewTicketId(ticketList);
            string property;
            bool doneWatchNames = true;
            string flag = "!DONE";
            string flagInQuotes = "'" + flag + "'";
            ArrayList watchers = new ArrayList();
            
            for(int i = 2; i<8; i++)
            {
                view.showTicketCreationPrompt(i);
                property = Console.ReadLine();
                if(i==2){ticket.summary        = property;}                
                else if(i==3){ticket.status    = property;}                
                else if(i==4){ticket.priority  = property;}                
                else if(i==5){ticket.submitter = property;}                
                else if(i==6){ticket.assigned  = property;}             
                else if(i==7)
                {
                    doneWatchNames = true;
                    int watchingFlag = -1;
                    view.showTicketCreationPrompt(watchingFlag);
                    // Until the user types the escape phrase, they can enter as many names to the watchlist as they desire

                    watchers.Add(property);
                    
                    while(doneWatchNames)
                    {
                        property = Console.ReadLine();
                        if(property.ToUpper()==flag || property.ToUpper()==flagInQuotes)
                        {
                            doneWatchNames = false;   
                        }
                        else
                        {
                            watchers.Add(property);
                        }                        
                    }
                    ticket.watching = watchers.ToArray(typeof(string)) as string[];
                    
                }             
            }

            return ticket;
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
                        }
                        
                    }
                    catch
                    {
                        logger.Error("Not Valid Input");
                    }
                }            
            return userChoice;
        }
        
    }
}
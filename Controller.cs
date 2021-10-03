using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class Controller
    {

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

            UserView view = new UserView();

            view.initMenuOptions();

            view.showWelcome();
            view.displayMenuOptions();

            System.Console.WriteLine("");

            //////////////////////////////
            //    Display Ticket List   //
            //////////////////////////////

            view.displayFormattedTicketList(ticketList);


        
        //*********************************//
        }
        
    }
}
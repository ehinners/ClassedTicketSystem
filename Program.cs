using System;
using System.IO;
using NLog.Web;
using System.Linq;
using System.Collections.Generic;

namespace ClassedTicketSystem
{
    class Program
    {
        static void Main(string[] args)
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
            //        Create Menu       //
            //////////////////////////////

            UserView view = new UserView();

            view.initMenuOptions();

            view.showWelcome();
            view.displayMenuOptions();

            System.Console.WriteLine("New Line");

            //////////////////////////////
            //       Map Tickets        //
            //////////////////////////////

            if(fileContents != null)
            {
                ticketList = TicketMapper.mapTicketListFromCSV(fileContents);
            }            

            //////////////////////////////
            //    Display Ticket List   //
            //////////////////////////////

            foreach(Ticket t in ticketList)
            {
                t.formattedDisplay();
            }


        
        //*********************************//
        }
    }
}

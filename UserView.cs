using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class UserView
    {
        private List<string> menuOptions = new List<string>();
        private string welcome = "Welcome To Pewaukee Ticketing"; // Holds a value used for an introduction prompt

        public void showWelcome()
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine(welcome);
            Console.WriteLine("=============================");
        }
        public void initMenuOptions()
        {
            menuOptions.Add("Please Enter:");
            menuOptions.Add("1: To Create A New Ticket");
            menuOptions.Add("2: To View All Current Tickets");
            menuOptions.Add("3: Save Tickets To File And End The Program");
        }

        public void SetMenuOptions(List<string> mo)
        {
            menuOptions = mo;
        }

        public void displayMenuOptions()
        {
            foreach(string s in menuOptions)
            {
                System.Console.WriteLine(s);
            }
        }

        public void formattedTicketDisplay(Ticket t)
        {
            System.Console.WriteLine($"{t.ticketId,-6}{t.summary,-40}{t.status,-20}{t.priority,-20}{t.submitter,-20}{t.assigned,-20}");
            System.Console.Write("-----------------------------------------------------------------");
            System.Console.WriteLine("-------------------------------------------------------------");
            System.Console.Write("{0,-16}","Watchers: ");
            foreach(string watcher in t.watching)
            {
                System.Console.Write("{0, -16}",watcher);
            }
            System.Console.WriteLine();
        }

        public void displayFormattedTicketList(List<Ticket> ticketList)
        {
            Console.Clear();

            System.Console.WriteLine("\n\n\n\n\n\n\n\n");
            

            System.Console.Write("/////////////////////////////////////////////////////////////////");
            System.Console.WriteLine("/////////////////////////////////////////////////////////////");
            
            System.Console.WriteLine($"{"Id",-6}{"Summary",-40}{"Status",-20}{"Priority",-20}{"Submitter",-20}{"Assigned",-20}");
            System.Console.Write("/////////////////////////////////////////////////////////////////");
            System.Console.WriteLine("/////////////////////////////////////////////////////////////");
            
            
            foreach(Ticket t in ticketList)
            {
                formattedTicketDisplay(t);
                System.Console.Write("=================================================================");
                System.Console.WriteLine("=============================================================");
            }
        }
    }
}

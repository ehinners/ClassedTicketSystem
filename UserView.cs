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

        private string prompt = "Please Enter:";

        private static string aG = "Please Enter The";
        private static string a2 = " Summary:";
        private static string a3 = " Status:";
        private static string a4 = " Priority:";
        private static string a5 = " Name Of Who Submitted The Ticket:";
        private static string a6 = " Name Of Who The Ticket Is Assigned To:";
        private static string a7 = "Please Enter Who Is Watching The Ticket: \n (Only One Name At A Time Please)";
        private static string watchersPrompt = "Please Enter Another Name Or '!DONE' To Finish Entering Names:";

        public void showWelcome()
        {
            Console.Clear();
            Console.WriteLine("=============================");
            Console.WriteLine(welcome);
            Console.WriteLine("=============================");
        }

        public void SetMenuOptions(List<string> mo)
        {
            menuOptions = mo;
        }

        public void displayMenuOptions()
        {
            System.Console.WriteLine(prompt);
            foreach(string s in menuOptions)
            {
                System.Console.WriteLine(s);
            }
        }

        public void showTicketCreationPrompt(int attribute)
        {
            if(attribute==1){System.Console.WriteLine();}
            if(attribute==2){System.Console.WriteLine(aG + a2);}
            if(attribute==3){System.Console.WriteLine(aG + a3);}
            if(attribute==4){System.Console.WriteLine(aG + a4);}
            if(attribute==5){System.Console.WriteLine(aG + a5);}
            if(attribute==6){System.Console.WriteLine(aG + a6);}
            if(attribute==7){System.Console.WriteLine(a7);}
            if(attribute==-1){System.Console.WriteLine(watchersPrompt);}
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

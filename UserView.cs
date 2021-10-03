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
    }
}

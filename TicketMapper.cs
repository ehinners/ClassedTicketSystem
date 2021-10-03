using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class TicketMapper
    {
        public static List<Ticket> mapTicketListFromCSV(List<string> fileStrings)
        {
            List<Ticket> ticketList = new List<Ticket>();

            foreach(string line in fileStrings)
            {
                ticketList.Add(mapTicketFromCSV(line));
            }

            return ticketList;
        }
        public static Ticket mapTicketFromCSV(string csv)
        {
            Ticket ticket = new Ticket();
            string[] csvsplit = csv.Split(",");
            string[] watchsplit;

            int ticketAttribute = 1;
            int tempInt = -1;

            foreach(string property in csvsplit)
            {
                if(ticketAttribute == 1)
                {
                    try
                    {
                        tempInt = int.Parse(property);
                    }
                    catch
                    {
                        tempInt = -1;
                    }     
                    ticket.ticketId = tempInt;               
                }
                else if(ticketAttribute==2){ticket.summary   = property;}                
                else if(ticketAttribute==3){ticket.status    = property;}                
                else if(ticketAttribute==4){ticket.priority  = property;}                
                else if(ticketAttribute==5){ticket.submitter = property;}                
                else if(ticketAttribute==6){ticket.assigned  = property;}             
                else if(ticketAttribute==7)
                {
                    watchsplit = property.Split("|");
                    ticket.watching = watchsplit;
                }
                

                ticketAttribute++;
            }
            return ticket;
        }
    }
}

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class TicketMapper
    {

        public static string mapTicketToCSV(Ticket ticket)
        {
            string csv = ticket.ticketId.ToString();
            csv += ",";
            csv += ticket.summary;
            csv += ",";
            csv += ticket.status;
            csv += ",";
            csv += ticket.priority;
            csv += ",";
            csv += ticket.submitter;
            csv += ",";
            csv += ticket.assigned;
            csv += ",";
            csv += ticket.watching[0];
            
            if(ticket.watching.Length> 1)
            {
                for(int i = 1; i< ticket.watching.Length; i++)
                {
                    csv+="|";
                    csv += ticket.watching[i];
                }
            }            

            return csv;
        }
        public static List<Ticket> mapTicketListFromCSV(List<string> fileStrings)
        {
            List<Ticket> ticketList = new List<Ticket>();

            foreach(string line in fileStrings)
            {
                ticketList.Add(mapTicketFromCSV(line));
            }

            return ticketList;
        }

        public static int genNewTicketId(List<Ticket> ticketList)
        {
            int highestId = 0;

            foreach(Ticket t in ticketList)
            {
                if(t.ticketId >= highestId)
                {
                    highestId = t.ticketId + 1;
                }
            }

            return highestId;
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

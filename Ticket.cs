using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class Ticket
    {
        public int ticketId { get; set; }
        public string summary { get; set; }
        public string status { get; set; }
        public string priority { get; set; }
        public string submitter { get; set; }
        public string assigned { get; set; }
        public string[] watching { get; set; }

        public void formattedDisplay()
        {
            System.Console.WriteLine("{0}{1}{2}{3}{4}{5}", ticketId, summary, status, priority, submitter, assigned);
            foreach(string watcher in watching)
            {
                System.Console.Write("{0}",watcher);
            }
            System.Console.WriteLine();
        }

        public string toString()
        {
            string output;
            output = "id: " + ticketId;
            output += " summary:" + summary;
            output += " status: " + status;
            output += " priority: " + priority;
            output += " submitter: " + submitter;
            output += " assigned: " + assigned;

            output += " watchers: ";
            
            foreach(string watcher in watching)
            {
                output += ", ";
                output += watcher;
            }

            return output;
        }
    }
}

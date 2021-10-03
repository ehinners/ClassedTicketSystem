using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class Ticket
    {
        int ticketId;
        string summary;
        string status;
        string priority;
        string submitter;
        string assigned;
        List<string> watching;
    }
}

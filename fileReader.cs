using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using NLog.Web;

namespace ClassedTicketSystem
{
    public class FileReader
    {
        public static List<string> getFileContents(string file)
        {
            List<string> fileContents = new List<string>();

            StreamWriter sw;

            //////////////////////////////
            //    Loading Movie File    //
            //////////////////////////////
            if(File.Exists(file))
            {
                StreamReader sr = new StreamReader(file);                

                while(!sr.EndOfStream)
                {
                    string temp = sr.ReadLine();

                    fileContents.Add(temp);
          
                }
                sr.Close();

                return fileContents;
            }            
            return null;           
        }



    }
}

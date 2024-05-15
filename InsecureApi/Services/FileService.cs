using InsecureApi.Classes;
using InsecureApi.Database;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System;
using System.Collections;

namespace InsecureApi.Services
{
    public class FileService 
    {
        private string serverPath = @"E:\dir\files";

        public string searchFileInOs(string filename)
        {
            string location = Path.Combine(serverPath, filename);
            
            if(File.Exists(location))
            {
                using (StreamReader reader = new StreamReader(location))
                {
                    return reader.ReadToEnd();
                }
            }
            
            return "File not found";
        }

        public void ProcessXmlFile(XmlReader reader)
        {
            while (reader.Read())
            {
                if (reader.Name == "UserId")
                {
                    var userIdStr = reader.ReadElementContentAsString();
                    if (long.TryParse(userIdStr, out string userIdValue))
                    {
                        Console.WriteLine($"An item with the '{userIdValue}' user ID was processed.");
                    }
                    else
                    {
                        Console.WriteLine($"{userIdStr} is not valid 'userID' value.");
                    }
                }
            }
        }
    }
}
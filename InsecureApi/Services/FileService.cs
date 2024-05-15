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
        private string serverPath = @"E:\dir\path";

        public List<string> getUserFiles(string userId)
        {
            List<string> filesList = new List<string>();
            string location = Path.Combine(serverPath, userId);

            string[] files = Directory.GetFiles(location);
            
            foreach (string file in files) 
            {
                int filePosition = file.LastIndexOf('\\');
                string trimmedFile = file.Substring(filePosition + 1);
                filesList.Add(trimmedFile);
            }

            return filesList;
        }

        /*public void ProcessXmlFile(XmlReader reader)
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
        }*/
    }
}
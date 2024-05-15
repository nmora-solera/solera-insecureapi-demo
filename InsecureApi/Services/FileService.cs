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
        public string searchFileInOs(string fileName)
        {
            file = Path.Combine(Path.GetTempPath(), fileName);
            
            if (System.IO.File.Exists(fileName))
            {
                return "File is in server: " + fileName;
            }

            return "File is not in server: " + fileName;
        }
    }
}
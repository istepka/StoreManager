using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StoreManager.Core.Models
{
    public class Logger : ILogger
    {
        private string _logFileName;
        private static string path;
        StreamWriter streamWriter;

        public Logger()
        {
            string date = DateTime.Now.ToString();
            date = date.Replace('/', '-');
            date = date.Replace(' ', '_');
            date = date.Replace(':', ';');
            date = date.Remove(date.Length - 6, 4);

            _logFileName = $"logs_{date}.txt";
            CreateNewFile();
            streamWriter = new StreamWriter(path);
            WriteNewLog("Started programm");
        }

        private void CreateNewFile()
        {
            path = Directory.GetCurrentDirectory();
            int i = path.IndexOf("StoreManagerUI");
            path = path.Substring(0, path.Length - (path.Length - i)) + $"StoreManager.Core\\logs\\{_logFileName}";
            //File.Create(path);
        }



        public void WriteNewLog(string content)
        {
            
            streamWriter.WriteLine(content);
            
        }







    }
}

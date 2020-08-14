using Store.BusinessLogic.Common.Interfaces;
using System;
using System.IO;

namespace Store.BusinessLogic.Common
{
    public class Logger : ILogger
    {
        public void LogFile(string path, string error)
        {
            string docPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, "ErrorLog.txt"), true))
            {
                outputFile.WriteLine($"{DateTime.Now} " + error);
            }
        }
    }
}

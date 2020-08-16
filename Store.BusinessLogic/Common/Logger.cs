using System;
using System.IO;
using Store.BusinessLogic.Common.Interfaces;

namespace Store.BusinessLogic.Common
{
    public class Logger : ILogger
    {
        private readonly string _errorLogFile;

        public Logger()
        {
            _errorLogFile = ErrorFilePath();
        }

        public void LogFile(string errorMessage)
        {
            using (StreamWriter outputFile = new StreamWriter(_errorLogFile, true))
            {
                outputFile.WriteLine($"Error: {DateTime.Now} {Environment.NewLine} {errorMessage}");
            }
        }

        private string ErrorFilePath()
        {
            string folderPath = new FileInfo(Environment.CurrentDirectory).Directory.FullName;
            return folderPath + "/ErrorLog.txt";
        }
    }
}

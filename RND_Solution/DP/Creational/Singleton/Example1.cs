using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace DP.Creational.Singleton
{
    class Example1
    {
        public static void Main1(string[] args)
        {
            //LogManager logManager = new LogManager();  This Code Will give you a error.

            LogManager logManager = LogManager.Instance;
            logManager.WriteLog("First Message Total No of instances is : " + logManager.NoOfInstances);

            LogManager logManager1 = LogManager.Instance;
            logManager1.WriteLog("Second Message Total No of instances is : " + logManager1.NoOfInstances);

            LogManager logManager2 = LogManager.Instance;
            logManager2.WriteLog("Three Message Total No of instances is : " + logManager2.NoOfInstances);

            LogManager logManager3 = LogManager.Instance;
            logManager3.WriteLog("Four Message Total No of instances is : " + logManager3.NoOfInstances);

            LogManager logManager4 = LogManager.Instance;
            logManager4.WriteLog("Five Message Total No of instances is : " + logManager4.NoOfInstances);

            LogManager.Instance.WriteLog("Six Message from LogManager.Instance.WriteLog, Total No of instances is : " + LogManager.Instance.NoOfInstances);
            
        }
    }

    public class LogManager
    {
        private static LogManager _instance;
        private FileStream _fileStream;
        private StreamWriter _streamWriter;
        private static int _numberOfInstance;

        private LogManager() // Constructor as Private
        {
            _fileStream = File.OpenWrite(GetExecutionFolder() + "\\Application.log");
            _streamWriter = new StreamWriter(_fileStream);
        }

        public static LogManager Instance
        {
            get
            {
                if (_instance == null)
                {
                    _numberOfInstance = 1;
                    _instance = new LogManager();
                }
                else
                {
                    _numberOfInstance++;
                }
                return _instance;
            }
        }

        public int NoOfInstances
        {
            get
            {
                return _numberOfInstance;
            }
        }

        public void WriteLog(string message)
        {
            StringBuilder formattedMessage = new StringBuilder();
            formattedMessage.AppendLine("Date: " +
            DateTime.Now.ToString());
            formattedMessage.AppendLine("Message: " + message);
            _streamWriter.WriteLine(formattedMessage.ToString());
            _streamWriter.Flush();
        }

        public string GetExecutionFolder()
        {
            return @"D:\MyWork\RND_Project\DP\Creational\Singleton\";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CheckDomainName
{
    public class Log
    {
        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo"></param>
        public static void WriteLog(string logInfo)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string logfilename = currentPath + DateTime.Today.ToString("yyyyMMdd") + ".log";
            StreamWriter sw = new StreamWriter(logfilename, true);
            sw.WriteLine(DateTime.Now.ToString() + "==" + logInfo);
            sw.Close();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo"></param>
        public static void WriteLog(string fileName, string logInfo)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string logfilename = currentPath + fileName  + ".log";
            StreamWriter sw = new StreamWriter(logfilename, true);
            sw.WriteLine(DateTime.Now.ToString() + "==" + logInfo);
            sw.Close();
        }

        /// <summary>
        /// 写日志
        /// </summary>
        /// <param name="logInfo"></param>
        public static void WriteLogUsed(string logInfo)
        {
            string currentPath = System.AppDomain.CurrentDomain.BaseDirectory;
            string logfilename = currentPath +  "不可用" + ".log";
            StreamWriter sw = new StreamWriter(logfilename, true);
            sw.WriteLine(logInfo);
            sw.Close();
        }
    }
}

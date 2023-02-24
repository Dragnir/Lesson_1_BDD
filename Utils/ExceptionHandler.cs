using System;
using System.IO;
using System.Text;

namespace Lesson_11_BDD.Utils
{
    public class ExceptionHandler
    {
        private static ExceptionHandler instance;
        private static readonly object Lock = new object();
        private StreamWriter StreamWriter;

        public static ExceptionHandler Instance
        {
            get
            {
                lock (Lock)
                {
                    if (instance == null)
                    {
                        instance = new ExceptionHandler();
                    }
                }
                return instance;
            }
        }

        private ExceptionHandler()
        {
            string exePath = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            StreamWriter = new StreamWriter(Path.Combine(exePath, "ExceptionLogs.txt"));
        }

        public void WriteExceptionLog(Exception ex)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(DateTime.Now.ToString("G"));
            sb.Append(": ");
            sb.Append(ex.Message);
            StreamWriter.WriteLine(sb.ToString());
            StreamWriter.Flush();
        }

    }
}

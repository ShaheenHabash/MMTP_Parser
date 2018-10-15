using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTP_Parser.Tools
{
    public static class Config
    {
        public static string _FeederIp = ConfigurationManager.AppSettings["FeederIp"];
        public static string _FeederPort = ConfigurationManager.AppSettings["FeederPort"];

        public static string _AutoRun = ConfigurationManager.AppSettings["AutoRun"];

        public static string _WriteMMTPLogMessageUnReadable = ConfigurationManager.AppSettings["WriteMMTPLogMessageUnReadable"];
        public static string _WriteMMTPLogMessageReadable = ConfigurationManager.AppSettings["WriteMMTPLogMessageReadable"];
        public static string _ReadFromMMTPLogMessage = ConfigurationManager.AppSettings["ReadFromMMTPLogMessage"];
        public static string _MMTPLogMessageName = ConfigurationManager.AppSettings["MMTPLogMessageName"];

        public static string _ProtocoleMode = ConfigurationManager.AppSettings["ProtocoleMode"];
    }
}

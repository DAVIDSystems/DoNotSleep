using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Easy.Logging
{
    public class EasyLog
    {
        private static EasyLog _instance = null;
        private string _filename;
        private string _folder;
        private object _lockObject = null;
        private bool _console = false;
        private int _logLevel;
        private string _lastLogfilename;

        protected EasyLog()
        {
            Assembly asm = Assembly.GetEntryAssembly();
            if (asm == null)
            {
                asm = Assembly.GetExecutingAssembly();
            }

            AssemblyName name = asm.GetName();
            _filename = string.Format("-{0}.log", name.Name);

            if (String.IsNullOrEmpty(_folder))
                _folder = string.Format(@"{0}\{1}\", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), name.Name);


            if (!Directory.Exists(_folder))
            {
                Directory.CreateDirectory(_folder);
            }

            _lockObject = new System.Object();
            _logLevel = (int) Level.Debug;
            _console = true;
        }

        #region public 

        public static string Log(string message, Level level = Level.Info, params object[] arguments)
        {
            string ausgabe = message;
            try
            {
                ausgabe = string.Format(message, arguments);
                ausgabe = Instance().WriteToLog(ausgabe, level);
            }
            catch (Exception)
            {
                ausgabe = Instance().WriteToLog(ausgabe, level);
            }

            return ausgabe;
        }

        public static string LogDebug(string message, params object[] arguments)
        {
            return Log(message, Level.Debug, arguments);
        }

        public static string LogAlways(string message, params object[] arguments)
        {
            return Log(message, Level.Always, arguments);
        }

        public static string LogError(string message, params object[] arguments)
        {
            return Log(message, Level.Error, arguments);
        }

        public static string LogWarning(string message, params object[] arguments)
        {
            return Log(message, Level.Warning, arguments);
        }

        public static string LogInfo(string message, params object[] arguments)
        {
            return Log(message, Level.Info, arguments);
        }

        public static string LogFolder
        {
            get
            {
                return Instance()._folder;
            }

            set
            {
                Instance()._folder = value;
                if (!Directory.Exists(value))
                {
                    Directory.CreateDirectory(value);
                }
            }

        }

        public static bool LogToConsole
        {
            get 
            {
                return Instance()._console;
            }
            set 
            {
                Instance()._console = value;
            }
        }

        public static int LogLevel
        {
            get
            {
                return Instance()._logLevel;
            }
            set
            {
                Instance()._logLevel = value;
            }
        }

        #endregion

        private static EasyLog Instance()
        {
            if (_instance == null)
            {
                _instance = new EasyLog();
            }
            return _instance;
        }

        private string WriteToLog(string message, Level level)
        {
            string ausgabe = "";

            try
            {
                if ((int)level > _logLevel)
                {
                    return message;
                }

                lock (_lockObject)
                {
                    StreamWriter myStream = null;
                    _lastLogfilename = GetLogFilename(DateTime.Now);
                    string prefix = DateTime.Now.ToString("dd.MM.yyyy HH:mm:ss");
                    ausgabe = string.Format("{0} : {1} : {2}", prefix, level.ToString().Substring(0, 1), message);

                    using (myStream = new StreamWriter(_lastLogfilename, true))
                    {
                            myStream.WriteLine(ausgabe);
                    }
                }

                if (_console)
                {
                    Console.WriteLine(ausgabe);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in WriteToLog: " + ex.Message);
            }

            return ausgabe;
        }

        private string GetLogFilename(DateTime dtNow)
        {
            string sLogFilename = _folder + string.Format("{0:D2}{1:D2}{2:D2}{3}", (dtNow.Year - 2000), dtNow.Month, dtNow.Day, _filename);
            return sLogFilename;
        }
    }

    public enum Level
    {
        Always,
        Error,
        Warning,
        Info,
        Debug
    }

}

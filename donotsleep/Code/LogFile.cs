using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Reflection;
using System.Diagnostics;

namespace DAVIDSystems.Helper
{
    public class Logfile
    {
        private static Logfile instance = null;
        private string m_filename;
        private string m_folder;

        protected Logfile()
        {
            Assembly asm = Assembly.GetExecutingAssembly();
            AssemblyName name = asm.GetName();
            m_filename = string.Format("{0}.log", name.Name);
         
            if(String.IsNullOrEmpty(m_folder))
                m_folder = string.Format(@"{0}\DigaSystem\{1}\", Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData), name.Name);
            
            
            if (!Directory.Exists(m_folder))
            {
                Directory.CreateDirectory(m_folder);
            }
        }

        public static Logfile Instance()
        {
            if (instance == null)
            {
                instance = new Logfile();
            }
            return instance;
        }

        public void WriteToLog(string sText, string Table)
        {
            try
            {
                DateTime dtNow = DateTime.Now;
                string prefix = dtNow.ToString("dd.MM.yyyy HH:mm:ss");
                StreamWriter myStream = null;
                string sLogFilename = m_folder + string.Format("{4}{0:D2}{1:D2}{2:D2}{3}", (dtNow.Year - 2000), dtNow.Month, dtNow.Day, m_filename,Table);
                using (myStream = new StreamWriter(sLogFilename, true))
                {
                    myStream.WriteLine(string.Format("{0} : {1}", prefix, sText));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in WriteToLog: " + ex.Message);
            }
        }

        public void WriteToLog(string sText)
        {
            try
            {
                DateTime dtNow = DateTime.Now;
                string prefix = dtNow.ToString("dd.MM.yyyy HH:mm:ss");
                StreamWriter myStream = null;
                string sLogFilename = m_folder + string.Format("{0:D2}{1:D2}{2:D2}{3}", (dtNow.Year - 2000), dtNow.Month, dtNow.Day, m_filename);
                using (myStream = new StreamWriter(sLogFilename, true))
                {
                    string ausgabe = string.Format("{0} : {1}", prefix, sText);
                    myStream.WriteLine(ausgabe);
#if DEBUG
                    Debug.WriteLine(ausgabe);
#endif
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception in WriteToLog: " + ex.Message);
            }
        }

        public void SetLogFolder(string folder)
        {
            m_folder = folder;

            if (!Directory.Exists(m_folder))
            {
                Directory.CreateDirectory(m_folder);
            }
        }

    }
}

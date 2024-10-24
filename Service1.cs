using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;

namespace FileFolderService
{
    public partial class Service1 : ServiceBase
    {
        public Service1()
        {
            InitializeComponent();
        }

        protected override void OnStart(string[] args)
        {
            string path = "C:\\FileFolderService";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = "C:\\FileFolderService\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = AppDomain.CurrentDomain.BaseDirectory + "\\Logs";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = AppDomain.CurrentDomain.BaseDirectory + "\\Folder1";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
            path = AppDomain.CurrentDomain.BaseDirectory + "\\Folder2";
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }
        }

        protected override void OnStop()
        {
        }

        protected void WriteLogFile(string Message="Logging started.")
        {
            string filepath = "C:\\FileFolderService\\Logs\\ServiceLog_" + DateTime.Now.Date.ToShortDateString().Replace('/', '_') + ".txt";
            if (!File.Exists(filepath))
            {
                // Create a file to write to.
                using (StreamWriter sw = File.CreateText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
            else
            {
                using (StreamWriter sw = File.AppendText(filepath))
                {
                    sw.WriteLine(Message);
                }
            }
        }
    }
}

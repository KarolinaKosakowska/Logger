using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FileLogger
{
    public class Logger
    {
        protected readonly string fileName;
        protected static string directory = System.Configuration.ConfigurationManager.AppSettings["dir"];

        public Logger()
        {
            setDirectory();
        }

        public Logger(string fileName)
        {
            this.fileName = fileName;
            setDirectory();
        }

        public virtual void Log(string text)
        {
            try
            {
                CreateDirectory();
                File.AppendAllText(Path.Combine(directory, fileName),
                   $"{Environment.NewLine} Data: {DateTime.Now.ToShortDateString()} Info: {text}");
            }
            catch (Exception ex)
            {
                Log(ex);
            }
        }

        public virtual void Log(Exception message)
        {
            CreateDirectory();
            File.AppendAllText(Path.Combine(directory,fileName),
               $"{Environment.NewLine} Data: {DateTime.Now.ToShortDateString()} Error: {message}");
        }

        private static void CreateDirectory()
        {
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
        }

        private void setDirectory()
        {
            try
            {
                directory = System.Configuration.ConfigurationManager.AppSettings["dir"];
            }
            catch (FileNotFoundException fnfe)
            {
                Log(fnfe);
            }
            catch (Exception ex)
            {
                Log(ex);
                throw;
            }
        }
    }
}

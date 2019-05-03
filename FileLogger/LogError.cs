using System;

namespace FileLogger
{
    public class LogError : Logger
    {
        public LogError(string fileName): base (fileName)
        {

        }
        public override void Log(Exception message)
        {
            base.Log(message);
        }
    }
}



using System;

namespace FileLogger
{
    public class LogInfo : Logger
    {
        public LogInfo(string fileName) :base(fileName)
        {

        }
        public override void Log(string text)
        {
            base.Log(text);
        }

    }
}
















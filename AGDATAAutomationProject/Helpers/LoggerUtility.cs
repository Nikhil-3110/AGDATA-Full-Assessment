using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Helpers
{
    public class LoggerUtility
    {
        /// <summary>
        /// Method to write text to text file
        /// </summary>
        /// <param name="path">string : filepath of text file</param>
        /// <param name="log">string : text to write</param>
        public void WriteToText(string path, string log)
        {
            try
            {
                if (!File.Exists(path))
                {
                    // Create a file to write to.
                    using (StreamWriter sw = File.CreateText(path))
                    {
                        sw.WriteLine(log);

                    }
                }
                else
                    // if it is not deleted.
                    using (StreamWriter sw = File.AppendText(path))
                    {
                        sw.WriteLine(log);
                    }
            }
            catch (Exception ex)
            {

                ExtentLogger.LogError(ex.StackTrace);
            }
        }
    }
}

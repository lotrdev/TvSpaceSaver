using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using TvLibrary.Log;

namespace TvEngine
{
    /// <summary>
    /// Provides ability to launch Windows processes and redirect output
    /// </summary>
    class ProcessLauncher
    {
        /// <summary>
        /// Launch a process with supplied parameters and save the output to a log file if it is supplied.
        /// </summary>
        /// <param name="fileName">The process' file name</param>
        /// <param name="arguments">The process' arguments</param>
        /// <param name="workingDirectory">The working directory of the process</param>
        /// <param name="logFile">Full path to a log file for standard output and standard error</param>
        /// <returns>The process' exit code</returns>
        public int LaunchProcess(string fileName, string arguments, string workingDirectory, string logFile = "")
        {
            Process process = new Process();
            StringBuilder allOutput = new StringBuilder("");

            try
            {
                // Initialize process settings
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.Arguments = arguments;
                process.StartInfo.FileName = fileName;
                process.StartInfo.WindowStyle = ProcessWindowStyle.Normal;
                process.StartInfo.WorkingDirectory = workingDirectory;
                
                // If a logfile is supplied redirect standard output and standard error
                if (logFile != "")
                {
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.RedirectStandardError = true;

                    // Set an event method for DataReceived, pass in allOutput variable
                    process.OutputDataReceived += new DataReceivedEventHandler((s, e) => OutputHandler(s, e, allOutput));
                    process.ErrorDataReceived += new DataReceivedEventHandler((s,e)=> OutputHandler(s, e, allOutput));
                }

                process.Start();

                // Asynchronously read standard output and standard error
                if (logFile != "")
                {
                    process.BeginOutputReadLine();
                    process.BeginErrorReadLine();
                }

                process.WaitForExit();
            }
            catch (Exception ex)
            {
                // Write any errors to both the MediaPortal log and to the individual process' log
                Log.Error("TvSpaceSaver - LaunchProcess(): {0}", ex.Message);
                if (logFile != "") allOutput.Append(ex.Message);
            }
            finally
            {
                // Always write all output to the logfile if supplied
                if (logFile != "") File.WriteAllText(logFile, allOutput.ToString());
            }

            return process.ExitCode;
        }

        /// <summary>
        /// Method for for handling a DataReceivedEvent for either Standard Output or Standard Error.
        /// The method takes a StringBuilder and appends the current data value to it.
        /// </summary>
        /// <param name="sendingProcess"></param>
        /// <param name="outLine"></param>
        /// <param name="output"></param>
        private void OutputHandler(object sendingProcess, DataReceivedEventArgs outLine, StringBuilder output)
        {
            // Collect the sort command output.
            if (!String.IsNullOrEmpty(outLine.Data))
            {
                // Add the text to the collected output.
                output.Append(outLine.Data + Environment.NewLine);
            }
        }
    }
}

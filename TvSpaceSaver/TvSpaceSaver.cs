using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.IO;
using SetupTv;
using TvLibrary.Log;
using TvLibrary.Interfaces;
using TvEngine.Events;
using TvControl;
using TvDatabase;

namespace TvEngine
{
    public class TvSpaceSaver : ITvServerPlugin
    {
        #region Constants

        private const bool DefaultImmideately = true;
        private const bool DefaultRunInHours = false;
        private const int DefaultNumberOfHours = 3;
        private const string DefaultProgram = "C:\\Program Files\\Handbrake\\Handbrake.exe";
        private const string DefaultParameters = "";//"\"{0}\"";

        #endregion Constants

        #region Members

        private static bool _immediately = DefaultImmideately;
        private static bool _runInHours = DefaultRunInHours;
        private static int _numberOfHours = DefaultNumberOfHours;
        private static string _program = DefaultProgram;
        private static string _parameters = DefaultParameters;

        #endregion Members

        #region Properties

        /// <summary>
        /// returns the name of the plugin
        /// </summary>
        public string Name
        {
            get { return "TvSpaceSaver"; }
        }

        /// <summary>
        /// returns the version of the plugin
        /// </summary>
        public string Version
        {
            get { return "1.0.0.0"; }
        }

        /// <summary>
        /// returns the author of the plugin
        /// </summary>
        public string Author
        {
            get { return "lotrDev"; }
        }

        /// <summary>
        /// returns if the plugin should only run on the master server
        /// or also on slave servers
        /// </summary>
        public bool MasterOnly
        {
            get { return false; }
        }

        internal static bool Immediately
        {
            get { return _immediately; }
            set { _immediately = value; }
        }

        internal static bool RunInHours
        {
            get { return _runInHours; }
            set { _runInHours = value; }
        }

        internal static int NumberOfHours
        {
            get { return _numberOfHours; }
            set { _numberOfHours = value; }
        }

        internal static string CompressionProgram
        {
            get { return _program; }
            set { _program = value; }
        }

        internal static string CompressionParameters
        {
            get { return _parameters; }
            set { _parameters = value; }
        }

        #endregion Properties

        #region IPlugin Members

        [CLSCompliant(false)]
        public void Start(IController controller)
        {
            Log.Info("plugin: TvSpaceSaver start");

            LoadSettings();

            GlobalServiceProvider.Instance.Get<ITvServerEvent>().OnTvServerEvent += TvSpaceSaver_OnTvServerEvent;
        }

        public void Stop()
        {
            Log.Info("plugin: TvSpaceSaver stop");

            if (GlobalServiceProvider.Instance.IsRegistered<ITvServerEvent>())
            {
                GlobalServiceProvider.Instance.Get<ITvServerEvent>().OnTvServerEvent -= TvSpaceSaver_OnTvServerEvent;
            }
        }

        [CLSCompliant(false)]
        public SectionSettings Setup
        {
            get { return new SetupTv.Sections.TvSpaceSaverSetup(); }
        }

        #endregion

        #region Implementation

        private static void TvSpaceSaver_OnTvServerEvent(object sender, EventArgs eventArgs)
        {
            try
            {
                TvServerEventArgs tvEvent = (TvServerEventArgs)eventArgs;

                if (tvEvent.EventType == TvServerEventType.RecordingEnded)
                {
                    Channel channel = Channel.Retrieve(tvEvent.Recording.IdChannel);

                    string parameters = ProcessParameters(_parameters, tvEvent.Recording.FileName, channel.DisplayName);

                    Log.Info("TvSpaceSaver: Recording ended ({0} on {1}), launching program ({2} {3}) ...",
                             tvEvent.Recording.FileName, channel.DisplayName, _program, parameters);

                    LaunchProcess(_program, parameters, Path.GetDirectoryName(_program), ProcessWindowStyle.Hidden);
                }
            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - TvSpaceSaver_OnTvServerEvent(): {0}", ex.Message);
            }
        }

        internal static void LoadSettings()
        {
            try
            {
                TvBusinessLayer layer = new TvBusinessLayer();

                _immediately = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_Immediately", DefaultImmideately.ToString()).Value);
                _runInHours = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_RunInHours", DefaultRunInHours.ToString()).Value);
                _numberOfHours = Convert.ToInt32(layer.GetSetting("TvSpaceSaver_NumberOfHours", DefaultNumberOfHours.ToString()).Value);
                _program = layer.GetSetting("TvSpaceSaver_Program", DefaultProgram).Value;
                _parameters = layer.GetSetting("TvSpaceSaver_Parameters", DefaultParameters).Value;
            }
            catch (Exception ex)
            {
                _program = DefaultProgram;
                _parameters = DefaultParameters;

                Log.Error("TvSpaceSaver - LoadSettings(): {0}", ex.Message);
            }
        }

        internal static void SaveSettings()
        {
            try
            {
                TvBusinessLayer layer = new TvBusinessLayer();

                Setting setting = layer.GetSetting("TvSpaceSaver_Immediately");
                setting.Value = _immediately.ToString();
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_RunInHours");
                setting.Value = _runInHours.ToString();
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_NumberOfHours");
                setting.Value = _numberOfHours.ToString();
                setting.Persist();
                
                setting = layer.GetSetting("TvSpaceSaver_Program");
                setting.Value = _program;
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_Parameters");
                setting.Value = _parameters;
                setting.Persist();
            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - SaveSettings(): {0}", ex.Message);
            }
        }

        internal static string ProcessParameters(string input, string fileName, string channel)
        {
            string output = String.Empty;

            try
            {
                output = string.Format(
                  input, // Format
                  fileName, // {0} = Recorded filename (includes path)
                  Path.GetFileName(fileName), // {1} = Recorded filename (w/o path)
                  Path.GetFileNameWithoutExtension(fileName), // {2} = Recorded filename (w/o path or extension)
                  Path.GetDirectoryName(fileName), // {3} = Recorded file path
                  DateTime.Now.ToShortDateString(), // {4} = Current date
                  DateTime.Now.ToShortTimeString(), // {5} = Current time
                  channel // {6} = Channel name
                  );
            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - ProcessParameters(): {0}", ex.Message);
            }

            return output;
        }

        internal static Process LaunchProcess(string program, string parameters, string workingFolder,
                                           ProcessWindowStyle windowStyle)
        {
            Process process = new Process();

            try
            {
                process.StartInfo = new ProcessStartInfo();
                process.StartInfo.Arguments = parameters;
                process.StartInfo.FileName = program;
                process.StartInfo.WindowStyle = windowStyle;
                process.StartInfo.WorkingDirectory = workingFolder;
                if (OSInfo.OSInfo.VistaOrLater())
                {
                    process.StartInfo.Verb = "runas";
                }

                process.Start();
            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - LaunchProcess(): {0}", ex.Message);
            }

            return process;
        }

        public static void ProcessCommercials(string fileName)
        {
            string cutFile = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + ".cut";

            if (!File.Exists(cutFile))
            {
                Process comSkip = LaunchProcess("ComSkip.exe", "--zpcut \"" + fileName + "\"", Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);

                //Wait for the process to end.
                //comSkip.WaitForInputIdle(); //Only use for GUI programs
                comSkip.WaitForExit();
            }

            if (File.Exists(cutFile))
            {
                List<string> chapters = new List<string>();
                string[] lines = System.IO.File.ReadAllLines(cutFile);

                foreach (string line in lines)
                {
                    // Use a tab to indent each line of the file.
                    int first = line.IndexOf("=") + 1;
                    int last = line.LastIndexOf("=") + 1;
                    string cut1 = line.Substring(first, line.IndexOf("\",") - first);
                    string cut2 = line.Substring(last, line.LastIndexOf("\"") - last);

                    // Cut from beginning if first commercial is within the first second
                    if (Double.Parse(cut1) < 1.0)
                        chapters.Add(ConvertSecondsToTimeCode("0.0000"));
                    else
                        chapters.Add(ConvertSecondsToTimeCode(cut1));


                    chapters.Add(ConvertSecondsToTimeCode(cut2));
                }

                // Create mkvmerge split locations
                string split = " \"--split\" \"parts:";

                int i = 0;
                foreach (string chapter in chapters)
                {
                    if (i == 0 && chapter != ConvertSecondsToTimeCode("0.0000"))
                    {
                        split += ConvertSecondsToTimeCode("0.0000") + "-" + chapter + ",";
                    }
                    else if (i > 0) {
                        split += chapter;

                        if (i % 2 == 0)
                            split += ",";
                        else
                            split += "-";
                    }

                    i++;
                }
                split += "\"";
                string fullParam = " -o output.mkv" + split + " \"" + fileName + "\"";

                LaunchProcess("mkvmerge.exe", fullParam, Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);
            }
            else
            {
                Log.Error("TvSpaceSaver - ComSkip.exe failed to create cut file");
            }
        }

        internal static string FormatTimeSpan(TimeSpan span)
        {
            string retVal = span.ToString();

            if (retVal.LastIndexOf(".") == -1)
            {
                retVal += ".0000000";
            }

            return retVal;
        }

        internal static string ConvertSecondsToTimeCode(string time)
        {
            string[] parts = time.Split('.');
            TimeSpan timeCode = TimeSpan.FromSeconds(int.Parse(parts[0]));
            
            return string.Format("{0:D2}:{1:D2}:{2:D2}:{3}", timeCode.Hours, timeCode.Minutes, timeCode.Seconds, parts[1]);
        }

        #endregion Implementation
    }
}

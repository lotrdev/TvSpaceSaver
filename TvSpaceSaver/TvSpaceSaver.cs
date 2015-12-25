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

        private const bool DefaultManual = true;
        private const bool DefaultImmediately = true;
        private const bool DefaultRunInHours = false;
        private const int DefaultNumberOfHours = 3;
        private const string DefaultCompressProg = "C:\\Program Files\\Handbrake\\HandbrakeCLI.exe";
        private const string DefaultCompressParam = "-i \"{0}\" -e x264 -o \"{3}\\{2}.mkv\"";
        private const string DefaultComSkipProg = "C:\\Program Files (x86)\\ComSkip\\Comskip.exe";
        private const string DefaultComSkipParam = "--zpcut \"{0}\"";
        private const string DefaultMkvMergeProg = "C:\\Program Files\\MKVToolNix\\MkvMerge.exe";
        private const string DefaultMkvPropEditProg = "C:\\Program Files\\MKVToolNix\\MkvPropEdit.exe";
        private const bool DefaultCutCommercials = false;
        private const bool DefaultProcessCommercials = true;

        #endregion Constants

        #region Members

        private static bool _manual = DefaultManual;
        private static bool _immediately = DefaultImmediately;
        private static bool _runInHours = DefaultRunInHours;
        private static int _numberOfHours = DefaultNumberOfHours;
        private static string _compressProg = DefaultCompressProg;
        private static string _compressParam = DefaultCompressParam;
        private static string _comSkipProg = DefaultComSkipProg;
        private static string _comSkipParam = DefaultComSkipParam;
        private static string _mkvMergeProg = DefaultMkvMergeProg;
        private static string _mkvPropEditProg = DefaultMkvPropEditProg;
        private static bool _cutCommercials = DefaultCutCommercials;
        private static bool _processCommercials = DefaultProcessCommercials;

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

        internal static bool Manual
        {
            get { return _manual; }
            set { _manual = value; }
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
            get { return _compressProg; }
            set { _compressProg = value; }
        }

        internal static string CompressionParameters
        {
            get { return _compressParam; }
            set { _compressParam = value; }
        }
        internal static string ComSkipProgram
        {
            get { return _comSkipProg; }
            set { _comSkipProg = value; }
        }

        internal static string ComSkipParameters
        {
            get { return _comSkipParam; }
            set { _comSkipParam = value; }
        }
        internal static bool CutCommercials
        {
            get { return _cutCommercials; }
            set { _cutCommercials = value; }
        }
        internal static bool ProcessCommercials
        {
            get { return _processCommercials; }
            set { _processCommercials = value; }
        }

        #endregion Properties

        #region IPlugin Members
        
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

                    string parameters = ProcessParameters(_compressParam, tvEvent.Recording.FileName, channel.DisplayName, "");

                    Log.Info("TvSpaceSaver: Recording ended ({0} on {1}), launching program ({2} {3}) ...",
                             tvEvent.Recording.FileName, channel.DisplayName, _compressProg, parameters);

                    LaunchProcess(_compressProg, parameters, Path.GetDirectoryName(_compressProg), ProcessWindowStyle.Hidden);
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

                _manual = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_Manual", DefaultManual.ToString()).Value);
                _immediately = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_Immediately", DefaultImmediately.ToString()).Value);
                _runInHours = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_RunInHours", DefaultRunInHours.ToString()).Value);
                _numberOfHours = Convert.ToInt32(layer.GetSetting("TvSpaceSaver_NumberOfHours", DefaultNumberOfHours.ToString()).Value);
                _compressProg = layer.GetSetting("TvSpaceSaver_CompressProg", DefaultCompressProg).Value;
                _compressParam = layer.GetSetting("TvSpaceSaver_CompressParam", DefaultCompressParam).Value;

                _comSkipProg = layer.GetSetting("TvSpaceSaver_ComSkipProg", DefaultCompressProg).Value;
                _comSkipParam = layer.GetSetting("TvSpaceSaver_ComSkipParam", DefaultComSkipParam).Value;
                _cutCommercials = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_CutCommercials", DefaultCutCommercials.ToString()).Value);
                _processCommercials = Convert.ToBoolean(layer.GetSetting("TvSpaceSaver_ProcessCommercials", DefaultProcessCommercials.ToString()).Value);
            }
            catch (Exception ex)
            {
                _compressProg = DefaultCompressProg;
                _compressParam = DefaultCompressParam;

                Log.Error("TvSpaceSaver - LoadSettings(): {0}", ex.Message);
            }
        }

        internal static void SaveSettings()
        {
            try
            {
                TvBusinessLayer layer = new TvBusinessLayer();
                
                Setting setting = layer.GetSetting("TvSpaceSaver_Manual");
                setting.Value = _manual.ToString();
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_Immediately");
                setting.Value = _immediately.ToString();
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_RunInHours");
                setting.Value = _runInHours.ToString();
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_NumberOfHours");
                setting.Value = _numberOfHours.ToString();
                setting.Persist();
                
                setting = layer.GetSetting("TvSpaceSaver_CompressProg");
                setting.Value = _compressProg;
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_CompressParam");
                setting.Value = _compressParam;
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_ComSkipProg");
                setting.Value = _comSkipProg;
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_ComSkipParam");
                setting.Value = _comSkipParam;
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_CutCommercials");
                setting.Value = _cutCommercials.ToString();
                setting.Persist();

                setting = layer.GetSetting("TvSpaceSaver_ProcessCommercials");
                setting.Value = _processCommercials.ToString();
                setting.Persist();
            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - SaveSettings(): {0}", ex.Message);
            }
        }

        internal static string ProcessParameters(string input, string fileName, string channel, string other)
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
                  channel, // {6} = Channel name
                  other // {7} = extra param
                  );
            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - ProcessParameters(): {0}", ex.Message);
            }

            return output;
        }

        internal static int LaunchProcess(string program, string parameters, string workingFolder,
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
                //if (OSInfo.OSInfo.VistaOrLater())
                //{
                //    process.StartInfo.Verb = "runas";
                //}

                process.Start();
                process.WaitForExit();

            }
            catch (Exception ex)
            {
                Log.Error("TvSpaceSaver - LaunchProcess(): {0}", ex.Message);
            }

            return process.ExitCode;
        }

        public static void ProcessRecording(string fileName)
        {
            int result = 0;
            string fullPathWithoutExt = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName);

            // Compress .ts file into a .mkv file
            if (!File.Exists(fullPathWithoutExt + ".mkv"))
            {
                string compressParam = ProcessParameters(_compressParam, fileName, "", "");

                result = LaunchProcess(_compressProg, compressParam, Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);

                if (result != 0)
                {
                    Log.Error("TvSpaceSaver - {0} encountered error: {1}", _compressProg, result);
                    return;
                }
            }

            if (_processCommercials)
            {
                // Use ComSkip to generate .cut file
                if (!File.Exists(fullPathWithoutExt + ".cut"))
                {
                    string comSkipParam = ProcessParameters(_comSkipParam, fileName, "", "");

                    result = LaunchProcess(_comSkipProg, comSkipParam, Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);

                    if (result == 0)
                    {
                        Log.Error("TvSpaceSaver - ComSkip.exe no commercials found.");
                        return;
                    }
                    else if (result != 1)
                    {
                        Log.Error("TvSpaceSaver - {0} encountered error: {1}", _comSkipProg, result);
                        return;
                    }
                }

                // Get commercial start and stop points
                List<string> chapters = ProcessCutFile(fullPathWithoutExt + ".cut");

                // Cut commercials out of the final MKV file
                if (_cutCommercials)
                {
                    string mkvSplitParam = ProcessParameters(" -o \"{3}\\{2}_split.mkv\" {7} \"{3}\\{2}.mkv\"", fileName, "", ProcessSplitParam(chapters));

                    result = LaunchProcess(_mkvMergeProg, mkvSplitParam, Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);

                    if (result == 0)
                    {

                        mkvSplitParam = ProcessParameters(" -o \"{3}\\{2}.mkv\" {7}", fileName, "", ProcessJoinParam(fileName));

                        result = LaunchProcess(_mkvMergeProg, mkvSplitParam, Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);

                        if (result != 0)
                            Log.Error("TvSpaceSaver - {0} encountered error: {1}", _mkvMergeProg, result);

                    }
                    else
                    {
                        Log.Error("TvSpaceSaver - {0} encountered error: {1}", _mkvMergeProg, result);

                    }
                }
                // Set chapter markers based on commercials
                else
                {
                    string chapterFile = Path.GetDirectoryName(fileName) + "\\" + Path.GetFileNameWithoutExtension(fileName) + "_chapters.txt";
                    ProcessChapters(chapters, chapterFile);
                    string mkvParam = ProcessParameters("\"--chapters\" \"{7}\" \"{3}\\{2}.mkv\"", fileName, "", chapterFile);

                    result = LaunchProcess(_mkvPropEditProg, mkvParam, Path.GetDirectoryName(fileName), ProcessWindowStyle.Normal);

                    if (result != 0)
                        Log.Error("TvSpaceSaver - {0} encountered error: {1}", _mkvPropEditProg, result);
                }
            }
        }

        internal static List<string> ProcessCutFile(string fileName)
        {
            List<string> chapters = new List<string>();
            string[] lines = System.IO.File.ReadAllLines(fileName);

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

            return chapters;
        }

        internal static string ProcessSplitParam(List<string> chapters)
        {
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
            return split + "\"";
        }

        internal static string ProcessJoinParam(string fileName)
        {
            string[] files = Directory.GetFiles(Path.GetDirectoryName(fileName), Path.GetFileNameWithoutExtension(fileName) + "_split*.mkv");
            string appendParam = "";
            foreach (string file in files)
            {
                if (file != files[0])
                    appendParam += "+";

                appendParam += "\"" + file + "\" ";
            }

            return appendParam;
        }

        internal static void ProcessChapters(List<string> chapters, string fileName)
        {
            using (StreamWriter outfile = new StreamWriter(fileName))
            {
                int i = 1;
                foreach (string chapter in chapters)
                {
                    outfile.WriteLine("CHAPTER{0:00}={1}", i, chapter);
                    outfile.WriteLine("CHAPTER{0:00}NAME=CHAPTER{0:00}", i);

                    i++;
                }
            }
        }

        internal static string ConvertSecondsToTimeCode(string time)
        {
            string[] parts = time.Split('.');
            TimeSpan timeCode = TimeSpan.FromSeconds(int.Parse(parts[0]));
            
            return string.Format("{0:D2}:{1:D2}:{2:D2}.{3}", timeCode.Hours, timeCode.Minutes, timeCode.Seconds, parts[1]);
        }

        #endregion Implementation
    }
}

using System;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;
using System.Net.Http;
using System.Xml.Linq;
using System.Collections.Generic;

namespace Testy
{
    public partial class MainForm : Form
    {
        bool running = false, autoStart = false, initialStart = false, specialProcessing = false;

        int runCount = 0;

        string configFileName = "config.xml";

        string logFileName = "testy.log";
        StreamWriter logWriter;

        DateTime startTime = DateTime.Now;
        Random random = new Random((int)System.DateTime.Now.Ticks);

        ManualResetEvent[] threadsDone;
        TestContext[] threadContexts;

        List<TestConfig> TestConfigs = new List<TestConfig>();

        int SelectedConfigIndex = 0;

        private TestConfig Config
        {
            get
            {
                if (TestConfigs.Any())
                {
                    return TestConfigs[SelectedConfigIndex];
                }
                else
                {
                    return new TestConfig();
                }
            }
        }

        public MainForm()
        {
            InitializeComponent();

            try
            {
                Application.ThreadException += 
                    new ThreadExceptionEventHandler(Application_ThreadException);

                var assembly = 
                    System.Reflection.Assembly.GetExecutingAssembly();

                this.Text += " - v" + assembly.GetName().Version.Major.ToString() + "." + 
                    assembly.GetName().Version.Minor.ToString() + "." + 
                    assembly.GetName().Version.Build.ToString();

                if (File.Exists("testybg.jpg"))
                {
                    try
                    {
                        this.pictureBoxBackground.ImageLocation = "testybg.jpg";
                        this.pictureBoxBackground.SizeMode = PictureBoxSizeMode.StretchImage;
                        this.pictureBoxBackground.Visible = true;
                    }
                    catch (Exception bgException)
                    {
                        LogStatus("Background Image Exception: " + bgException.Message);
                        this.pictureBoxBackground.Visible = false;
                    }
                }

                if (File.Exists(configFileName))
                {
                    try
                    {
                        // Load all configs from XML
                        TestConfigs = LoadConfig(configFileName);

                        // Populate UI from selected config values
                        ChangeConfig(Config);
                    }
                    catch (Exception ex)
                    {
                        LogException("Load/Change Configs Exception: " + ex.Message);
                    }
                }

                if (specialProcessing)
                {
                    string status = new SpecialProcessing(Log).DoSpecialProcessing();
                    MessageBox.Show(status, "Special Processing Message");
                }

                LogStatus("Initialization Complete");
            }
            catch (Exception ex)
            {
                LogException("MainForm Exception: " + ex.Message);
            }
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            try
            {
                SaveConfig(configFileName);
            }
            catch (Exception ex)
            {
                LogException("SaveConfig Exception: " + ex.Message);
            }
        }

        #region Test Control

        private void buttonStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (running)
                {
                    Log("Stopping Test");

                    running = false;

                    this.panelConfig.Enabled = false;
                    this.buttonStart.Enabled = false;
                    this.comboBoxConfig.Enabled = false;

                    try
                    {
                        // Wait twice as long as the maximum time a web request can take
                        WaitHandle.WaitAll(threadsDone, Config.QueryTimeout * 2); 
                    }
                    catch (Exception ex)
                    {
                        LogException("Thread WaitAll Exception: " + ex.Message);
                    }

                    this.buttonStart.Text = "&Start";
                    this.buttonStart.Enabled = true;
                    this.comboBoxConfig.Enabled = true;
                    this.panelConfig.Enabled = true;
                    this.progressBar1.Value = 0;

                    Log("Stopped Test");
                }
                else
                {
                    this.panelConfig.Enabled = true;

                    if (this.checkBoxLogFile.Checked)
                    {
                        StreamWriter sw;
                        logFileName = DateTime.Now.ToShortDateString()
                            .Replace("/", "_") + "_testy.log";
                        sw = File.CreateText(logFileName);
                        sw.Close();
                    }

                    string startText = "Start Test,URL:" + this.comboBoxURL.Text + ",Runs:" + 
                        this.numericUpDownTestRuns.Value.ToString() + ",EventsThreshhold:" + 
                        this.numericUpDownEventThreshhold.Value.ToString() + ",Sleep:" + 
                        this.numericUpDownSleep.Value.ToString() + ",Threads:" + 
                        this.numericUpDownThreads.Value.ToString();

                    Log(startText);

                    Config.NumberOfTestRuns = (int)this.numericUpDownTestRuns.Value;
                    Config.NumberOfThreads = (int)this.numericUpDownThreads.Value;
                    Config.QueryDelay = (int)this.numericUpDownSleep.Value;
                    Config.EventThreshold = (int)this.numericUpDownEventThreshhold.Value;

                    threadsDone = new ManualResetEvent[Config.NumberOfThreads];
                    threadContexts = new TestContext[Config.NumberOfThreads];

                    startTime = DateTime.Now; 
                    
                    runCount = 0;

                    progressBar1.Minimum = 0;
                    progressBar1.Maximum = (int) this.numericUpDownTestRuns.Value;

                    int chunkSize = (int) progressBar1.Maximum / Config.NumberOfThreads;
                    
                    for (int i = 0; i < Config.NumberOfThreads; i++)
                    {
                        threadsDone[i] = new ManualResetEvent(false);

                        TestContext context = 
                            new TestContext(i, chunkSize, this.comboBoxURL.Text, Config);

                        //TODO: Possibly do away with ThreadPool
                        if (ThreadPool.QueueUserWorkItem(TestThread, context))
                        {
                            running = true;
                            this.buttonStart.Text = "&Stop";

                            Log("Started Test Thread #" +
                                context.ThreadNumber.ToString());
                        }
                        else
                        {
                            Log("Unable to queue worker thread #" +
                                context.ThreadNumber.ToString());
                        }
                    }

                    LogStatus("All Test Threads Started");
                }
            }
            catch (Exception ex)
            {
                LogException("Exception: " + ex.Message);
            }
        }

        private async void TestThread(Object startContext)
        {
            TestContext context = (TestContext)startContext;
            threadContexts[context.ThreadNumber] = context;

            try
            {
                for (int i = 0; i < context.RunCount; i++)
                {
                    if (!running)
                        break;

                    using (var client = 
                        new HttpClient(new HttpClientHandler { AutomaticDecompression = 
                            DecompressionMethods.GZip | DecompressionMethods.Deflate }))
                    {
                        client.BaseAddress = new Uri(context.BaseUrl);
                        //client.Timeout = TimeSpan.FromMilliseconds(5);
                        HttpResponseMessage response = await client.GetAsync("");
                        response.EnsureSuccessStatusCode();

                        string results = response.Content.ReadAsStringAsync().Result;
                        string length = results.Length.ToString();

                        int sleep = random.Next((int)this.numericUpDownSleep.Value);

                        if (i % Config.EventThreshold == 0 || i == 0)
                        {
                            LogEvent("TestRun:" + (i + 1).ToString() + ",Thread:" +
                                context.ThreadNumber.ToString() + ",Slept:" +
                                sleep.ToString() + "," + response.ReasonPhrase + "," +
                                length + " bytes");
                        }

                        if ((int)this.numericUpDownSleep.Value > 0)
                        {
                            Thread.Sleep(sleep);
                        }
                    }

                    runCount++;
                }
            }
            catch (Exception ex)
            {
                LogEvent("TestException: " + ex.Message);
            }

            TimeSpan duration = DateTime.Now - startTime;

            UpdateProgress(context);

            Log("Ending Test Thread #" + context.ThreadNumber.ToString());

            threadsDone[context.ThreadNumber].Set();

            // If this the end of the last thread, update as test complete
            if (context.ThreadNumber >= threadContexts.Length - 1)
            {
                Thread.Sleep(Config.QueryTimeout);  // Delay to allow for the last updates

                Log("Stop Test,Run Count:" + runCount.ToString() + 
                    ",Duration:" + ((int)duration.TotalMinutes).ToString() + " minutes " + 
                    (int)duration.Seconds + " seconds");

                running = false;
                UpdateButton(false);
            }
        }

        #endregion

        #region UI Events

        private void MainForm_Shown(object sender, EventArgs e)
        {
            if (autoStart
                && !initialStart)
            {
                initialStart = true;
                this.buttonStart_Click(this, new EventArgs());
            }
        }

        private void comboBoxConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selected = comboBoxConfig.SelectedIndex;
            if (TestConfigs.Count >= selected)
            {
                SelectedConfigIndex = selected;
                ChangeConfig(TestConfigs[selected]);
            }
        }

        private void checkBoxLogFile_CheckedChanged(object sender, EventArgs e)
        {
            Config.LogEventsToFile = this.checkBoxLogFile.Checked;
        }

        private void checkBoxDisplayEvents_CheckedChanged(object sender, EventArgs e)
        {
            this.labelTop.Visible = this.textBoxEvents.Visible = this.checkBoxShowEvents.Checked;
            this.pictureBoxBackground.Visible = !this.checkBoxShowEvents.Checked;
            Config.ShowEventsGUI = this.checkBoxShowEvents.Checked;
        }

        private void numericUpDownTestRuns_ValueChanged(object sender, EventArgs e)
        {
            Config.NumberOfTestRuns = (int) this.numericUpDownTestRuns.Value;
        }

        private void numericUpDownThreads_ValueChanged(object sender, EventArgs e)
        {
            Config.NumberOfThreads = (int)this.numericUpDownThreads.Value;
        }

        private void numericUpDownSleep_ValueChanged(object sender, EventArgs e)
        {
            Config.QueryDelay = (int)this.numericUpDownSleep.Value;
        }

        private void numericUpDownEventThreshhold_ValueChanged(object sender, EventArgs e)
        {
            Config.EventThreshold = (int)this.numericUpDownEventThreshhold.Value;
        }

        delegate void InvokeUpdateButton(bool running);
        private void UpdateButton(bool running)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new InvokeUpdateButton(UpdateButton), running);
                return;
            }

            if (running)
            {
                this.buttonStart.Text = "&Stop";
            }
            else
            {
                this.buttonStart.Text = "&Start";
            }
        }

        delegate void InvokeUpdateProgress(TestContext context);
        private void UpdateProgress(TestContext context)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new InvokeUpdateProgress(UpdateProgress), context);
                return;
            }

            lock (this.progressBar1)
            {
                this.progressBar1.Value = runCount;
            }
        }

        #endregion

        #region Config

        private void ChangeConfig(TestConfig config)
        {
            // Update combobox list of available test configs
            if (this.comboBoxConfig.Items.Count <= 0)
            {
                foreach (TestConfig c in TestConfigs)
                {
                    this.comboBoxConfig.Items.Add(c.Description);
                }
            }

            this.comboBoxConfig.Text = config.Description;
            this.comboBoxConfig.SelectedIndex = SelectedConfigIndex;
            this.numericUpDownTestRuns.Value = config.NumberOfTestRuns;
            this.numericUpDownThreads.Value = config.NumberOfThreads;
            this.numericUpDownSleep.Value = config.QueryDelay;
            this.numericUpDownEventThreshhold.Value = config.EventThreshold;

            this.checkBoxLogFile.Checked = config.LogEventsToFile;
            this.checkBoxShowEvents.Checked = config.ShowEventsGUI;
            this.pictureBoxBackground.Visible = !config.ShowEventsGUI;

            if (config.TestURLs.Length > 0)
            {
                this.comboBoxURL.Items.Clear();
                string[] urls = config.TestURLs.Split(',');
                foreach (string u in urls)
                    this.comboBoxURL.Items.Add(u.Trim());
                this.comboBoxURL.SelectedIndex = 0;
            }

            LogStatus(config.Description + " Config Loaded");
            this.Refresh();
        }

        public List<TestConfig> LoadConfig(string fileName)
        {
            var doc = XDocument.Load(fileName);

            // Load app config attributes
            var appConfig = 
                doc.Descendants("TestyConfig")

                .Select(config => new 
                {
                    AutoLoadConfig = int.Parse(config.Attribute("AutoLoadConfig").Value),

                    AutoStartTest = (config.Attribute("AutoStartTest").Value)
                        .ToLower() == "true" ? true : false,
                    SpecialProcessing = (config.Attribute("SpecialProcessing").Value)
                        .ToLower() == "true" ? true : false,
                }).SingleOrDefault();

            SelectedConfigIndex = appConfig.AutoLoadConfig;

            autoStart = appConfig.AutoStartTest;
            this.checkBoxAutoStart.Checked = appConfig.AutoStartTest;

            specialProcessing = appConfig.SpecialProcessing;

            // Load test specific config elements
            var testConfigs = 
                doc.Descendants("TestConfigs")

                .Select(testConfig => new TestConfig
                {
                    Version = testConfig.Element("Version").Value,
                    Description = testConfig.Element("Description").Value,

                    NumberOfTestRuns =
                    int.Parse(testConfig.Element("NumberOfTestRuns").Value),
                    NumberOfThreads =
                    int.Parse(testConfig.Element("NumberOfThreads").Value),
                    QueryDelay =
                    int.Parse(testConfig.Element("QueryDelay").Value),
                    QueryTimeout =
                    int.Parse(testConfig.Element("QueryTimeout").Value),
                    EventThreshold =
                    int.Parse(testConfig.Element("EventThreshold").Value),

                    AsyncDownloads = (testConfig.Element("AsyncDownloads").Value)
                    .ToLower() == "true" ? true : false,
                    ShowEventsGUI = (testConfig.Element("ShowEventsGUI").Value)
                    .ToLower() == "true" ? true : false,
                    LoginToADWithDefault = (testConfig.Element("LoginToADWithDefault").Value)
                    .ToLower() == "true" ? true : false,
                    LogEventsToFile = (testConfig.Element("LogEventsToFile").Value)
                    .ToLower() == "true" ? true : false,

                    TestURLs = testConfig.Element("TestURLs").Value,
                });

            return testConfigs.ToList();
        }

        public void SaveConfig(string fileName)
        {
            var doc = XDocument.Load(fileName);

            var root = doc.Root;

            root.SetAttributeValue("AutoLoadConfig", SelectedConfigIndex.ToString());
            root.SetAttributeValue("AutoStartTest", this.checkBoxAutoStart.Checked.ToString());

            var testConfigs = 
                doc.Descendants("TestConfigs");

            foreach (TestConfig config in TestConfigs)
            {
                foreach (var cr in testConfigs)
                {
                    if (cr.Element("Description").Value == config.Description)
                    {
                        cr.SetElementValue("Description", config.Description);

                        cr.SetElementValue("LogEventsToFile", config.LogEventsToFile.ToString());
                        cr.SetElementValue("ShowEventsGUI", config.ShowEventsGUI.ToString());

                        cr.SetElementValue("NumberOfTestRuns", config.NumberOfTestRuns.ToString());
                        cr.SetElementValue("NumberOfThreads", config.NumberOfThreads.ToString());
                        cr.SetElementValue("QueryDelay", config.QueryDelay.ToString());
                        cr.SetElementValue("QueryTimeout", config.QueryTimeout.ToString());
                        cr.SetElementValue("EventThreshold", config.EventThreshold.ToString());
                    }
                }
            }

            doc.Save(fileName);
        }

        #endregion

        #region Logging

        private void WriteLogFile(string text)
        {
            try
            {
                if (this.checkBoxLogFile.Checked)
                {
                    //lock (sw)
                    {
                        logWriter = File.AppendText(logFileName);
                        logWriter.WriteLine(text);
                        logWriter.Close();
                    }
                }
            }
            catch { }
        }

        delegate void InvokeLogEvent(string text);
        private void LogEvent(string text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new InvokeLogEvent(LogEvent), text);
                return;
            }

            try
            {
                string formattedText = DateTime.Now.ToShortDateString() + ":" +
                    DateTime.Now.ToLongTimeString() + "," + text;

                WriteLogFile(formattedText);

                formattedText += "\r\n";

                if (checkBoxShowEvents.Checked)
                {
                    lock (this.textBoxEvents)
                    {
                        this.textBoxEvents.AppendText(formattedText);
                        this.textBoxEvents.SelectionStart = textBoxEvents.Text.Length;
                        this.textBoxEvents.ScrollToCaret();
                    }
                }
            }
            catch { }
        }

        delegate void InvokeLogStatus(string text);
        private void LogStatus(string text)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new InvokeLogStatus(LogStatus), text);
                return;
            }

            lock (this.labelStatus)
            {
                this.labelStatus.Text = text;
            }
        }

        public void Log(string text)
        {
            LogStatus(text);
            LogEvent(text);
        }

        private void LogException(string text)
        {
            Log(text);
        }

        private void Application_ThreadException(object sender, ThreadExceptionEventArgs e)
        {
            LogException("Application_ThreadException: " + e.Exception.Message);
        }

        #endregion
    }
}

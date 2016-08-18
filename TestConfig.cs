using System.IO;

namespace Testy
{
    public class TestConfig
    {
        public string Version { get; set; }
        public string Description { get; set; }

        public bool AsyncDownloads { get; set; }
        public bool ShowEventsGUI { get; set; }

        public bool LoginToADWithDefault { get; set; }
        public bool LogEventsToFile { get; set; }

        public int NumberOfTestRuns { get; set; }
        public int NumberOfThreads { get; set; }
        public int QueryDelay { get; set; }
        public int QueryTimeout { get; set; }
        public int EventThreshold { get; set; }

        public string TestURLs { get; set; }

        public TestConfig()
        {
            Version = "2.0";
            Description = "Default Configuration";

            AsyncDownloads = true;
            ShowEventsGUI = false;

            LoginToADWithDefault = false;
            LogEventsToFile = false;

            NumberOfTestRuns = 1;
            NumberOfThreads = 1;
            QueryDelay = 0;
            QueryTimeout = 5000;
            EventThreshold = 1;

            TestURLs = "http://localhost";
        }

        public override string ToString()
        {
            return Version + "," + Description;
        }

        public void Serialize(string file, TestConfig c)
        {
            var xs = 
                new System.Xml.Serialization.XmlSerializer(c.GetType());

            StreamWriter writer = File.CreateText(file);
            xs.Serialize(writer, c);
            writer.Flush();
            writer.Close();
        }

        public TestConfig Deserialize(string file)
        {
            var xs = 
                new System.Xml.Serialization.XmlSerializer(typeof(TestConfig));

            StreamReader reader = File.OpenText(file);
            TestConfig c = (TestConfig)xs.Deserialize(reader);
            
            reader.Close();
            return c;
        }
    }
}

namespace Testy
{
    public class TestContext
    {
        public int ThreadNumber { get; set; }
        public int RunCount { get; set; }

        public string BaseUrl { get; set; }

        private TestConfig TestyConfig { get; set; }
        
        public TestContext(int threadNumber, int runCount, string baseUrl, 
            TestConfig testyConfig)
        {
            ThreadNumber = threadNumber;
            RunCount = runCount;
            BaseUrl = baseUrl;

            TestyConfig = testyConfig;
        }
    }
}

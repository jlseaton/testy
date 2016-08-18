using System;
using System.IO;

namespace Testy
{
    public class SpecialProcessing
    {
        private bool running = false;
        
        public delegate void InvokeLogStatusAndEvent(string text);
        private InvokeLogStatusAndEvent LogEvent = null;

        public SpecialProcessing(InvokeLogStatusAndEvent logEvent)
        {
            this.LogEvent = logEvent;
        }

        public string DoSpecialProcessing()
        {
            string status = "No Action Taken";

            try
            {
                LogEvent("DoSpecialProcessing Started");

                // Special processing here - NOTE: unused since v1.1

                LogEvent("DoSpecialProcessing Complete");
            }
            catch (Exception ex)
            {
                status = "SpecialProcessing Exception: " + ex.Message;
            }
            
            return status;
        }

        public void StartOrStopMonitoring(bool running)
        {
            this.running = running;
        }

        private string ReadEndTokens(string path, Int64 numberOfTokens, 
            System.Text.Encoding encoding, string tokenSeparator)
        {
            int sizeOfChar = encoding.GetByteCount("\n");
            byte[] buffer = encoding.GetBytes(tokenSeparator);

            try
            {
                using (FileStream fs = new FileStream(path, FileMode.Open,
                    FileAccess.Read, FileShare.Read))
                {
                    Int64 tokenCount = 0;
                    Int64 endPosition = fs.Length / sizeOfChar;

                    for (Int64 position = sizeOfChar; position < endPosition; position += sizeOfChar)
                    {
                        fs.Seek(-position, SeekOrigin.End);
                        fs.Read(buffer, 0, buffer.Length);

                        if (encoding.GetString(buffer) == tokenSeparator)
                        {
                            tokenCount++;
                            if (tokenCount == numberOfTokens)
                            {
                                byte[] returnBuffer = new byte[fs.Length - fs.Position];
                                fs.Read(returnBuffer, 0, returnBuffer.Length);
                                return encoding.GetString(returnBuffer);
                            }
                        }
                    }

                    // handle case where number of tokens in file is less than numberOfTokens 
                    fs.Seek(0, SeekOrigin.Begin);
                    buffer = new byte[fs.Length];
                    fs.Read(buffer, 0, buffer.Length);
                    return encoding.GetString(buffer);
                }
            }
            catch (Exception ex)
            {
                LogEvent("Exception: " + ex.Message);
            }

            return String.Empty;
        }
    }
}

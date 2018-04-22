using System;

namespace BNSBoost.BNSDat
{
    public class ExtractEventListener
    {
        public Action<int> NumberOfFiles;
        public Action ProcessedFile;
    }
}
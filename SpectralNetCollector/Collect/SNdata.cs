using System;

namespace SpectralNetCollector.Collect
{
    public class SNdata : EventArgs
    {
        public DateTime DateStamp { get; set; }
        public string Name { get; set; }
        public SNModule Data { get; set; }

    }
}
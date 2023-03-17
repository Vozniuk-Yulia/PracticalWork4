using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task3
{
    internal class Retry
    {
        public int MaxRetries { get; set; }
        public int InitialDelayMs { get; set; }
        public int MaxDelayMs { get; set; }
        public double RandomizationFactor { get; set; }

        public Retry(int maxRetries, int initialDelayMs, int maxDelayMs, double randomizationFactor)
        {
            MaxRetries = maxRetries;
            InitialDelayMs = initialDelayMs;
            MaxDelayMs = maxDelayMs;
            RandomizationFactor = randomizationFactor;
        }
    }
}

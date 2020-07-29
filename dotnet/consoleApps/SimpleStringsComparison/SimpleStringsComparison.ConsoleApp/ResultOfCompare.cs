using System;
using System.Collections.Generic;

namespace SimpleStringsComparison.ConsoleApp
{
    public class ResultOfCompare
    {
        public bool AreEqual { get; set; }
        public List<Difference> Differences { get; private set; }

        public ResultOfCompare()
        {
            Differences = new List<Difference>();
        }

        internal void AddDifference(Difference difference)
        {
            if (difference == null)
                throw new ArgumentNullException(nameof(difference));

            Differences.Add(difference);
        }
    }
}
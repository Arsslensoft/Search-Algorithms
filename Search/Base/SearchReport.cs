using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Search.Base
{
    public class SearchReport<K> where K : class, IComparable<K>
    {
        public Stopwatch Timer { get; set; }
        public SearchResult<K> Result { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public List<SearchStep<K>> Steps { get; set; }

        public SearchReport()
        {
            Steps = new List<SearchStep<K>>();
            Timer = new Stopwatch();
           
        }

    }
}
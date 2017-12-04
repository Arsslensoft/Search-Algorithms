using System;
using System.Collections.Generic;

namespace Search.Base
{
    public class SearchReport<K> where K : class, IComparable<K>
    {
        public SearchResult<K> Result { get; set; }
        public TimeSpan ElapsedTime { get; set; }
        public List<SearchStep<K>> GraphSteps { get; set; }
        public Queue<KeyValuePair<INode<K>, NodeVisitAction>> Steps { get; set; }

    }
}
using System;
using System.Collections.Generic;

namespace Search.Base
{
    public class SearchResult<K> where K : class, IComparable<K>
    {
        IList<IEdge<K>> path;
        public IList<IEdge<K>> Path { get => path; set => path = value; }

        INode<K> start;
        public INode<K> Start { get => start; set => start = value; }

        INode<K> end;
        public INode<K> End { get => end; set => end = value; }

        public bool Found { get; set; }

        public  int DLSDeph { get; set; }
        public SearchResult(INode<K>  start, INode<K> final = null)
        {
            Found = (final != null);
            this.start = start;
            this.path = new List<IEdge<K>>();
            this.end = final;
        }
    }
}
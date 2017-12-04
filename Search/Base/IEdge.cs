using System;

namespace Search.Base
{
    public interface IEdge<K>
        where K : class, IComparable<K>
    {
        INode<K> Source { get; set; }
        INode<K> Target { get; set; }
        double Cost { get; set; }
    }
}
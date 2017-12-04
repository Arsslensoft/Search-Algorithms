using System;

namespace Search.Base
{
    
    public delegate void NodeVisitEventHandler<K>(INode<K> node) where K : class, IComparable<K>;
}
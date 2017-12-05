using System;

namespace Search.Base
{
    public delegate void NodeVisitActionEventHandler<K>(INode<K> node, string action) where K : class, IComparable<K>;
    public delegate void NodeVisitEventHandler<K>(INode<K> node) where K : class, IComparable<K>;
}
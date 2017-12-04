using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Search
{
    public class BiGraph<K> : BidirectionalGraph<Base.Node<K>, Base.Edge<K>>
         where K : class, IComparable<K>
    {

    }
}

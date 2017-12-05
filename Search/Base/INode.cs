using System;
using System.Collections.Generic;

namespace Search.Base
{
    public interface INode<K>
        where K : class, IComparable<K>
    {
        event NodeVisitEventHandler<K> OnPreVisit;
        event NodeVisitEventHandler<K> OnVisit;
        event NodeVisitEventHandler<K> OnPostVisit;
        event NodeVisitActionEventHandler<K> OnActionVisit;

        K Key { get; set; }
        double Heuristic { get; set; }
        int MaxDepth { get; }

        void LogAction(string action);
        void PreVisit();
        void Visit();
        void PostVisit();
        IList<IEdge<K>> Edges { get; }


    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base.Algorithms
{
    public class IDLS<K> : ISearchAlgorithm<K>
              where K : class, IComparable<K>
    {
        public string Name => "Iterative Depth limited search";
        public event EventHandler OnResetRequired;
        public event NodeVisitEventHandler<K> OnResultFound;

        public string Description => "In computer science, iterative deepening search or more specifically iterative deepening depth-first search (IDS or IDDFS) is a state space/graph search strategy in which a depth-limited version of depth-first search is run repeatedly with increasing depth limits until the goal is found. IDDFS is equivalent to breadth-first search, but uses much less memory; on each iteration, it visits the nodes in the search tree in the same order as depth-first search, but the cumulative order in which nodes are first visited is effectively breadth-first.";

        public void Initialize()
        {
        
        }

        public SearchResult<K> DLS(INode<K> start, K key,int depth)
        {
            start.PreVisit();
            start.Visit();
            if (depth == 0 && start.Key == key)
            {
                start.PostVisit();
                OnResultFound?.Invoke(start);
                SearchResult<K> sr = new SearchResult<K>(start, start);
                return sr;
            }
            else if(depth > 0)
            {
                foreach (var edge in start.Edges)
                {
                    var sres = DLS(edge.Target, key, depth - 1);
                    if (sres.Found)
                    {
                        sres.Path.Insert(0, edge);
                        sres.Start = edge.Source;
                        start.PostVisit();
                        return sres;
                    }
                }
            }

            return new SearchResult<K>(start, null);
        }


        public SearchResult<K> Search(INode<K> root, K key)
        {
            for (int depth = 0; depth < int.MaxValue; depth++)
            {
                OnResetRequired?.Invoke(depth, EventArgs.Empty);
                   var sr = DLS(root, key, depth);
                if (sr.Found)
                {
                    sr.DLSDeph = depth;
                    return sr;
                }
            }
            return new SearchResult<K>(root, null);

        }


    }

}

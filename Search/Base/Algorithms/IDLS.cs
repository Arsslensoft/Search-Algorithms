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
        List<INode<K>> last_iteration_nodes = new List<INode<K>>();
        List<INode<K>> iteration_nodes = new List<INode<K>>();
        public string Description => "In computer science, iterative deepening search or more specifically iterative deepening depth-first search (IDS or IDDFS) is a state space/graph search strategy in which a depth-limited version of depth-first search is run repeatedly with increasing depth limits until the goal is found. IDDFS is equivalent to breadth-first search, but uses much less memory; on each iteration, it visits the nodes in the search tree in the same order as depth-first search, but the cumulative order in which nodes are first visited is effectively breadth-first.";
        private bool logged = false;
        public bool Logged
        {
            get => logged;
            set => logged = value;
        }
        public void Initialize()
        {
        
        }

        public SearchResult<K> DLS(INode<K> start, K key,int depth)
        {
            start.PreVisit();
            start.Visit();
            iteration_nodes.Add(start);
            if (depth == 0 && start.Key == key)
            {
                start.PostVisit();
                OnResultFound?.Invoke(start);
                SearchResult<K> sr = new SearchResult<K>(start, start);
                return sr;
            }
            else if(depth > 0)
            {
                if (logged)
                    start.LogAction("Exploring successors of " + start); // successors
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
                if (logged)
                    root.LogAction("New Interation with max depth=" + depth);
                OnResetRequired?.Invoke(depth, EventArgs.Empty);

                iteration_nodes.Clear();
                   var sr = DLS(root, key, depth);
               // check  infinite loop
                bool is_infinite = false;
                if (iteration_nodes.Count == last_iteration_nodes.Count)
                {
                    is_infinite = true;
                    for (int i = 0; i < iteration_nodes.Count; i++)
                    {
                        if (last_iteration_nodes[i] != iteration_nodes[i])
                        {
                            is_infinite = false;
                            break;

                        }
                    }
                }
                if(is_infinite)
                    break;
                last_iteration_nodes = new List<INode<K>>(iteration_nodes);


                if (sr.Found)
                {
                    sr.DLSDeph = depth;
                    return sr;
                }
            }
            return new SearchResult<K>(root, null);

        }



        public SearchResult<K> DLSClean(INode<K> start, K key, int depth)
        {
            iteration_nodes.Add(start);
            if (depth == 0 && start.Key == key)
            {
                SearchResult<K> sr = new SearchResult<K>(start, start);
                return sr;
            }
            else if (depth > 0)
            {
                foreach (var edge in start.Edges)
                {
                    var sres = DLS(edge.Target, key, depth - 1);
                    if (sres.Found)
                    {
                        sres.Path.Insert(0, edge);
                        sres.Start = edge.Source;
                        return sres;
                    }
                }
            }

            return new SearchResult<K>(start, null);
        }
        public SearchResult<K> SearchClean(INode<K> root, K key)
        {
            for (int depth = 0; depth < int.MaxValue; depth++)
            {
                iteration_nodes.Clear();
                var sr = DLSClean(root, key, depth);
                // check  infinite loop
                bool is_infinite = false;
                if (iteration_nodes.Count == last_iteration_nodes.Count)
                {
                    is_infinite = true;
                    for (int i = 0; i < iteration_nodes.Count; i++)
                    {
                        if (last_iteration_nodes[i] != iteration_nodes[i])
                        {
                            is_infinite = false;
                            break;

                        }
                    }
                }
                if (is_infinite)
                    break;
                last_iteration_nodes = new List<INode<K>>(iteration_nodes);


                if (sr.Found)
                {
                    sr.DLSDeph = depth;
                    return sr;
                }
            }
            return new SearchResult<K>(root, null);

        }
        public double CalculateCost(SearchResult<K> result)
        {
            if (result == null || !result.Found)
                return double.PositiveInfinity;
            else
            {
                double cost = 0;
                foreach (var edge in result.Path)
                    cost += edge.Cost;
                return cost;
            }
        }
    }

}

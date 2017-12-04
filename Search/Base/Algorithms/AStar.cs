using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Search.Base.Algorithms
{
    public class AStar<K> : ISearchAlgorithm<K>
             where K : class, IComparable<K>
    {
        public event EventHandler OnResetRequired;
        public string Name => "A*";
        public string Description => "In computer science, A* (pronounced as \"A star\") is a computer algorithm that is widely used in pathfinding and graph traversal, the process of plotting an efficiently directed path between multiple points, called nodes. It enjoys widespread use due to its performance and accuracy. However, in practical travel-routing systems, it is generally outperformed by algorithms which can pre-process the graph to attain better performance, although other work has found A* to be superior to other approaches.";

        public event NodeVisitEventHandler<K> OnResultFound;


        public void Initialize()
        {
            
        }
        
        void ConstructPath(Dictionary<INode<K>, IEdge<K>> meta, INode<K> state, SearchResult<K> sr)
        {
            
            while(true)
            {
                if (meta.ContainsKey(state))
                {
                    IEdge<K> edge = meta[state];
                    state = edge.Source;
                    sr.Path.Add(edge);
                }
                else
                    break;
            }
           sr.Path = sr.Path.Reverse().ToList();
        }
   
        public SearchResult<K> Search(INode<K> root, K key)
        {
            List<K> visited = new List<K>();
            SimplePriorityQueue<INode<K>, double> queue = new SimplePriorityQueue<INode<K>, double>();
            Dictionary<INode<K>, IEdge<K>> cameFrom = new Dictionary<INode<K>, IEdge<K>>();
            Dictionary<INode<K>, double> g = new Dictionary<INode<K>, double>(); // g(node) from start to node
            Dictionary<INode<K>, double> f = new Dictionary<INode<K>, double>(); // f(n)
            f.Add(root, root.Heuristic); // f(root) = 0 + h(root)
            g.Add(root, 0); // g(root) = 0
            queue.Enqueue(root, root.Heuristic); 
            while (queue.Any())
            {
                var node = queue.Dequeue();             
                node.PreVisit();
                visited.Add(node.Key); // mark as visited
                node.Visit();
                if (node.Key == key) // node is goal
                { 
                    node.PostVisit();
                    OnResultFound?.Invoke(node);
                    SearchResult<K> sr  = new SearchResult<K>(root, node);
                    ConstructPath(cameFrom, node, sr); 
                    return sr;
                }
        
                foreach (var child in node.Edges)
                {
                    if (!g.ContainsKey(child.Target)) g.Add(child.Target, double.PositiveInfinity); // set +infinity as default
                    if (!f.ContainsKey(child.Target)) f.Add(child.Target, double.PositiveInfinity); // set +infinity as default

                    if (!visited.Contains(child.Target.Key) && !queue.Contains(child.Target))
                    {
                        queue.Enqueue(child.Target, double.PositiveInfinity);// Discover a new node, with f(node)=priority = +infinity
                        // The distance from start to a neighbor
                        //the "dist_between" function may vary as per the solution requirements.
                        double tentative_gScore = g[node] + child.Cost;
                        if(g.ContainsKey(child.Target) && g[child.Target] <= tentative_gScore) 
                            continue;

                        // This path is the best until now. Record it!
                        cameFrom.Add(child.Target, child);
                        g[child.Target] = tentative_gScore;
                        f[child.Target] = tentative_gScore + child.Target.Heuristic;
                        queue.UpdatePriority(child.Target, tentative_gScore + child.Target.Heuristic); // update priority queue
                    }                  
                }
                node.PostVisit();
                
            }
            return new SearchResult<K>(root, null) ;
        }

    }
}

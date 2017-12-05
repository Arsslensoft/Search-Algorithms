using Priority_Queue;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base.Algorithms
{
   public class UCS<K> : ISearchAlgorithm<K>
             where K : class, IComparable<K>
    {
        public string Name => "Uniform Cost Search";

        public event EventHandler OnResetRequired;
        public event NodeVisitEventHandler<K> OnResultFound;
        public string Description => "If all the edges in the search graph do not have the same cost then breadth-first search generalizes to uniform-cost search. Instead of expanding nodes in order of their depth from the root, uniform-cost search expands nodes in order of their cost from the root. At each step, the next step n to be expanded is one whose cost g(n) is lowest where g(n) is the sum of the edge costs from the root to node n. The nodes are stored in a priority queue. This algorithm is also known as Dijkstra’s single-source shortest algorithm.";

        public void Initialize()
        {

        }

        void ConstructPath(Dictionary<INode<K>, IEdge<K>> meta, INode<K> state, SearchResult<K> sr)
        {

            while (true)
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
            SimplePriorityQueue <INode<K>, double> queue = new SimplePriorityQueue<INode<K>, double> ();
            List<K> visited = new List<K>();
            Dictionary<INode<K>, IEdge<K>> meta = new Dictionary<INode<K>, IEdge<K>>();
            queue.Enqueue(root, 0);
            while (queue.Any())
            {
                var node_cost = queue.GetPriority(queue.First);
                var node = queue.Dequeue();
                node.PreVisit();
                visited.Add(node.Key); // mark as visited
                node.Visit();

                if (node.Key == key)
                {
                    node.PostVisit();
                    OnResultFound?.Invoke(node);
                    SearchResult<K> sr = new SearchResult<K>(root, node);
                    ConstructPath(meta, node, sr);
                    return sr;
                }

                foreach (var child in node.Edges)
                {
                    if (!visited.Contains(child.Target.Key) && !queue.Contains(child.Target))
                    {
                            meta.Add(child.Target, child);
                            queue.Enqueue(child.Target, child.Cost + node_cost);

                    }
                  else if (queue.Contains(child.Target) && queue.GetPriority(child.Target) > (child.Cost + node_cost))
                    {
                        meta[child.Target] = child;
                        queue.UpdatePriority(child.Target, child.Cost + node_cost);
                     
                    }

                    
                }
                node.PostVisit();

            }
            return new SearchResult<K>(root, null);
        }

 
    }
}

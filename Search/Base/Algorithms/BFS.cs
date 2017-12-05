using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base.Algorithms
{
    public class BFS<K> : ISearchAlgorithm<K>
             where K : class, IComparable<K>
    {
        public event EventHandler OnResetRequired;
        public string Name => "Breadth-first search";

        public string Description => "Breadth-first search (BFS) is an algorithm for traversing or searching tree or graph data structures. It starts at the tree root (or some arbitrary node of a graph, sometimes referred to as a 'search key') and explores the neighbor nodes first, before moving to the next level neighbours.";

        public event NodeVisitEventHandler<K> OnResultFound;

        private bool logged = false;
        public bool Logged
        {
            get => logged;
            set => logged = value;
        }
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
            Queue<INode<K>> queue = new Queue<INode<K>>();
            List<K> visited = new List<K>();
            Dictionary<INode<K>, IEdge<K>> meta = new Dictionary<INode<K>, IEdge<K>>();
            queue.Enqueue(root);
            while (queue.Any())
            {
                var node = queue.Dequeue();
                node.PreVisit();
                visited.Add(node.Key); // mark as visited
                node.Visit();

                if (node.Key == key) // goal found
                { 
                    node.PostVisit();
                    OnResultFound?.Invoke(node);
                    SearchResult<K> sr  = new SearchResult<K>(root, node);
                    ConstructPath(meta, node, sr); 
                    return sr;
                }
                if (logged)
                    node.LogAction("Exploring successors of " + node);
                foreach (var child in node.Edges) // neighbors
                {
                    if (!visited.Contains(child.Target.Key))
                    {
                        if (!queue.Contains(child.Target))
                        {
                            meta.Add(child.Target, child);
                            queue.Enqueue(child.Target);
                            if (logged)
                                node.LogAction("Enqueue " + node);
                        }
                    }                  
                }
                node.PostVisit();
                
            }
            return new SearchResult<K>(root, null) ;
        }
    }
}

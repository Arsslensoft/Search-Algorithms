using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{
    public class BFS<K> : ISearchAlgorithm<K>
             where K : class, IComparable<K>
    {
        public string Name => "Breadth-first search";
        int delay;

        public event NodeVisitEventHandler<K> OnResultFound;

        public int Delay { get => delay; set => delay = value; }

        
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

                if (node.Key == key)
                { 
                    node.PostVisit();
                    OnResultFound?.Invoke(node);
                    SearchResult<K> sr  = new SearchResult<K>(root, node);
                    ConstructPath(meta, node, sr); 
                    return sr;
                }
        
                foreach (var child in node.Edges)
                {
                    if (!visited.Contains(child.Target.Key))
                    {
                        if (!queue.Contains(child.Target))
                        {
                            meta.Add(child.Target, child);
                            queue.Enqueue(child.Target);
                        }
                    }                  
                }
                node.PostVisit();
                
            }
            return new SearchResult<K>(root, null) ;
        }
    }
}

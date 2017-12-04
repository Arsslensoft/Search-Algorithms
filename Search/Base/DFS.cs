using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{/*
    public class DFS<K> : ISearchAlgorithm<K>
              where K : class, IComparable<K>
    {
        List<K> visited = new List<K>();
        public INode<K, V> Search(INode<K, V> node, K key)
        {
            visited.Clear();
            node.PreVisit();
            visited.Add(node.Key); // mark as visited
            node.Visit();
            if (node.Key == key)
            {
                node.PostVisit();
                return node;
            }

            foreach (var child in node.Edges) {
                if (!visited.Contains(child.Target.Key))
                {
                    var result = Search(child.Target, key);
                    if (result != default(INode<K, V>))
                    {
                        node.PostVisit();
                        return result;
                    }
                }
              }
            node.PostVisit();
            return default(INode<K, V>);
        }
    }
*/
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{/*
   public class IDS<K> : ISearchAlgorithm<K>
              where K : class, IComparable<K>
    {
       /// <summary>
        /// Searches tree using BFS but the depth of the search
        /// is limited. Level of root is 0.
        /// </summary>
        /// <param name="root">To start the search</param>
        /// <param name="goal"></param>
        /// <param name="depth">Maximum depth of level to search</param>
        /// <returns>Default of V if key is not found</returns>
        public INode<K,V> DepthLimitedSearch(INode<K, V> root, K goal, int depth)
        {
            root.PreVisit();
            root.Visit();
            if (depth == 0 && root.Key == goal)
            {
                root.PostVisit();
                return root;
            }
            else if (depth > 0)
            {
                foreach (var child in root.Children)
                {
                    var result = DepthLimitedSearch(child, goal, depth - 1);
                    if (result != default(V))
                    {
                        root.PostVisit();
                        return result;
                    }

                }
                root.PostVisit();
                return default(INode<K, V>);
            }
            else
            {
                root.PostVisit();
                return default(INode<K, V>);
            }
        }
        
        public INode<K, V> IterativeDeepeningSearch(INode<K, V> root, K key, int depth)
        {
            for (int currentDepth = 0; currentDepth <= depth; currentDepth++)
            {
                var v = DepthLimitedSearch(root, key, currentDepth);
                if (v != default(INode<K, V>))
                    return v;
                
            }
            return default(INode<K, V>);
        }
        
        public INode<K, V> Search(INode<K, V> root, K key)
        {
            // return IterativeDeepeningSearch(root, key, root.MaxDepth);
            return null;
        }
    }
    */
}

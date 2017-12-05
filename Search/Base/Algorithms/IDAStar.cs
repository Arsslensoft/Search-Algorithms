using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Search.Base.Algorithms
{
    public class IDAStar<K> : ISearchAlgorithm<K>
             where K : class, IComparable<K>
    {
        public event EventHandler OnResetRequired;
        public string Name => "Iterative deepening A*";

        public string Description => "Iterative deepening A* (IDA*) is a graph traversal and path search algorithm that can find the shortest path between a designated start node and any member of a set of goal nodes in a weighted graph. It is a variant of iterative deepening depth-first search that borrows the idea to use a heuristic function to evaluate the remaining cost to get to the goal from the A* search algorithm. Since it is a depth-first search algorithm, its memory usage is lower than in A*, but unlike ordinary iterative deepening search, it concentrates on exploring the most promising nodes and thus does not go to the same depth everywhere in the search tree. Unlike A*, IDA* does not utilize dynamic programming and therefore often ends up exploring the same nodes many times.";
        public event NodeVisitEventHandler<K> OnResultFound;


        public void Initialize()
        {
            
        }


        public double DoSearch(Stack<INode<K>> path, K key, double g, double threshold)
        {
            var node = path.Peek();
            node.PreVisit();
            node.Visit();
            double f = g + node.Heuristic;
            if (f > threshold) // abort search and return threshHold
            {
                node.PostVisit();
                return f;
            } 
            // goal found
            if (node.Key == key)
                return double.NegativeInfinity;

            double min = double.PositiveInfinity;
            foreach (var edge in node.Edges)
            {
                if (!path.Contains(edge.Target))
                {
                    path.Push(edge.Target);
                    var t = DoSearch(path, key, g + edge.Cost, threshold);
                    if(double.IsNegativeInfinity(t))  // goal was found
                        return double.NegativeInfinity;
                    else if (t < min)
                        min = t;

                    path.Pop();
                }
            }

            node.PostVisit();
            return min;
        }

        void ConstructPath(SearchResult<K> result, Stack<INode<K>> path, INode<K> child = null)
        {
            if(!path.Any())
                return;

            var node = path.Pop();
            ConstructPath(result, path, node);
            if (child != null)
            {
                double f = double.PositiveInfinity;
                IEdge<K> selectedEdge = null;
                foreach (var edge in node.Edges.Where(x => x.Target == child))
                    if (f > (edge.Cost + child.Heuristic))
                    {
                        f = (edge.Cost + child.Heuristic);
                        selectedEdge = edge;
                    }
                result.Path.Insert(0, selectedEdge);
            }
        }
        public SearchResult<K> Search(INode<K> root, K key)
        {
            var threshold = root.Heuristic;
            Stack<INode<K>> path = new Stack<INode<K>>();
            path.Push(root);
            while (true)
            {
                var t = DoSearch(path, key, 0, threshold);
                if (double.IsNegativeInfinity(t)) // found
                {
                    OnResultFound?.Invoke(path.Peek());
                    SearchResult<K> sr = new SearchResult<K>(root, path.Peek());
                    ConstructPath(sr, path);
                    return sr;
                }

                if (double.IsPositiveInfinity(t)) // not found
                    break;
                threshold = t;
                OnResetRequired?.Invoke(t, EventArgs.Empty);
            }
            return new SearchResult<K>(root, null) ;
        }

    }
}

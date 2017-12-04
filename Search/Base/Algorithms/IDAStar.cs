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
                    if(t == double.NegativeInfinity)  // goal was found
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
                if (t == double.NegativeInfinity) // found
                {
                    OnResultFound?.Invoke(path.Peek());
                    SearchResult<K> sr = new SearchResult<K>(root, path.Peek());
                    ConstructPath(sr, path);
                    return sr;
                }

                if (t == double.PositiveInfinity) // not found
                    break;
                threshold = t;
                OnResetRequired?.Invoke(t, EventArgs.Empty);
            }
            return new SearchResult<K>(root, null) ;
        }

        public SearchResult<K> SearchWithReport(INode<K> root, K key, SearchReport<K> report)
        {
            throw  new NotImplementedException();
        }
    }
}

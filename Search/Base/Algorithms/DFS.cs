using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base.Algorithms
{
    public class DFS<K> : ISearchAlgorithm<K>
              where K : class, IComparable<K>
    {
        public event EventHandler OnResetRequired;
        public string Name => "Depth-first search";
        public string Description => "Depth-first search (DFS) is an algorithm for traversing or searching tree or graph data structures. One starts at the root (selecting some arbitrary node as the root in the case of a graph) and explores as far as possible along each branch before backtracking.";
        public event NodeVisitEventHandler<K> OnResultFound;

        private bool logged = false;
        public bool Logged
        {
            get => logged;
            set => logged = value;
        }

        List<K> visited = new List<K>();
        public void Initialize()
        {
            visited.Clear();
        }
        public SearchResult<K> Search(INode<K> root, K key)
        {
            root.PreVisit();
            visited.Add(root.Key); // mark as visited
            root.Visit();
            if (root.Key == key)
            {
                root.PostVisit();
                OnResultFound?.Invoke(root);
                SearchResult<K> sr = new SearchResult<K>(root, root);

                return sr;
            }
            if (logged)
                root.LogAction("Exploring successors of " + root); // successors
            foreach (var edge in root.Edges)
            {
                if (!visited.Contains(edge.Target.Key))
                {
                    var sres = Search(edge.Target, key);
                    if (sres.Found)
                    {
                        sres.Path.Insert(0, edge);
                        sres.Start = edge.Source;

                        root.PostVisit();
                        return sres;
                    }
                }
            }

            root.PostVisit();
            return new SearchResult<K>(root, null);

        }
        public SearchResult<K> SearchClean(INode<K> root, K key)
        {
   
            visited.Add(root.Key); // mark as visited
            if (root.Key == key)
            {

                SearchResult<K> sr = new SearchResult<K>(root, root);
                return sr;
            }

            foreach (var edge in root.Edges)
            {
                if (!visited.Contains(edge.Target.Key))
                {
                    var sres = SearchClean(edge.Target, key);
                    if (sres.Found)
                    {
                        sres.Path.Insert(0, edge);
                        sres.Start = edge.Source;
                        return sres;
                    }
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

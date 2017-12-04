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

        public event NodeVisitEventHandler<K> OnResultFound;

  

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

        public SearchResult<K> SearchWithReport(INode<K> root, K key, SearchReport<K> report)
        {
            throw new NotImplementedException();
        }
    }

}

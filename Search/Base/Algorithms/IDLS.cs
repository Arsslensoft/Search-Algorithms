using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base.Algorithms
{
    public class IDLS<K> : ISearchAlgorithm<K>
              where K : class, IComparable<K>
    {
        public string Name => "Iterative Depth limited search";
        public event EventHandler OnResetRequired;
        public event NodeVisitEventHandler<K> OnResultFound;

  

        public void Initialize()
        {
        
        }

        public SearchResult<K> DLS(INode<K> start, K key,int depth)
        {
            start.PreVisit();
            start.Visit();
            if (depth == 0 && start.Key == key)
            {
                start.PostVisit();
                OnResultFound?.Invoke(start);
                SearchResult<K> sr = new SearchResult<K>(start, start);
                return sr;
            }
            else if(depth > 0)
            {
                foreach (var edge in start.Edges)
                {
                    var sres = DLS(edge.Target, key, depth - 1);
                    if (sres.Found)
                    {
                        sres.Path.Insert(0, edge);
                        sres.Start = edge.Source;
                        start.PostVisit();
                        return sres;
                    }
                }
            }

            return new SearchResult<K>(start, null);
        }


        public SearchResult<K> Search(INode<K> root, K key)
        {
            for (int depth = 0; depth < int.MaxValue; depth++)
            {
                OnResetRequired?.Invoke(depth, EventArgs.Empty);
                   var sr = DLS(root, key, depth);
                if (sr.Found)
                {
                    sr.DLSDeph = depth;
                    return sr;
                }
            }
            return new SearchResult<K>(root, null);

        }

        public SearchResult<K> SearchWithReport(INode<K> root, K key, SearchReport<K> report)
        {
            throw new NotImplementedException();
        }
    }

}

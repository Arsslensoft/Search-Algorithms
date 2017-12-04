using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{
  public class SearchResult<K> where K : class, IComparable<K>
    {
        IList<IEdge<K>> path;
        public IList<IEdge<K>> Path { get => path; set => path = value; }

        INode<K> start;
        public INode<K> Start { get => start; set => start = value; }

        INode<K> end;
        public INode<K> End { get => end; set => end = value; }

        public bool Found { get; set; }
        public SearchResult(INode<K>  start, INode<K> final = null)
        {
            Found = (final != null);
            this.start = start;
            this.path = new List<IEdge<K>>();
            this.end = final;
        }
    }
  public  interface ISearchAlgorithm<K>
            where K : class, IComparable<K>
    {
        event NodeVisitEventHandler<K> OnResultFound;
        string Name { get; }
        int Delay { get; set; }

        SearchResult<K> Search(INode<K> root, K key);
    }
    public interface IEdge<K>
          where K : class, IComparable<K>
    {
        INode<K> Source { get; set; }
        INode<K> Target { get; set; }
        double Cost { get; set; }
    }
    public interface INode<K>
            where K : class, IComparable<K>
    {
        event NodeVisitEventHandler<K> OnPreVisit;
        event NodeVisitEventHandler<K> OnVisit;
        event NodeVisitEventHandler<K> OnPostVisit;

        K Key { get; set; }
        double Heuristic { get; set; }
        int MaxDepth { get; }

        void PreVisit();
        void Visit();
        void PostVisit();
        IList<IEdge<K>> Edges { get; }


    }
    public delegate void NodeVisitEventHandler<K>(INode<K> node) where K : class, IComparable<K>;
}

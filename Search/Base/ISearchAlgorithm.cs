using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{
    public  interface ISearchAlgorithm<K>
            where K : class, IComparable<K>
    {
        event NodeVisitEventHandler<K> OnResultFound;
        event EventHandler OnResetRequired;

        string Name { get; }

        void Initialize();
        SearchResult<K> Search(INode<K> root, K key);
        SearchResult<K> SearchWithReport(INode<K> root, K key, SearchReport<K> report);



    }
}

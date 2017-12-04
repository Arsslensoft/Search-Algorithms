using Search.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Parser
{
    public class ParserResults<T>
        where T : class, IComparable<T>
    {
       public List<INode<T>> Nodes { get; set; }
        public List<IEdge<T>> Edges { get; set; }

        public ParserResults()
        {
            Nodes = new List<INode<T>>();
            Edges = new List<IEdge<T>>();
        }
    }
   public interface IGraphDescriptorHandler
    {
        ParserResults<string> Parse(string file);
        void Save(IList<INode<string>> nodes, IList<IEdge<string>> edges,string file);
    }
}

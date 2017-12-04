using Search.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Search.Parser
{
    public class TextGraphDescriptorHandler : IGraphDescriptorHandler
    {
        public void Save(IList<INode<string>> nodes,IList<IEdge<string>> edges, string file)
        {
            using(StreamWriter str = new StreamWriter(file, false))
            {
                foreach (var n in nodes)
                    str.WriteLine(n.Key + "," + n.Heuristic);

                foreach (var e in edges)
                    str.WriteLine(e.Source.Key + "->" + e.Target.Key + "," + e.Cost);

            }
        }
       public ParserResults<string> Parse(string file)
        {
            string[] lines = File.ReadAllLines(file);
            ParserResults<string> result = new ParserResults<string>();
            Dictionary<string, Node<string>> node_cache = new Dictionary<string, Node<string>>();
            string edge_pattern = @"(?<source>[a-zA-Z0-9]+)\-\>(?<target>[a-zA-Z0-9]+)(?<weight>,(\d+[.])?\d+)?";
            string node_pattern = @"(?<node>[a-zA-Z0-9]+)(?<heuristic>,(\d+[.])?\d+)?";
            foreach (var line in lines)
            {
                var m = Regex.Match(line, node_pattern);
                if (m.Success) // node
                {
                    if(!node_cache.ContainsKey(m.Groups["node"].Value))
                    {
                        Node<string> node = new Node<string>(m.Groups["node"].Value, !string.IsNullOrEmpty(m.Groups["heuristic"].Value) ? double.Parse(m.Groups["heuristic"].Value.Remove(0,1)) : 1);
                        node_cache.Add(m.Groups["node"].Value, node);
                        result.Nodes.Add(node);
                    }
                   
                 }
                m = Regex.Match(line, edge_pattern);
                if (m.Success) // edge
                {
                    if (!node_cache.ContainsKey(m.Groups["source"].Value))
                        throw new ArgumentException("Source node is not defined");

                    if (!node_cache.ContainsKey(m.Groups["target"].Value))
                        throw new ArgumentException("Target node is not defined");

                    double weight = !string.IsNullOrEmpty(m.Groups["weight"].Value) ? double.Parse(m.Groups["weight"].Value.Remove(0, 1)) : 1;
                    result.Edges.Add(new Edge<string>(node_cache[m.Groups["source"].Value], node_cache[m.Groups["target"].Value], weight));

                }
            }
            return result;
        }
    }
}

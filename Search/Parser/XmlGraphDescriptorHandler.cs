using Search.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace Search.Parser
{
   public class XmlGraphDescriptorHandler : IGraphDescriptorHandler
    {
        public ParserResults<string> Parse(string file)
        {
            ParserResults<string> result = new ParserResults<string>();
            Dictionary<string, Node<string>> node_cache = new Dictionary<string, Node<string>>();
            XmlDocument doc = new XmlDocument();
            doc.Load(file);
            foreach(XmlElement el in doc.ChildNodes[0].ChildNodes)
            {
                // node
                if(el.Name == "node")
                {
                    if (!node_cache.ContainsKey(el.GetAttribute("key")))
                    {
                        Node<string> node = new Node<string>(el.GetAttribute("key"), el.HasAttribute("heuristic") ? double.Parse(el.GetAttribute("heuristic")) : 1);
                        node_cache.Add(el.GetAttribute("key"), node);
                        result.Nodes.Add(node);
                    }
                }

                // edge
                if (el.Name == "edge")
                {
                    if (!el.HasAttribute("source") || !node_cache.ContainsKey(el.GetAttribute("source")))
                        throw new ArgumentException("Source node is not defined");

                    if (!el.HasAttribute("target") || !node_cache.ContainsKey(el.GetAttribute("target")))
                        throw new ArgumentException("Target node is not defined");

                    double weight = el.HasAttribute("weight") ? double.Parse(el.GetAttribute("weight")) : 1;
                    result.Edges.Add(new Edge<string>(node_cache[el.GetAttribute("source")], node_cache[el.GetAttribute("target")], weight));

                }

            }
            
            return result;
        }

        public void Save(IList<INode<string>> nodes, IList<IEdge<string>> edges, string file)
        {
            XmlDocument doc = new XmlDocument();
            var gel = doc.CreateElement("graph");
            doc.AppendChild(gel);
            foreach(var n in nodes)
            {
                var nel = doc.CreateElement("node");
                nel.SetAttribute("key", n.Key);
                nel.SetAttribute("heuristic", n.Heuristic.ToString());
                gel.AppendChild(nel);
            }
            foreach(var e in edges)
            {
                var eel = doc.CreateElement("edge");
                eel.SetAttribute("source", e.Source.Key);
                eel.SetAttribute("target", e.Target.Key);
                eel.SetAttribute("weight", e.Cost.ToString());
                gel.AppendChild(eel);
            }
            doc.Save(file);
        }

     }
}

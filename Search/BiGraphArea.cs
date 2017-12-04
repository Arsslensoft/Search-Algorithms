using GraphX;
using QuickGraph;
using System;
using System.Collections.Generic;
using System.Linq;
using GraphX.Controls;
using Search.Base;
using System.Windows.Media;

namespace Search
{
   public class BiGraphArea<K> : GraphArea<Node<K>, Search.Base.Edge<K>, BidirectionalGraph<Node<K>, Search.Base.Edge<K>>>
             where K : class, IComparable<K>
    {
        Dictionary<Node<K>, VertexControl> vertices = new Dictionary<Node<K>, VertexControl>();
        List<EdgeControl> changed = new List<EdgeControl>();
        public void Generate()
        {
            vertices.Clear();
            //edges.Clear();
            GenerateGraph(true);
            SetVerticesDrag(true, true);
            foreach (var v in GetAllVertexControls())
                vertices.Add(((Node<K>)v.Vertex), v);

        }

        public void ColorizeNode(Node<K> node, Brush color)
        {
            vertices[node].Background = color;
        }
        public void ResetNodesColor()
        {
            foreach (var v in GetAllVertexControls())
                v.Background = new SolidColorBrush(Color.FromRgb(227,227,227));

            foreach (var e in changed)
                e.Foreground = Brushes.Black;

            changed.Clear();
        }
        public void ColorizePath(SearchResult<K> sr, Brush color)
        {
            foreach(var edge in sr.Path)
            {
                var edges = GetRelatedEdgeControls(vertices[((Node<K>)edge.Source)], GraphX.PCL.Common.Enums.EdgesType.Out).Cast<EdgeControl>();
                foreach (var e in edges)
                    if (e.Target.Vertex == edge.Target)
                    {
                        e.Foreground = color;
                        changed.Add(e);
                    }

            }
        }
    }
}

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

        private Node<K> start, goal;
        public void SetInitialGoal(Node<K> start, Node<K> goal)
        {
            this.start = start;
            this.goal = goal;

               vertices[start].BorderBrush = Brushes.Gold;
            vertices[start].UpdateLayout();

            vertices[goal].BorderBrush = Brushes.Crimson;
            vertices[goal].UpdateLayout();
        }
        public void ResetInitialGoal()
        {
            if (start != null)
            {
                vertices[start].BorderBrush = Brushes.Black;
                vertices[start].UpdateLayout();
            }
            if (goal != null)
            {
                vertices[goal].BorderBrush = Brushes.Black;
                vertices[goal].UpdateLayout();
            }
        }
        public void ColorizeNode(Node<K> node, Brush color)
        {
            vertices[node].Background = color;
            vertices[node].UpdateLayout();
        }
        public void ResetNodesColor()
        {
            foreach (var v in GetAllVertexControls())
            {
                v.Background = new SolidColorBrush(Color.FromRgb(227, 227, 227));
                v.UpdateLayout();
            }

            foreach (var e in changed)
            {
                e.Foreground = Brushes.Black;
                e.UpdateLayout();
            }

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
                        e.UpdateLayout();
                    }

            }
        }
    }
}

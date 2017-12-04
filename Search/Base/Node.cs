using GraphX.PCL.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{
    public class Node<K> : VertexBase, INode<K>
     where K : class, IComparable<K>
    {
        K key;
        IList<IEdge<K>> edges;


        /// <summary>
        /// Some string property for example purposes
        /// </summary>
        public string Text { get => Key.ToString(); }

        public override string ToString()
        {
            return Text;
        }

        public K Key { get => key; set => key=value; }
        public double Heuristic { get; set; }     
        public int MaxDepth => CalculateDepth();
    
        public IList<IEdge<K>> Edges => edges;

        int CalculateDepth()
        {
            int max = 0;
            foreach (var n in edges)
                max = max < n.Target.MaxDepth ? n.Target.MaxDepth : max;

            return max + 1;
        }
        public event NodeVisitEventHandler<K> OnPreVisit;
        public event NodeVisitEventHandler<K> OnVisit;
        public event NodeVisitEventHandler<K> OnPostVisit;

        public void PostVisit()
        {
            OnPostVisit?.Invoke(this);
        }

        public void PreVisit()
        {
            OnPreVisit?.Invoke(this);
        }

        public void Visit()
        {
            OnVisit?.Invoke(this);
        }


        public Node(K key, double heuristic = 1)
        {
            this.key = key;
            this.Heuristic = heuristic;
            edges = new List<IEdge<K>>();

        }
    }
}

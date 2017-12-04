using GraphX.PCL.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Search.Base
{
    public class Edge<K> : EdgeBase<Node<K>>, IEdge<K>
              where K : class, IComparable<K>
    {
        double cost;
        public double Cost { get => cost; set => cost = value; }
        INode<K> IEdge<K>.Source { get => base.Source; set => base.Source = (Node<K>)value; }
        INode<K> IEdge<K>.Target { get => base.Target; set => base.Target = (Node<K>)value; }

        public override string ToString()
        {
            return Cost.ToString();
        }

        /// <summary>
        /// We need to set at least Source and Target properties of the edge.
        /// </summary>
        /// <param name="source">Source vertex data</param>
        /// <param name="target">Target vertex data</param>
        /// <param name="weight">Optional edge weight</param>
        public Edge(Node<K> source, Node<K> target, double cost = 1)
			: base(source, target, cost)
		{
            this.cost = cost;
        }
       
        /// <summary>
        /// Default parameterless constructor (for serialization compatibility)
        /// </summary>
        public Edge()
            : base(null, null, 1)
        {

        }

     
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Priority_Queue;

namespace Search.Base.Algorithms
{
    public class GBFS<K> : ISearchAlgorithm<K>
               where K : class, IComparable<K>
    {
        public event EventHandler OnResetRequired;
        public string Name => "Greedy Best-first search";
        public string Description => "Best-first search is a search algorithm which explores a graph by expanding the most promising node chosen according to a specified rule.";

        public event NodeVisitEventHandler<K> OnResultFound;
        private bool logged = false;
        public bool Logged
        {
            get => logged;
            set => logged = value;
        }

        public void Initialize()
        {

        }

        void ConstructPath(Dictionary<INode<K>, IEdge<K>> meta, INode<K> state, SearchResult<K> sr)
        {

            while (true)
            {
                if (meta.ContainsKey(state))
                {
                    IEdge<K> edge = meta[state];
                    state = edge.Source;
                    sr.Path.Add(edge);
                }
                else
                    break;
            }
            sr.Path = sr.Path.Reverse().ToList();
        }

        public SearchResult<K> Search(INode<K> root, K key)
        {
            SimplePriorityQueue<INode<K>,double> queue = new SimplePriorityQueue<INode<K>, double>();
            List<K> visited = new List<K>();
            Dictionary<INode<K>, IEdge<K>> meta = new Dictionary<INode<K>, IEdge<K>>();
            queue.Enqueue(root,root.Heuristic);
            while (queue.Any())
            {
                var node = queue.Dequeue();
                node.PreVisit();
                visited.Add(node.Key); // mark as visited
                node.Visit();

                if (node.Key == key)
                {
                    node.PostVisit();
                    OnResultFound?.Invoke(node);
                    SearchResult<K> sr = new SearchResult<K>(root, node);
                    ConstructPath(meta, node, sr);
                    return sr;
                }
                if (logged)
                    root.LogAction("Exploring successors of " + root); // successors
                foreach (var child in node.Edges)
                {
                    if (!visited.Contains(child.Target.Key) && !queue.Contains(child.Target))
                    {
                        if (logged)
                            root.LogAction("New node has been added to the queue " + child.Target); 
                        meta.Add(child.Target, child);
                            queue.Enqueue(child.Target, child.Target.Heuristic);
                    }
                    else if(queue.Contains(child.Target) && queue.GetPriority(child.Target) > child.Target.Heuristic)
                    {
                        if (logged)
                            root.LogAction("Updating " + child.Target + " priority from " + queue.GetPriority(child.Target) + " to " + child.Target.Heuristic);
                        queue.UpdatePriority(child.Target, child.Target.Heuristic);
                        meta[child.Target] = child;
                    }
                }
                node.PostVisit();

            }
            return new SearchResult<K>(root, null);
        }
        public SearchResult<K> SearchClean(INode<K> root, K key)
        {
            SimplePriorityQueue<INode<K>, double> queue = new SimplePriorityQueue<INode<K>, double>();
            List<K> visited = new List<K>();
            Dictionary<INode<K>, IEdge<K>> meta = new Dictionary<INode<K>, IEdge<K>>();
            queue.Enqueue(root, root.Heuristic);
            while (queue.Any())
            {
                var node = queue.Dequeue();
                visited.Add(node.Key); // mark as visited


                if (node.Key == key)
                {
                    SearchResult<K> sr = new SearchResult<K>(root, node);
                    ConstructPath(meta, node, sr);
                    return sr;
                }
                foreach (var child in node.Edges)
                {
                    if (!visited.Contains(child.Target.Key) && !queue.Contains(child.Target))
                    {
                        meta.Add(child.Target, child);
                        queue.Enqueue(child.Target, child.Target.Heuristic);
                    }
                    else if (queue.Contains(child.Target) && queue.GetPriority(child.Target) > child.Target.Heuristic)
                    {
                        queue.UpdatePriority(child.Target, child.Target.Heuristic);
                        meta[child.Target] = child;
                    }
                }

            }
            return new SearchResult<K>(root, null);
        }
        public double CalculateCost(SearchResult<K> result)
        {
            if (result == null || !result.Found)
                return double.PositiveInfinity;
            else
            {
                double cost = 0;
                foreach (var edge in result.Path)
                    cost += edge.Cost;
                return cost;
            }
        }
    }
}

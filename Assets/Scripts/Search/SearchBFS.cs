using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Priority_Queue;

public static class SearchBFS
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
        //The basic algorithm is as follows
        // <create queue>
        SimplePriorityQueue<GraphNode> nodes = new SimplePriorityQueue<GraphNode>();
        // <set source node visited to true>
        source.Visited = true;
        // <enqueue source node>
        nodes.Enqueue(source, source.Cost);
        // set found bool flag and the current number of steps
        bool found = false;
        int steps = 0;
        while (!found && nodes.Count > 0 && steps++ < maxSteps)
        {
            GraphNode node = nodes.Dequeue();
            // go through edges of node
            foreach (GraphNode.Edge edge in node.Edges)
            {
                // if nodeB is not visited
                if (edge.NodeB.Visited == false)
                {
                    // <set nodeB visited to true>
                    edge.NodeB.Visited = true;
                    // <set nodeB parent to node>
                    edge.NodeB.Parent = node;
                    // <enqueue nodeB>
                    nodes.Enqueue(edge.NodeB, edge.NodeB.Cost);
                }
                if (edge.NodeB == destination)
                {
                    // <set found to true>
                    found = true;
                    // <break from foreach>
                    break;
                }
            }
        }
        // create a list of graph nodes (path)
        path = new List<GraphNode>();
        // if found is true
        if (found)
        {
            GraphNode node = destination;
            // while node not null
            while (node != null)
            {
                // <add node to path list>
                path.Add(node);
                // <set node to node.Parent>
                node = node.Parent;
            }
            // reverse path
            path.Reverse();
        }
        else
        {
            //path = nodes.ToList();
        }
        return found;
    }
}
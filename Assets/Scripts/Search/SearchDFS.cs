using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SearchDFS
{
    public static bool Search(GraphNode source, GraphNode destination, ref List<GraphNode> path, int maxSteps)
    {
        bool found = false;

        Stack<GraphNode> nodes = new Stack<GraphNode>();
        nodes.Push(source);

        int steps = 0;
        while (!found && nodes.Count > 0 && steps++ < maxSteps)
        {
            // get top node of stack node (peek)
            GraphNode node = nodes.Peek();
            node.Visited = true;
            // <mark node visited>

            bool forward = false;
            // search node edges for unvisited node
            foreach (GraphNode.Edge edge in node.Edges)
            {
                // if node unvisited then push on stack
                if (edge.NodeB.Visited == false)
                {
                    nodes.Push(edge.NodeB);
                    // <set forward flag to true>
                    forward = true;
                    if (edge.NodeB == destination)
                    {
                        found = true;
                        break;
                    }
                }
                // if not moving forward, pop current node off stack
                if (forward == false)
                {
                    // <pop stack>
                    nodes.Pop();
                }
            }
            // convert stack path nodes to list
            path = new List<GraphNode>(nodes);
            // <reverse path list>
            path.Reverse();

        }
        
        return found;
    }
}

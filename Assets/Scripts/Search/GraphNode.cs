using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraphNode : SearchNode
{
    public enum eType
    {
        Default,
        Source,
        Destination,
        Path,
        Visited
    }

    Color[] colors =
    {
        Color.white,
        Color.green,
        Color.red,
        Color.yellow,
        Color.blue
    };

    public struct Edge
    {
        public GraphNode NodeA;
        public GraphNode NodeB;
    }

    public List<Edge> Edges { get; set; } = new List<Edge>();
    public eType Type { get; set; } = eType.Default;
    public GraphNode Parent { get; set; } = null;
    public bool Visited { get; set; } = false;
    public float Cost { get; set; } = float.MaxValue;
    public float Heuristic { get; set; } = 0;

    void Update()
    {
        GetComponent<Renderer>().material.color = colors[(int)Type];

        foreach (Edge edge in Edges)
        {
            Debug.DrawLine(edge.NodeA.transform.position, edge.NodeB.transform.position);
        }
    }

    public static GraphNode[] GetGraphNodes()
    {
        return GameObject.FindObjectsOfType<GraphNode>();
    }

    public static GraphNode GetGraphNode(eType type)
    {
        GraphNode graphNode = null;

        GraphNode[] graphNodes = GetGraphNodes();
        foreach(GraphNode node in graphNodes)
        {
            if(node.Type == type)
            {
                graphNode = node;
                break;
            }
        }

        return graphNode;
    }

    public static void UnLinkNodes()
    {
        GraphNode[] graphNodes = GetGraphNodes();
        foreach (GraphNode graphNode in graphNodes)
        {
            graphNode.Edges.Clear();
        }

    }

    public static void LinkNodes(float range)
    {
        GraphNode[] graphNodes = GetGraphNodes();
        foreach(GraphNode graphNode in graphNodes)
        {
            LinkNode(graphNode,range);
        }

    }

    public static void LinkNode(GraphNode node, float range)
    {
        Collider[] colliders = Physics.OverlapSphere(node.transform.position, range);
        foreach (Collider collider in colliders)
        {
            GraphNode otherNode = collider.GetComponent<GraphNode>();
            if (otherNode != null && otherNode != node)
            {
                GraphNode.Edge edge;
                edge.NodeA = node;
                edge.NodeB = otherNode;

                node.Edges.Add(edge);
            }
        }
    }

    public static void ClearNodeType(eType type)
    {
        GraphNode[] graphNodes = GetGraphNodes();
        foreach (GraphNode node in graphNodes)
        {
            if (node.Type == type)
            {
                node.Type = eType.Default;
                break;
            }
        }
    }

    public static void Reset()
    {
        ClearNodeType(eType.Path);
        ClearNodeType(eType.Visited);

        GraphNode[] graphNodes = GetGraphNodes();
        foreach (GraphNode graphNode in graphNodes)
        {
            graphNode.Visited = false;
            graphNode.Parent = null;
            graphNode.Cost = float.MaxValue;
        }
    }
}


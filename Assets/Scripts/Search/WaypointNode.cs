using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointNode : SearchNode
{
    public WaypointNode nextWayPoint;
    
    private void OnTriggerEnter(Collider other)
    {
        Agent Agent = other.GetComponent<Agent>();
        if(Agent != null)
        {
            SearchPath searchPath = Agent.GetComponent<SearchPath>();
            if (searchPath.Node == this)
            {
                //searchPath.Node = nextWayPoint;
                //This is for random next nodes
                searchPath.Node = GetRandomSearchNode();
            }

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CohessionBehavior : Behavior
{
    public override Vector3 Execute()
    {
        Vector3 force = Vector3.zero;

        GameObject[] gameObjects = perception.GetGameObjects();
        if (gameObjects != null && gameObjects.Length > 0)
        {
            Vector3 position = Vector3.zero;
            foreach(GameObject gameObject in gameObjects)
            {
                position += gameObject.transform.position;
            }
            Vector3 center = position / gameObjects.Length;
            Vector3 direction = (center - transform.position).normalized;

            Vector3 desired = direction * Agent.maxSpeed;
            force = Vector3.ClampMagnitude(desired - Agent.Velocity, Agent.maxForce);
        }

        return force;
    }
}

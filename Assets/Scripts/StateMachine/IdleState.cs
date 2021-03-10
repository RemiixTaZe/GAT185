using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : State
{
    public override void Enter(Agent Owner)
    {
        Debug.Log(GetType().Name + " Enter");
    }

    public override void Execute(Agent Owner)
    {
        SearchPath searchPath = Owner.GetComponent<SearchPath>();
        searchPath.Move(Owner.movement);

        GameObject[] gameObjects = Owner.perception.GetGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

        if (player != null)
        {
            ((StateAgent)Owner).StateMachine.SetState("AttackState");
        }
    }

    public override void Exit(Agent Owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackState : State
{
    public float attackTimeMin = 0.5f;
    public float attackTimeMax = 2.0f;
    public float MeleeDistance = 2.0f;


    float timer;
    float attckTimer;
    Vector3 lastTargetPosition;

    public override void Enter(Agent Owner)
    {
        Debug.Log(GetType().Name + " Enter");
        attckTimer = Random.Range(attackTimeMin, attackTimeMax);
    }

    public override void Execute(Agent Owner)
    {
        GameObject[] gameObjects = Owner.perception.GetGameObjects();
        GameObject player = Perception.GetGameObjectFromTag(gameObjects, "Player");

        //player seen
        if(player != null)
        {
            lastTargetPosition = player.transform.position;
            timer = 4;

            attckTimer -= Time.deltaTime;
            if(attckTimer <= 0)
            {
                float distance = Vector3.Distance(Owner.transform.position, player.transform.position);
                if(distance < MeleeDistance)
                {
                    ((StateAgent)Owner).StateMachine.SetState("AttackMeleeState");
                }
            }
        }

        Owner.movement.MoveTowards(lastTargetPosition);

        if (player == null)
        {
            timer -= Time.deltaTime;
            if(timer <= 0)
            {
                ((StateAgent)Owner).StateMachine.SetState("IdleState");
            }
        }
    }

    public override void Exit(Agent Owner)
    {
        Debug.Log(GetType().Name + " Exit");
    }
}

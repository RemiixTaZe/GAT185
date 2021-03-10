using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackMeleeState : State
{
    float timer;

    public override void Enter(Agent Owner)
    {
        Owner.animator.SetTrigger("EnemySwipe");
        Owner.movement.Stop();
        timer = 2;
    }

    public override void Execute(Agent Owner)
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            ((StateAgent)Owner).StateMachine.SetState("AttackState");
        }
    }

    public override void Exit(Agent Owner)
    {
        Owner.movement.Resume();
    }
}

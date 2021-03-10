using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    float timer;

    public override void Enter(Agent Owner)
    {
        Owner.animator.SetTrigger("Death");
        timer = 4;
    }

    public override void Execute(Agent Owner)
    {
        timer -= Time.deltaTime;
        if(timer <= 0)
        {
            Destroy(Owner.gameObject);
        }
    }

    public override void Exit(Agent Owner)
    {
    }
}

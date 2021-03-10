using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class State : MonoBehaviour
{
    public abstract void Enter(Agent Owner);
    public abstract void Execute(Agent Owner);
    public abstract void Exit(Agent Owner);
}

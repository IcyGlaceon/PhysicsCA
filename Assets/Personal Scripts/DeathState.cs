using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathState : State
{
    public DeathState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.movement.Stop();
    }

    public override void OnExit()
    {
        
    }

    public override void OnUpdate()
    {
        GameObject.Destroy(owner.gameObject, 3);
    }
}

//using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WanderState : State
{
    private Vector3 target;

    public WanderState(StateAgent owner) : base(owner)
    {
    }

    public override void OnEnter()
    {
        owner.navigation.targetNode = null;
        owner.movement.Resume();
        // create random target position around owner 
        owner.movement.MoveTowards(target);
    }
    public override void OnExit()
    {
    }

    public override void OnUpdate()
    {
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Skeleton_Idle : FsmState
{
    public static string STATE_NAME = "Idle";

    private string CHASE_STATE = State_Skeleton_Chase.STATE_NAME;
    private string IDLE_STATE = State_Skeleton_Idle.STATE_NAME;

    private float idleTime = 5.0f;

    public State_Skeleton_Idle() : base(STATE_NAME)
    {

    }

    public override void OnEnter()
    {
       
    }

    public override void OnExit(GameObject go)
    {
        go.GetComponent<Skeleton_01Cntrl>().StartChase();
    }

    public override string OnUpdate(GameObject go, float dt)
    {
        idleTime -= dt;

        return (idleTime <= 0.0f ? CHASE_STATE : IDLE_STATE);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class State_Skeleton_Chase : FsmState
{
    public static string STATE_NAME = "Chase";

    private GameObject player = null;

    private float rotationSlerp = 0.2f;

    public State_Skeleton_Chase(GameObject player) : base(STATE_NAME)
    {
        this.player = player;
    }

    public override void OnEnter()
    {

    }

    public override void OnExit(GameObject go)
    {

    }

    public override string OnUpdate(GameObject skeleton, float dt)
    {
        MoveSkeleton(skeleton);

        return (STATE_NAME);
    }

    private void MoveSkeleton(GameObject skeleton)
    {
        Vector3 direction = player.transform.position - skeleton.transform.position;
        direction.y = 0.0f;
        Quaternion rotation = Quaternion.LookRotation(direction);
        skeleton.transform.rotation = Quaternion.Slerp(skeleton.transform.rotation, rotation, rotationSlerp);
    }
}

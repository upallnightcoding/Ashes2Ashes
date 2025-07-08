using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FsmState 
{
    public string Name { private set; get; }

    public FsmState(string name)
    {
        Name = name;
    }

    public abstract void OnEnter();
    public abstract void OnExit(GameObject go);
    public abstract string OnUpdate(GameObject go, float dt);
}

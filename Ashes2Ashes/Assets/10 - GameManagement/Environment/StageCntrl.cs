using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageCntrl : MonoBehaviour
{
    [SerializeField] private GameObject floorBluePrint;

    [SerializeField] private GameObject[] WallDoor;
    [SerializeField] private GameObject[] statue;
    [SerializeField] private GameObject wall;

    // Start is called before the first frame update
    void Start()
    {
        Framework framework = new Framework();

        framework
        .Blueprint(floorBluePrint)
        .Assemble(WallDoor[0], "North", new FwTransform().Set(0.0f, 180.0f, 0.0f))
        .Assemble(WallDoor[1], "South", new FwTransform().Set(0.0f, 0.0f, 0.0f))
        .Assemble(WallDoor[0], "East", new FwTransform().Set(0.0f, -90.0f, 0.0f))
        .Assemble(WallDoor[1], "West", new FwTransform().Set(0.0f, 90.0f, 0.0f))
        .Assemble(statue, "Figure1")
        .Assemble(statue, "Figure2")
        .Assemble(statue, "Figure3")
        .Construct(wall, "Wall_North", new FwTransform().Set(0.0f, 180.0f, 0.0f))
        .Construct(wall, "Wall_South", new FwTransform().Set(0.0f, 0.0f, 0.0f))
        .Construct(wall, "Wall_West", new FwTransform().Set(0.0f, 90.0f, 0.0f))
        .Construct(wall, "Wall_East", new FwTransform().Set(0.0f, -90.0f, 0.0f))
        .Build();
    }

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WFCStructure", menuName = "A2A/WFC Structure")]
public class WFCStructureSO : ScriptableObject
{
    public WFCGameObject[] gridGameObjectList;

    public int GetGameObjectsCount()
    {
        return (gridGameObjectList.Length);
    }
}

[System.Serializable]
public class WFCGameObject
{
    public GameObject gridGameObject;

    public int[] north;
    public int[] south;
    public int[] east;
    public int[] west;
}

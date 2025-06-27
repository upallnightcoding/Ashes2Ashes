using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WFC : MonoBehaviour
{
    [SerializeField] private WFCStructureSO wfcStructure;

    private WFCWorkingGrid[,] workingGrid;

    private int width = 5;
    private int height = 5;

    // Start is called before the first frame update
    void Start()
    {
        InitWorkingGrid();

        ProcessWorkingGrid();

        DisplayWorkingGrid();
    }

    private void ProcessWorkingGrid()
    {
        WFCGridPos gridPos = ChooseRandomStartPoint();

        CollapseGrid(gridPos);
    }

    private void TestCollapse(WFCGridPos center, WFCGridPos compare)
    {

    }

    private WFCGridPos ChooseRandomStartPoint()
    {
        return (new WFCGridPos(1, 1));
    }

    private void CollapseGrid(WFCGridPos gridPos)
    {
        WFCWorkingGrid grid = workingGrid[gridPos.w, gridPos.h];

        grid.Collaspe();
    }

    /**
     * displayWorkingGrid() - 
     */
    private void DisplayWorkingGrid()
    {
        float delta = 2.5f;

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                Vector3 position = new Vector3(delta * w, 0.0f, delta * h);
                WFCGridPos pos = new WFCGridPos(w, h);

                GameObject prefab = wfcStructure.gridGameObjectList[1].gridGameObject;
                GameObject go = Instantiate(prefab, position, Quaternion.identity);
                go.transform.SetParent(gameObject.transform);
            }
        }
    }

    /**
     * initWorkingGrid() - 
     */
    private void InitWorkingGrid()
    {
        workingGrid = new WFCWorkingGrid[width, height];

        int nGameObjects = wfcStructure.GetGameObjectsCount();

        for (int w = 0; w < width; w++)
        {
            for (int h = 0; h < height; h++)
            {
                workingGrid[w, h] = new WFCWorkingGrid(nGameObjects);
            }
        }
    }
}

public class WFCGridPos 
{
    public int w, h;

    public WFCGridPos(int w, int h)
    {
        this.w = w;
        this.h = h;
    }
    
}

public class WFCWorkingGrid
{
    private bool[] options;
    private bool isCollapsed = false;
    private int collapsedObject = -1;
    private int nOptions = -1;

    public WFCWorkingGrid(int n)
    {
        nOptions = n;
        options = new bool[n];

        for (int i = 0; i < n; i++)
        {
            options[i] = true;
        }
    }

    public void Process(WFCStructureSO wfcStructure, WFCWorkingGrid grid)
    {
        bool[] allowableGrids = null;

        allowableGrids = BuildNorthAllowableGrid(wfcStructure);
        UpdateOptions(allowableGrids);
    }

    public void UpdateOptions(bool[] compareList)
    {
        int n = 0;

        for (int i = 0; i < nOptions; i++)
        {
            if (options[i] && compareList[i])
            {
                options[i] = true;
                n++;
            } else
            {
                options[i] = false;
            }
        }

        switch (n)
        {
            case 0:
                break;
            case 1:
                break;
            default:
                break;
        }
    }

    public int compare(bool[] allowable)
    {
        int n = 0;

        for (int i = 0; i < nOptions; i++)
        {
            if (options[i] && allowable[i])
            {
                options[i] = true;
                n++;
            }
            else
            {
                options[i] = false;
            }
        }

        return (n);
    }

    public bool[] BuildNorthAllowableGrid(WFCStructureSO wfcStructure)
    {
        bool[] compareList = new bool[nOptions];
        for (int i = 0; i < nOptions; i++) compareList[i] = false;

        for (int i = 0; i < nOptions; i++)
        {
            if (options[i])
            {
                int n = wfcStructure.gridGameObjectList[i].north.Length;

                for (int j = 0; j < n; j++)
                {
                    int index = wfcStructure.gridGameObjectList[i].north[j];
                    compareList[index] = true;
                }
            }
        }

        return (compareList);
    }

    public bool[] BuildSouthCompareList(WFCStructureSO wfcStructure)
    {
        bool[] compareList = new bool[nOptions];
        for (int i = 0; i < nOptions; i++) compareList[i] = false;

        for (int i = 0; i < nOptions; i++)
        {
            if (options[i])
            {
                int n = wfcStructure.gridGameObjectList[i].south.Length;

                for (int j = 0; j < n; j++)
                {
                    int index = wfcStructure.gridGameObjectList[i].south[j];
                    compareList[index] = true;
                }
            }
        }

        return (compareList);
    }

    public bool[] BuildWestCompareList(WFCStructureSO wfcStructure)
    {
        bool[] compareList = new bool[nOptions];
        for (int i = 0; i < nOptions; i++) compareList[i] = false;

        for (int i = 0; i < nOptions; i++)
        {
            if (options[i])
            {
                int n = wfcStructure.gridGameObjectList[i].west.Length;

                for (int j = 0; j < n; j++)
                {
                    int index = wfcStructure.gridGameObjectList[i].west[j];
                    compareList[index] = true;
                }
            }
        }

        return (compareList);
    }

    public bool[] BuildEastCompareList(WFCStructureSO wfcStructure)
    {
        bool[] compareList = new bool[nOptions];
        for (int i = 0; i < nOptions; i++) compareList[i] = false;

        for (int i = 0; i < nOptions; i++)
        {
            if (options[i])
            {
                int n = wfcStructure.gridGameObjectList[i].east.Length;

                for (int j = 0; j < n; j++)
                {
                    int index = wfcStructure.gridGameObjectList[i].east[j];
                    compareList[index] = true;
                }
            }
        }

        return (compareList);
    }

    public void Collaspe()
    {
        isCollapsed = true;
        collapsedObject = 3;
    }
}

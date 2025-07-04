using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Framework 
{
    private GameObject model = null;

    public Framework Blueprint(GameObject framework)
    {
        model = Object.Instantiate<GameObject>(framework, new Vector3(), Quaternion.identity);

        return (this);
    }

    public Framework Assemble(GameObject[] additionList, string anchorName)
    {
        int selection = Random.Range(0, additionList.Length);

        return (Assemble(additionList[selection], anchorName));
    }

    public Framework Assemble(GameObject addition, string anchorName, Vector3 face = new Vector3())
    {
        if (addition != null)
        {
            Transform anchors = model.transform.Find("Anchors");
            Transform anchor = anchors.Find(anchorName);

            if (anchor)
            {
                GameObject go = Object.Instantiate(addition, anchor);
                go.transform.rotation = Quaternion.Euler(face);
            }
        }

        return (this);
    }

    public Framework Assemble(GameObject addition, string anchorName, FwTransform fwTransform)
    {
        if (addition != null)
        {
            Transform anchors = model.transform.Find("Anchors");
            Transform anchor = anchors.Find(anchorName);

            if (anchor)
            {
                GameObject go = Object.Instantiate(addition, anchor);
                go.transform.rotation = fwTransform.Rotation();
            }
        }

        return (this);
    }

    public Framework Construct(GameObject addition, string achorName, FwTransform fwTransform)
    {
        if (addition != null)
        {
            Transform anchors = model.transform.Find("Anchors");
            int nChild = anchors.childCount;

            for (int i = 0; i < nChild; i++) 
            {
                Transform child = anchors.GetChild(i);

                Debug.Log($"Anchors: {child.name}");

                if (child.name == achorName)
                {
                    GameObject go = Object.Instantiate(addition, child);
                    go.transform.rotation = fwTransform.Rotation();
                }
            }
        }

        return (this);
    }

    public Framework Parent(Transform transform)
    {
        model.transform.parent = transform;

        return (this);
    }

    public Framework Position(Vector3 position)
    {
        model.transform.position = position;

        return (this);
    }

    public Framework Face(Vector3 face)
    {
        return (this);
    }

    public GameObject Build()
    {
        return (model);
    }

    public GameObject Build(Vector3 rotate)
    {
        model.transform.rotation = Quaternion.Euler(rotate);

        return (model);
    }

}

public class FwTransform
{
    private Vector3 value = new Vector3();

    public FwTransform Set(float x, float y, float z)
    {
        value.x = x;
        value.y = y;
        value.z = z;

        return (this);
    }

    public Quaternion Rotation(float x, float y, float z)
    {
        Set(x, y, z);

        return (Rotation());
    }

    public Quaternion Rotation()
    {
        return (Quaternion.Euler(value));
    }
}

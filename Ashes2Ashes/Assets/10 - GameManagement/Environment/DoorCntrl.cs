using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class DoorCntrl : MonoBehaviour
{
    [SerializeField] private Transform leftDoor;
    [SerializeField] private Transform rightDoor;

    private bool isDoorOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Open Door ...");
        if (!isDoorOpen)
        {
            isDoorOpen = true;

            rightDoor.DORotate(new Vector3(0.0f, -90.0f, 0.0f), 2.0f);
            leftDoor.DORotate(new Vector3(0.0f, 90.0f, 0.0f), 2.0f);
        }
    }
}

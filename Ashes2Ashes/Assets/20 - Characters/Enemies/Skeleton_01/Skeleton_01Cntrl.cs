using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_01Cntrl : MonoBehaviour
{
    [SerializeField] private Transform hero;

    private float rotationSlerp = 0.2f;
    private float swipDistance = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MoveSkeleton();
    }

    private void MoveSkeleton()
    {
        Vector3 direction = hero.transform.position - transform.position;
        direction.y = 0.0f;
        Quaternion rotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, rotationSlerp);
    }

    private void SwipAtHero()
    {

    }
}

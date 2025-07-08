using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton_01Cntrl : MonoBehaviour
{
    [SerializeField] private GameObject hero;

    private Animator animator = null;

    private Fsm fsm = null;

    private void Awake()
    {
        fsm = new Fsm();

        fsm.AddState(new State_Skeleton_Idle());
        fsm.AddState(new State_Skeleton_Chase(hero));
    }

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    public void StartChase()
    {
        animator.SetBool("chase", true);
    }

    // Update is called once per frame
    void Update()
    {
        fsm.OnUpdate(gameObject, Time.deltaTime);
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactCntrl : MonoBehaviour
{
    private bool hasNotImpacted = true;

    private GameObject impactPrefab = null;
    
    // Start is called before the first frame update
    public void Set(GameObject impactPrefab)
    {
        this.impactPrefab = impactPrefab;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (hasNotImpacted)
        {
            Debug.Log("OnCollisionEnter ...");
            hasNotImpacted = false;

            GameObject go = Instantiate(impactPrefab, transform.position, Quaternion.identity);


            Destroy(transform.gameObject);
        }
    }
}

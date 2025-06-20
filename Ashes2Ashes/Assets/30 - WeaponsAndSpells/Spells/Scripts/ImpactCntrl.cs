using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImpactCntrl : MonoBehaviour
{
    public GameEvent onWeaponsImpactEvent;

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
            hasNotImpacted = false;

            onWeaponsImpactEvent.Raise(new OnWeaponImpactData(impactPrefab, transform.position));

            Destroy(transform.gameObject);
        }
    }
}

public class OnWeaponImpactData : EventData
{
    public GameObject prefab;
    public Vector3 position;

    public OnWeaponImpactData(GameObject prefab, Vector3 position)
    {
        this.prefab = prefab;
        this.position = position;
    }
}

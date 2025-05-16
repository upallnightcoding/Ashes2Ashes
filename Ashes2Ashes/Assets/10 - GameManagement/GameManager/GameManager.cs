using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public EventChannelDataSO onWeaponImpactChannel;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void Impact(EventData eventData)
    {
        OnWeaponImpactData data = (OnWeaponImpactData)eventData;

        GameObject go = Instantiate(data.prefab, data.position, Quaternion.identity);
    }

    private void OnEnable()
    {
        onWeaponImpactChannel.OnEventRaised += Impact;
    }

    private void OnDisable()
    {
        onWeaponImpactChannel.OnEventRaised -= Impact;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameEvent mainMenuEvent;

    // Start is called before the first frame update
    void Start()
    {
        //Debug.Log("GameManager ...");
        //MainMenuStart(null);
    }

    public void MainMenuStart(EventData eventData)
    {
        mainMenuEvent.Raise();
    }

    public void StartGamePlay(EventData eventData)
    {

    }

    public void Impact(EventData eventData)
    {
        OnWeaponImpactData data = (OnWeaponImpactData)eventData;

        GameObject go = Instantiate(data.prefab, data.position, Quaternion.identity);
        Destroy(go, 3.0f);
    }
}


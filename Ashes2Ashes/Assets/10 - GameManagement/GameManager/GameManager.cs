using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Game Events ...")]
    [SerializeField] private GameEvent mainMenuEvent;
    [SerializeField] private GameEvent startGamePlayEvent;

    [SerializeField] private GameObject hero;

    // Start is called before the first frame update
    void Start()
    {

    }

    public void MainMenuStart(EventData eventData)
    {
        mainMenuEvent.Raise();
    }

    public void StartGamePlay()
    {
        startGamePlayEvent.Raise();

        RenderHero();
    }

    public void Impact(EventData eventData)
    {
        OnWeaponImpactData data = (OnWeaponImpactData)eventData;

        GameObject go = Instantiate(data.prefab, data.position, Quaternion.identity);
        Destroy(go, 3.0f);
    }

    private void RenderHero()
    {
        hero.SetActive(true);
    }
}


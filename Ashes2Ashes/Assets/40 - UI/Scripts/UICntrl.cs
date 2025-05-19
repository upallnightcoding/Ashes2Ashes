using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UICntrl : MonoBehaviour
{
    [Header("UI Game Panels ...")]
    [SerializeField] private GameObject mainMenuPanel;
    [SerializeField] private GameObject gamePlayPanel;

    [Header("Testing Variables ...")]
    [SerializeField] private GameObject environment;

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("UICntrl ...");

        OpenMainMenu(null);
    }

 
    public void OpenMainMenu(EventData eventData)
    {
        Debug.Log("OpenMainMenu ...");
        CloseAllPanels();

        mainMenuPanel.SetActive(true);
    }

    public void StartGamePlay(EventData eventData)
    {
        CloseAllPanels();
       
        gamePlayPanel.SetActive(true);
        environment.SetActive(true);
    }

    private void CloseAllPanels()
    {
        mainMenuPanel.SetActive(false);
        gamePlayPanel.SetActive(false);
        environment.SetActive(false);
    }
}

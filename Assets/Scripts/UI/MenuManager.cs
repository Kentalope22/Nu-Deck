using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject _menuCanvasGO;
    [SerializeField] private GameObject _partyCanvasGO;

    [SerializeField] private GameObject _menuFirst;
    [SerializeField] private GameObject _partyFirst;

    private bool isPaused;

    private void Start()
    {
        _menuCanvasGO.SetActive(false); 
        _partyCanvasGO.SetActive(false);    

    }

    private void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            if (!isPaused)
            {
                Pause();
            }
            else
            {
                Unpause();
            }
        }
        
    }

    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        OpenMenu();
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        CloseAllMenus();

    }

    private void OpenMenu()
    {
        _menuCanvasGO.SetActive(true);
        _partyCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_menuFirst);
    }

    public void OpenPartyMenu()
    {
        _menuCanvasGO.SetActive(false);
        _partyCanvasGO.SetActive(true);

        EventSystem.current.SetSelectedGameObject(_partyFirst);

    }

    private void CloseAllMenus()
    {
        _menuCanvasGO.SetActive(false);
        _partyCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }

    public void OnResumePress()
    {
        Unpause();
    }

    public void OnPartyPress()
    {
        OpenPartyMenu();
    }

    public void OnPartyBackPress()
    {
        OpenMenu();
    }
}

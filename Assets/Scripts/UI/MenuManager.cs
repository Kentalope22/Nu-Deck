using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;


public class MenuManager : MonoBehaviour
{
    //canvas screens to be activated and deactivated
    [Header("Menu Objects")]
    [SerializeField] private GameObject _menuCanvasGO;
    [SerializeField] private GameObject _partyCanvasGO;

    //objs for default first selected in each menu
    [Header("Defaule First Selected")]
    [SerializeField] private GameObject _menuFirst;
    [SerializeField] private GameObject _partyFirst;

    private bool isPaused;
    //set canvases to inactive at game start
    private void Start()
    {
        _menuCanvasGO.SetActive(false); 
        _partyCanvasGO.SetActive(false);    

    }
    //checking for open menu input(escapekey for keyboard)
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

    #region Pause/Unpause Functions
    //pauses game, sets ingame tic speed to 0: DOES NOT pause user inputted animations
    public void Pause()
    {
        isPaused = true;
        Time.timeScale = 0f;
        OpenMenu();
        //add line to pause user inputted animations
    }

    public void Unpause()
    {
        isPaused = false;
        Time.timeScale = 1f;
        CloseAllMenus();
        //add line to unpause user inputted animations
    }
    #endregion

    #region Canvas Activation/Deactivation
    private void OpenMenu()
    {
        _menuCanvasGO.SetActive(true);
        _partyCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(_menuFirst);
    }


    private void CloseAllMenus()
    {
        _menuCanvasGO.SetActive(false);
        _partyCanvasGO.SetActive(false);

        EventSystem.current.SetSelectedGameObject(null);
    }
    #endregion

    #region Menu Button Actions
    public void OnResumePress()
    {
        Unpause();
    }

    public void OnQuitPress()
    {
        SceneManager.LoadSceneAsync(0);
        Unpause();
    }
    #endregion
}

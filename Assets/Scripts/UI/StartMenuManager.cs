using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class StartMenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (InputManager.instance.MenuOpenCloseInput)
        {
            OnTitleScreenPress();
        }
    }
    // Buttons to load in and out of start menu
    public void OnPlayPress()
    {
        SceneManager.LoadScene(2);
    }

    public void OnTitleScreenPress()
    {
        SceneManager.LoadSceneAsync(2);
        Time.timeScale = 1f;

    }

    public void OnReturnToTitlePress()
    {
        
        SceneManager.LoadScene(0);
        
    }

    
}

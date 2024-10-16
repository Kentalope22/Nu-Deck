using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleStarter : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("This is working");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            SceneManager.LoadScene(1);
        }
    }
}

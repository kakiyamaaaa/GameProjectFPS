using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CallMenu : MonoBehaviour
{
    public GameObject MainMenu;

    void Start()
    {
        MainMenu.SetActive(false);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            //MainMenu.SetActive(true);
            Application.Quit();
        }        
    }
}

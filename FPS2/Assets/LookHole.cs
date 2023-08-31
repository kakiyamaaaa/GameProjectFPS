using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookHole : MonoBehaviour
{
    public GameObject cam1;
    public GameObject cam2;
    public GameObject ThoughtsAboutHole;
    public GameObject LookText;
    public GameObject HoleObject;
    public bool inReach;

    void OnTriggerEnter(Collider other)
    {
        //if you're close enough, "answer" should appear on screen
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            ThoughtsAboutHole.SetActive(true);
            LookText.SetActive(true);
        }

       // if (other.gameObject.tag == "Reach" && ThoughtsAboutHole == false)
        {
            inReach = true;
            LookText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if you're not close enough, "answer" shouldn't appear on screen
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            LookText.SetActive(false);
        }
    }

    void Update()
    {
        //if you're close enough and you press "E" then the camera will change
        if (inReach && Input.GetButtonDown("Interact"))
        {
            cam1.SetActive(false);
            cam2.SetActive(true);
            LookText.SetActive(false);
        }
        //But if you're close enough and you press "Esc" then the camera will change back
        else if (inReach && Input.GetKeyDown(KeyCode.Escape))
        {
            cam1.SetActive(true);
            cam2.SetActive(false);
            HoleObject.SetActive(false);
        }
    }
}

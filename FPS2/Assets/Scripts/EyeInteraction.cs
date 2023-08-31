using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeInteraction : MonoBehaviour
{
    public GameObject DialogueBox;
    private bool isTimePaused;
    private float previousTimeScale;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        DialogueBox.SetActive(true);
        PauseTime();
    }

    void Update()
    {
        if (isTimePaused && Input.GetKeyDown(KeyCode.Space))
        {
            ResumeTime();
        }
    }

    void PauseTime()
    {
        if (!isTimePaused)
        {
            isTimePaused = true;
            previousTimeScale = Time.timeScale;
            Time.timeScale = 0f;
        }
    }

    void ResumeTime()
    {
        if (isTimePaused)
        {
            isTimePaused = false;
            Time.timeScale = previousTimeScale;
        }
    }
}
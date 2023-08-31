using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LetterScript : MonoBehaviour
{
    public GameObject answerText;
    public GameObject DialogueLetter;

    public AudioSource AnswerSound;
    public AudioSource EndSound;

    public bool inReach;
    private bool ringing;
    private bool quiet;

    private bool isTimePaused;
    private float previousTimeScale;

    void Start()
    {
        inReach = false;
        ringing = true;
        quiet = false;

        answerText.SetActive(false);        
    }

     void OnTriggerEnter(Collider other)
    {
        //if you're close enough, "answer" should appear on screen
        if (other.gameObject.tag == "Reach" && ringing)
        {
            inReach = true;
            answerText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        //if you're not close enough, "answer" shouldn't appear on screen
        if (other.gameObject.tag == "Reach" || Input.GetButtonDown("Interact"))
        {
            inReach = false;
            answerText.SetActive(false);
            DialogueLetter.SetActive(false);
        }
    }

    void Update()
    {
        //if you're close enough and it's ringing and you press "E" then the telephone light turn on, "answer" will disappear and "answersound" will play ounce
        if (inReach && ringing && Input.GetButtonDown("Interact"))
        {
            answerText.SetActive(false);
            //AnswerSound.Play();
            //text must appear
            DialogueLetter.SetActive(true);
            //PauseTime();
        }
        //But if you're close enough and it's quiet and you press "E" then nothing happens
        else if (inReach && quiet && Input.GetButtonDown("Interact"))
        {
            DialogueLetter.SetActive(false);
        }
    }
        //void PauseTime()
   // {
       // if (!isTimePaused)
  //      {
  //          isTimePaused = true;
   //         previousTimeScale = Time.timeScale;
   //         Time.timeScale = 0f;
   //     }
   // }
        //void ResumeTime()
   // {
       // if (isTimePaused)
   //     {
   //         isTimePaused = false;
   //         Time.timeScale = previousTimeScale;
   //     }
   // }
}
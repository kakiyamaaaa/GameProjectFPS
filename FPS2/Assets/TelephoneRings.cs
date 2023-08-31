using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TelephoneRings : MonoBehaviour
{
    public GameObject answerText;
    public GameObject TelephoneLight;
    public GameObject DialogueTelephone;

    public AudioSource RingSound;
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
        TelephoneLight.SetActive(true);
        RingSound.Play();
        
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
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            answerText.SetActive(false);
        }
    }

    void Update()
    {
        //if you're close enough and it's ringing and you press "E" then the telephone light turn on, "answer" will disappear and "answersound" will play ounce
        if (inReach && ringing && Input.GetButtonDown("Interact"))
        {
            TelephoneLight.SetActive(false);
            answerText.SetActive(false);
            RingSound.Stop();
            //AnswerSound.Play();
            //text must appear
            DialogueTelephone.SetActive(true);
            PauseTime();
        }
        //But if you're close enough and it's quiet and you press "E" then nothing happens
        else if (inReach && quiet && Input.GetButtonDown("Interact"))
        {
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

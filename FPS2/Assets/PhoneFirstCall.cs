using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PhoneFirstCall : MonoBehaviour
{
//    public AudioSource RingSound;
//    public AudioSource AnswerSound;
//    public AudioSource EndSound;

    private bool ringing;
    private bool quiet;

    public float callDuration = 2f;

    // Diálogo
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private bool isDialogueActive;

    private void Start()
    {
        StartPhoneCall();
    }

    private void Update()
    {
        if (isDialogueActive && (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return)))
        {
            if (index < lines.Length)
            {
                textComponent.text = lines[index];
                index++;
            }
            else
            {
                isDialogueActive = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void StartPhoneCall()
    {
//        RingSound.Play();
        Invoke("ActivateDialogue", callDuration);
    }

    private void ActivateDialogue()
    {
//        RingSound.Stop();
        isDialogueActive = true;
        index = 0;
        textComponent.text = lines[index];
        index++;
    }
}
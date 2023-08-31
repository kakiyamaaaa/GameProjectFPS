using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GuestCinematic : MonoBehaviour
{
    public TextMeshProUGUI textComponent;
    public string[] lines;
    public float textSpeed;

    private int index;
    private float timeElapsed;

    // Start is called before the first frame update
    void Start()
    {
        textComponent.text = string.Empty;
        StartDialogue();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Return))
        {
            if (textComponent.text == lines[index])
            {
                NextLine();
            }
            else
            {
                StopAllCoroutines();
                textComponent.text = lines[index];
            }
        }

        timeElapsed += Time.unscaledDeltaTime; // Use unscaledDeltaTime para o avanço do diálogo
    }

    void StartDialogue()
    {
        index = 0;
        timeElapsed = 0f;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        foreach (char c in lines[index].ToCharArray())
        {
            textComponent.text += c;
            yield return new WaitForSecondsRealtime(textSpeed); // Use WaitForSecondsRealtime para não ser afetado pela escala de tempo
        }
    }

    void NextLine()
    {
        if (index < lines.Length - 1)
        {
            index++;
            textComponent.text = string.Empty;
            StartCoroutine(TypeLine());
        }
        else
        {
            gameObject.SetActive(false);
            ResumeTime(); // Retoma o tempo quando o diálogo termina
        }
    }

    void ResumeTime()
    {
        Time.timeScale = 1f;
        //Guest.SetActive(true);
    }
}
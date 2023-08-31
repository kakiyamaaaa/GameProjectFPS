using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCInteraction : MonoBehaviour
{
    public GameObject interactText;
    public GameObject dialogueText;

    private bool inReach;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            interactText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            interactText.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se o jogador está perto do objeto e tem o keyOB equipado
        if (inReach && Input.GetButtonDown("Interact"))
        {
            dialogueText.SetActive(true);
        }
    }
}

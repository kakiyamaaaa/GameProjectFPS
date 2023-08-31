using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakGrid : MonoBehaviour
{
    public GameObject grid;
    public GameObject brokenGrid;
    public GameObject keyOB;
    public GameObject openText;

    private bool inReach;
    private bool alicateEquipado;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = true;
            openText.SetActive(true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Reach")
        {
            inReach = false;
            openText.SetActive(false);
        }
    }

    void Update()
    {
        // Verifica se o jogador está perto do objeto e tem o keyOB equipado
        if (inReach && keyOB.activeSelf)
        {
            if (Input.GetButtonDown("Interact"))
            {
                brokenGrid.SetActive(true);
                openText.SetActive(false);
                grid.SetActive(false);
            }
        }
    }
}
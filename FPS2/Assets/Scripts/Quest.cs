using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Quest : MonoBehaviour
{
    public GameObject Phone;

    void OnTriggerEnter(Collider other)
    {
        Debug.Log("hit detected");
        Phone.SetActive(true);
    }

    void Update()
    {
    }
}

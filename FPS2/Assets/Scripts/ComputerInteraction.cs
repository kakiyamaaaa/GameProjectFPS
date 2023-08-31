using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerInteraction : MonoBehaviour
{
    public GameObject Computer;
    public float pickUpRange;

    public BoxCollider coll;
    public Transform player;

    public AudioSource turnOn;
    public AudioSource turnOff;

    public bool on;
    public bool off;




    void Start()
    {
        off = true;
        Computer.SetActive(false);
    }




    void Update()
    {
        Vector3 distanceToPlayer = player.position - transform.position;
        if (distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E))
        {
            Computer.SetActive(true);
            // Time.timeScale = 0f;
            Cursor.visible = true;
            
            // turnOn.Play();
            off = false;
            on = true;
        }
        else if (on && Input.GetKeyDown(KeyCode.Escape) || distanceToPlayer.magnitude > pickUpRange)
        {
            Computer.SetActive(false);
            // Time.timeScale = 1f;
            Cursor.visible = false;
           
           // turnOff.Play();
           off = true;
           on = false;
        }



    }
}

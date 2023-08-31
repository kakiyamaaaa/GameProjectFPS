using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpController1 : MonoBehaviour
{
    public EmptyScript EmptyScript;
    public Rigidbody rb;
    public BoxCollider coll;
    public Transform player, Container, fpsCam;
    public GameObject gunContainer;

    public float pickUpRange;
    public float dropForwardForce, dropUpwardForce;

    public bool equipped;
    public static bool slotFull;

    private void Start()
    {
        //Setup
        if (!equipped)
        {
            EmptyScript.enabled = false;
            rb.isKinematic = false;
            coll.isTrigger = false;
            gunContainer.SetActive(false);
        }
        if (equipped)
        {
            EmptyScript.enabled = true;
            rb.isKinematic = true;
            coll.isTrigger = true;
            slotFull = true;
            gunContainer.SetActive(true);
        }
    }

    private void Update()
    {
        //Check if player is in range and "E" is pressed
        Vector3 distanceToPlayer = player.position - transform.position;
        if (!equipped && distanceToPlayer.magnitude <= pickUpRange && Input.GetKeyDown(KeyCode.E) && !slotFull) PickUp();

        //Drop if equipped and "Q" is pressed
        //if (equipped && Input.GetKeyDown(KeyCode.Q)) Drop();
    }

    private void PickUp()
    {
        equipped = true;
        slotFull = true;

        //Make weapon a child of the camera and move it to default position
        transform.SetParent(Container);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.Euler(Vector3.zero);
        transform.localScale = Vector3.one;

        gunContainer.SetActive(true);

        //Make Rigidbody kinematic and BoxCollider a trigger
        rb.isKinematic = true;
        coll.isTrigger = true;

        //Enable script
        EmptyScript.enabled = true;
    }
}

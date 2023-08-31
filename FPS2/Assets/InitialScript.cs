using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitialScript : MonoBehaviour
{
        void Start()
    {
        // Hide the cursor
        Cursor.visible = false;

        // Lock the cursor to the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }
}

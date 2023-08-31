using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootStep : MonoBehaviour
{
    public AudioSource AudioSource;

    public AudioClip ground;

    RaycastHit hit;
    public Transform RayStart;
    public float range;
    public LayerMask layerMask;

    public void Footstep()
    {
        if(Physics.Raycast(RayStart.position, RayStart.transform.up * -1, out hit, range, layerMask))
        {
            if (hit.collider.CompareTag("ground"))
            {
                PlayFootstepSoundL(ground);
            }
        }
    }

    void PlayFootstepSoundL(AudioClip audio)
    {
        AudioSource.pitch = Random.Range(0.8f, 1f);
        AudioSource.PlayOneShot(audio);
    }

    private void Update()
    {
        Debug.DrawRay(RayStart.position, RayStart.transform.up * -1, Color.green);
    }
}
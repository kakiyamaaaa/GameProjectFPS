using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    public GameObject player;
    private float damageRange;
    public float damageSet = 25f;
    public float minDamage;
    public float maxDamage;

    public bool randomDamage;
    public bool setDamage;

    public AudioClip[] sounds;
    private AudioSource source;

    private void Start()
    {
        damageRange = Random.Range(minDamage, maxDamage);
        source = player.GetComponent<AudioSource>();
    }
}
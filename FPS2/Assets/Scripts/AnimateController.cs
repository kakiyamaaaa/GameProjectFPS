using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AnimateController : MonoBehaviour
 {
    Animator animator;
 
     public Transform Player;
     int MoveSpeed = 8 ;
     int MaxDist = 10;
     int MinDist = 5;
 
 
 
 
     void Start()
     {
        animator = GetComponent<Animator>();
     }
 
     void Update()
     {
         transform.LookAt(Player);
 
         //if their distance is higher than MinDist, the chaser will stop crawling
         if (Vector3.Distance(transform.position, Player.position) >= MinDist)
         {
            animator.SetBool("Crawling", false);
             transform.position += transform.forward * MoveSpeed * Time.deltaTime;
 
 
             //if their distance is lower than MaxDist, the chaser will crawl
             if (Vector3.Distance(transform.position, Player.position) <= MaxDist)
             {
                 animator.SetBool("Crawling", true);
             }
 
         }
     }
 }
 
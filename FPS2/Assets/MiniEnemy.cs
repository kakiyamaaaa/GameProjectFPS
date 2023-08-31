using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MiniEnemy : MonoBehaviour
{
    public int HP = 100;
    public Animator animator;

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        if(HP<=0)
        {
            //Play Death Animation
            animator.SetTrigger("die");
            GetComponent<Collider>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
        }
        else
        {
            //Play Get Hit Animation
        }
    }
}


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public int HP, MaxHP = 100;
    public Animator animator;
    [SerializeField] FloatingHealthBar healthBar;

    public void Awake()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
    }

    private void Start()
    {
        HP = MaxHP;
        healthBar.UpdateHealthBar(HP, MaxHP);
    }

    public void TakeDamage(int damageAmount)
    {
        HP -= damageAmount;
        healthBar.UpdateHealthBar(HP, MaxHP);
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
